using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance { private set; get; }

    private Game game;

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

    public Game GetGame() {
        if (game == null) {
            game = new Game();
        }

        return game;
    }
}
