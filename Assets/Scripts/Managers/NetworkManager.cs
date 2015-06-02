using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkView))]
public class NetworkManager : MonoBehaviour {
    public static NetworkManager instance { private set; get; }

    public string gameTypeName;
    public HostData[] serverList;

    public int clientScene;
    public int serverScene;

    public string gameName;
    public string gameDescription;
    public int port = 50;
    public int maxPlayers = 6;
    public bool useNAT = false;

    public delegate void ServerListUpdateEvent();
    public event ServerListUpdateEvent OnServerListUpdate = delegate { };

    public delegate void PlayerJoinedEvent();
    public event PlayerJoinedEvent OnPlayerJoin = delegate { };

    public delegate void PlayerLeftEvent();
    public event PlayerLeftEvent OnPlayerLeave = delegate { };

    private NetworkView _networkView;

    void Awake() {
        instance = this;
        _networkView = GetComponent<NetworkView>();
    }

    void Start() {
        // Predict what's needed
        useNAT = !Network.HavePublicAddress();
    }

    public void RefreshList() {
        MasterServer.RequestHostList(gameTypeName);
    }

    public void StartServer() {
        NetworkConnectionError connectionError = Network.InitializeServer(maxPlayers, port, useNAT);
        bool succes = HandleConnectionError(connectionError);

        if (succes) {
            MasterServer.RegisterHost(gameTypeName, gameName, gameDescription);
        }
    }

    public void Connect(HostData host) {
        NetworkConnectionError connectionError = Network.Connect(host);
        HandleConnectionError(connectionError);
    }

    bool HandleConnectionError(NetworkConnectionError error) {
        switch (error) {
            case NetworkConnectionError.NoError:
                return true;
            default:
                return false;
        }
    }

    void OnMasterServerEvent(MasterServerEvent masterEvent) {
        switch (masterEvent) {
            case MasterServerEvent.HostListReceived:
                serverList = MasterServer.PollHostList();
                OnServerListUpdate();
                break;
        }
    }

    public void StartGame() {
        _networkView.RPC("_StartGame", RPCMode.AllBuffered);
    }

    [RPC]
    void _StartGame() {
        // TODO: change
        Application.LoadLevel(Network.isServer ? serverScene : clientScene);
    }


    // Only called on server //
    void OnPlayerConnected(NetworkPlayer networkPlayer) {
        StartCoroutine(_AddPlayer(networkPlayer));
    }

    void OnServerInitialized() {
        StartCoroutine(_AddPlayer(Network.player));
    }

    void OnPlayerDisconnected(NetworkPlayer networkPlayer) {
        StartCoroutine(_RemovePlayer(networkPlayer));
    }
    //                        //

    IEnumerator _AddPlayer(NetworkPlayer networkPlayer) {
        yield return new WaitForFixedUpdate();
        _networkView.RPC("AddPlayer", RPCMode.AllBuffered, networkPlayer);
    }

    [RPC]
    void AddPlayer(NetworkPlayer networkPlayer) {
        Game game = GameManager.instance.GetGame();
        game.connectedPlayers.Add(networkPlayer, new Game.PlayerData());
        OnPlayerJoin();
    }

    IEnumerator _RemovePlayer(NetworkPlayer networkPlayer) {
        yield return new WaitForFixedUpdate();
        _networkView.RPC("RemovePlayer", RPCMode.AllBuffered, networkPlayer);
    }

    [RPC]
    void RemovePlayer(NetworkPlayer networkPlayer) {
        Game game = GameManager.instance.GetGame();
        game.connectedPlayers.Remove(networkPlayer);
        OnPlayerLeave();
    }
}
