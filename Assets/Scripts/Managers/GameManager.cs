using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
    public Game game { private set; get; }

    private readonly string playerNameKey = "PlayerName";
    public string playerName;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        playerName = PlayerPrefs.GetString(playerNameKey);
    }

    void OnDestroy() {
        PlayerPrefs.SetString(playerNameKey, playerName);
        PlayerPrefs.Save();
    }

    // Events //
    void OnServerInitialized() {
        Debug.Log("[GameManager] Starting new game!");
        game = new Game();
    }

    void OnConnectedToServer() {
        Debug.Log("[GameManager] Starting new game!");
        game = new Game();
    }

    void OnDisconnectedFromServer() {
        Debug.Log("[GameManager] Deleting game!");
        game = null;
    }
}
