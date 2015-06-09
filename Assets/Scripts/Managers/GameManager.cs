using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance { private set; get; }

    public Game game { private set; get; }

    private readonly string playerNameKey = "PlayerName";
    public string playerName;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        instance = this;
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
        game = new Game();
    }

    void OnConnectedToServer() {
        game = new Game();
    }

    void OnDisconnectedFromServer() {
        game = null;
    }
}
