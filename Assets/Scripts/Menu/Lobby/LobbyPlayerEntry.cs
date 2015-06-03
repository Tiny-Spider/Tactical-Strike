using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyPlayerEntry : MonoBehaviour {
    public Text playerName;
    public Text playerFaction;
    public Image background;
    public Button kickButton;

    private Game.PlayerData playerData;

    public void Start() {
        if (!Network.isServer || Network.player == playerData.networkPlayer) {
            kickButton.gameObject.SetActive(false);
        }
    }

    public void Initalize(Game.PlayerData playerData) {
        this.playerData = playerData;

        playerName.text = playerData.name;
        playerFaction.text = playerData.faction.ToString();
    }

    public void SetColor(Color color) {
        background.color = color;
    }

    public void Kick() {
        if (Network.isServer) {
            Network.CloseConnection(playerData.networkPlayer, true);
        }
    }
}
