using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
<<<<<<< HEAD

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
=======
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
>>>>>>> f7ee493b572fd84fd8ef435c41c70612f19b12cc
}
