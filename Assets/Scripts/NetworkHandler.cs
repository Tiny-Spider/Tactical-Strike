using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkView))]
public class NetworkHandler : MonoBehaviour {
    public static NetworkHandler instance { private set; get; }

    // Server

    public delegate void TurnFinishedEvent(int team);
    public event TurnFinishedEvent OnTurnFinished = delegate { };

    public delegate void ScoreAddEvent(int team, int score);
    public event ScoreAddEvent OnScoreAdd = delegate { };

    public delegate void ReadyEvent(int team);
    public event ReadyEvent OnReady = delegate { };

    // Client

    //public delegate void TurnChangedEvent(Turn turn);
    //public event TurnChangedEvent OnTurnChanged = delegate { };

    //

    private NetworkView _networkView;

    void Awake() {
        instance = this;
        _networkView = GetComponent<NetworkView>();
    }


    //public void FinishTurn() {
    //    NetworkManager networkManager = NetworkManager.instance;
    //    _networkView.RPC("_FinishTurn", RPCMode.Server, networkManager.team);
    //}

    //[RPC]
    //void _FinishTurn(int team) {
    //    Debug.Log("Team " + team + " finished their turn");

    //    OnTurnFinished(team);
    //}

    //public void SetTurn(Turn turn) {
    //    NetworkManager networkManager = NetworkManager.instance;
    //    _networkView.RPC("_SetTurn", RPCMode.Server, (int) turn);
    //}

    //[RPC]
    //void _SetTurn(int turn) {
    //    Debug.Log("Turn changed: " + ((Turn) turn).ToString());

    //    OnTurnChanged((Turn)turn);
    //}

    //public void AddScore(int score) {
    //    NetworkManager networkManager = NetworkManager.instance;
    //    _networkView.RPC("_AddScore", RPCMode.Server, networkManager.team, score);
    //}

    //[RPC]
    //void _AddScore(int team, int score) {
    //    Debug.Log("Adding " + score + " score to team " + team);

    //    OnScoreAdd(team, score);
    //}
}
