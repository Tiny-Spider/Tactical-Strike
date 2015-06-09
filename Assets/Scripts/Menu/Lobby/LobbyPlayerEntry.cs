using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class LobbyPlayerEntry : MonoBehaviour {
    public Text playerName;
    public Text playerFaction;
    public Image playerColor;
    public Image background;
    public Button kickButton;
    public Button factionButton;
    public Combobox factionCombobox;
    public Button colorButton;
    public Combobox colorCombobox;

    private Game.PlayerData playerData;

    public void Start() {
        if (!Network.isServer || Network.player == playerData.networkPlayer) {
            kickButton.gameObject.SetActive(false);
        }

        factionButton.gameObject.SetActive(false);
        factionCombobox.gameObject.SetActive(false);
        colorButton.gameObject.SetActive(false);
        colorCombobox.gameObject.SetActive(false);

        if (Network.player == playerData.networkPlayer) {
            InitalizeComboboxes();
        }
    }

    public void Initalize(Game.PlayerData playerData) {
        this.playerData = playerData;

        playerFaction.text = playerData.faction.ToString();
        playerColor.color = playerData.color.color;
        playerName.text = playerData.name;
    }

    private void InitalizeComboboxes() {
        factionButton.gameObject.SetActive(true);
        colorButton.gameObject.SetActive(true);

        foreach (Faction faction in Enum.GetValues(typeof(Faction))) {
            factionCombobox.Add(faction.ToString(), faction.ToString(), () =>
            {
                NetworkHandler.instance.SetFaction(faction);
            });
        }

        foreach (PlayerColor playerColor in PlayerColor.Values()) {
            ComboboxEntry entry = colorCombobox.Add(playerColor.color.ToString(), "", () =>
            {
                NetworkHandler.instance.SetColor(playerColor);
            });

            entry.image.color = playerColor.color;
        }
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
