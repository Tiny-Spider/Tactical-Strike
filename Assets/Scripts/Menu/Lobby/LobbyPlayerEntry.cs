using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyPlayerEntry : MonoBehaviour {
    public Text playerName;
    public Text playerFaction;
    public Image background;

    public void Initalize(Game.PlayerData playerData) {
        playerName.text = playerData.name;
        playerFaction.text = playerData.faction.ToString();
    }

    public void SetColor(Color color) {
        background.color = color;
    }
}
