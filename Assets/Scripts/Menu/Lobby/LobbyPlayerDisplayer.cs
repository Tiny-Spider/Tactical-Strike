using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(LayoutGroup))]
public class LobbyPlayerDisplayer : MonoBehaviour {
    public LobbyPlayerEntry entryPrefab;

    public Color colorEven;
    public Color colorOdd;
    public Color ownColor;

    void Awake() {
        Clear();

        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnPlayerJoin += Refresh;
        networkManager.OnPlayerLeave += Refresh;

        NetworkHandler networkHandler = NetworkHandler.instance;
        networkHandler.OnPlayerUpdate += Refresh;
    }

    void OnDestroy() {
        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnPlayerJoin -= Refresh;
        networkManager.OnPlayerLeave -= Refresh;

        NetworkHandler networkHandler = NetworkHandler.instance;
        networkHandler.OnPlayerUpdate -= Refresh;
    }

    void Clear() {
        LobbyPlayerEntry[] entries = GetComponentsInChildren<LobbyPlayerEntry>();

        foreach (LobbyPlayerEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh(NetworkPlayer networkPlayer) {
        Game game = GameManager.instance.game;

        Clear();

        Debug.Log("[LobbyPlayerDisplayer] Refresh");

        int current = 0;

        foreach (var player in game.GetPlayers()) {
            LobbyPlayerEntry entry = Instantiate(entryPrefab);
            entry.Initalize(player.Value);
            entry.transform.SetParent(transform);

            if (player.Key == Network.player) {
                entry.SetColor(ownColor);
            } else {
                entry.SetColor(current % 2 == 0 ? colorEven : colorOdd);
            }

            current++;
        }

    }
}
