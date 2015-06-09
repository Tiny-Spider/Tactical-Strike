using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkView))]
public class NetworkHandler : MonoBehaviour {
    public static NetworkHandler instance { private set; get; }


    public delegate void MapChangedEvent(MapData map);
    public event MapChangedEvent OnMapChanged = delegate { };

    public delegate void PlayerUpdateEvent(NetworkPlayer networkPlayer);
    public event PlayerUpdateEvent OnPlayerUpdate = delegate { };


    private NetworkView _networkView;

    void Awake() {
        instance = this;
        _networkView = GetComponent<NetworkView>();
    }

    void OnServerInitialized() {
        ChangeMap(MapManager.instance.GetMaps()[0]);
    }


    public void ChangeMap(MapData map) {
        StartCoroutine(_ChangeMap(map));
    }

    IEnumerator _ChangeMap(MapData map) {
        yield return new WaitForFixedUpdate();
        _networkView.RPC("OnChangeMap", RPCMode.AllBuffered, map.sceneName);
    }

    [RPC]
    void OnChangeMap(string sceneName) {
        MapManager mapManager = MapManager.instance;
        MapData map = mapManager.GetMapByScene(sceneName);
        Game game = GameManager.instance.game;

        if (map == null)
            return;

        Debug.Log("[NetworkHandler] Map has been changed to: " + map.name);
        game.map = map;
        OnMapChanged(map);
    }


    public void SetName(string name) {
        StartCoroutine(_SetName(name));
    }

    IEnumerator _SetName(string name) {
        yield return new WaitForFixedUpdate();
        _networkView.RPC("OnSetName", RPCMode.AllBuffered, name, Network.player);
    }

    [RPC]
    void OnSetName(string name, NetworkPlayer networkPlayer) {
        Game.PlayerData playerData = GameManager.instance.game.connectedPlayers[networkPlayer];

        if (playerData == null)
            return;

        Debug.Log("[NetworkHandler] Player " + networkPlayer.ToString() + " has changed their name to \"" + name + "\"");
        OnPlayerUpdate(networkPlayer);
    }
}
