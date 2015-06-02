using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerListEntry : MonoBehaviour {
    public Text serverName;
    public Text serverDescription;
    public Text serverPlayerCount;
    public Image background;

    private HostData hostData;

    public void Initalize(HostData hostData) {
        this.hostData = hostData;

        serverName.text = hostData.gameName;
        serverDescription.text = hostData.comment;
        serverPlayerCount.text = hostData.connectedPlayers + "/" + (hostData.playerLimit + 1);
    }

    public void Connect() {
        // Remove invalid entries
        if (hostData == null) {
            Destroy(gameObject);
            return;
        }

        NetworkManager networkManager = NetworkManager.instance;
        networkManager.Connect(hostData);
    }

    public void SetColor(Color color) {
        background.color = color;
    }
}
