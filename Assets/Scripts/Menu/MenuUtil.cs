using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(MenuControl))]
public class MenuUtil : MonoBehaviour {
    public MenuPanel mainPanel;
    public MenuPanel lobbyPanel;

    private MenuControl menuControl;

    void Awake() {
        menuControl = GetComponent<MenuControl>();
    }

    public void Exit() {
        #if UNITY_EDITOR
            Debug.Break();
        #else
            Application.Quit();
        #endif
    }
    

    // Server

    

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
