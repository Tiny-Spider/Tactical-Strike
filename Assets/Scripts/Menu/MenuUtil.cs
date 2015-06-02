using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(MenuControl))]
public class MenuUtil : MonoBehaviour {
    public MenuPanel mainPanel;
    public MenuPanel lobbyPanel;
    public MenuPanel newPopup;
    public MenuPanel savedPopup;

    private MenuControl menuControl;

    void Awake() {
        menuControl = GetComponent<MenuControl>();
    }

    void Start() {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null && gameManager.playerName.IsEmpty()) {
            menuControl.ShowPopupPanel(newPopup);
        }
    }

    public void Exit() {
        #if UNITY_EDITOR
            Debug.Break();
        #else
            Application.Quit();
        #endif
    }

    public void SetName(InputField inputField) {
        GameManager.instance.playerName = inputField.text;
    }

    public void RefreshServerList() {
        NetworkManager networkManager = NetworkManager.instance;
        networkManager.RefreshList();
    }

    // Server

    public void SetPort(InputField inputField) {
        int port;

        if (int.TryParse(inputField.text, out port)) {
            port = Mathf.Clamp(port, 1, 65535);

            NetworkManager.instance.port = port;
        }
    }

    public void SetNAT(Toggle toggle) {
        NetworkManager.instance.useNAT = toggle.isOn;
    }

    public void SetGameName(InputField inputField) {
        NetworkManager.instance.gameName = inputField.text;
    }

    public void SetGameDescription(InputField inputField) {
        NetworkManager.instance.gameDescription = inputField.text;
    }

    public void Connect() {
        NetworkManager.instance.StartServer();
    }

    public void Disconnect() {
        Network.Disconnect();
    }

    // Events

    void OnServerInitialized() {
        menuControl.ShowPanel(lobbyPanel);
    }

    void OnConnectedToServer() {
        menuControl.ShowPanel(lobbyPanel);
    }

    void OnDisconnectedFromServer() {
        menuControl.ShowPanel(mainPanel);
    }
}
