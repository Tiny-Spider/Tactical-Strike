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
    }

    void Start() {
        NetworkManager networkManager = NetworkManager.instance;

        if (!networkManager)
            return;

        networkManager.OnPlayerJoin += Refresh;
        networkManager.OnPlayerLeave += Refresh;
    }

    void OnDestroy() {
        NetworkManager networkManager = NetworkManager.instance;

        if (!networkManager)
            return;

        networkManager.OnPlayerJoin -= Refresh;
        networkManager.OnPlayerLeave -= Refresh;
    }

    void Clear() {
        LobbyPlayerEntry[] entries = GetComponentsInChildren<LobbyPlayerEntry>();

        foreach (LobbyPlayerEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh() {
        Game game = GameManager.instance.game;

        Clear();

        int current = 0;

        foreach (var player in game.connectedPlayers) {
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
