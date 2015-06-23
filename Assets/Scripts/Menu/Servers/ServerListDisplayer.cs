using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(LayoutGroup))]
public class ServerListDisplayer : MonoBehaviour {
    public ServerListEntry entryPrefab;
    
    public Color colorEven;
    public Color colorOdd;

    void Awake() {
        Clear();

        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnServerListUpdate += Refresh;
    }

    void OnDestroy() {
        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnServerListUpdate -= Refresh;
    }

    void Clear() {
        ServerListEntry[] entries = GetComponentsInChildren<ServerListEntry>();

        foreach (ServerListEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh() {
        NetworkManager networkManager = NetworkManager.instance;
        HostData[] serverList = networkManager.serverList;

        Clear();

        Debug.Log("[ServerListDisplayer] Refresh");

        int current = 0;

        foreach (HostData server in serverList) {
            ServerListEntry entry = Instantiate(entryPrefab);

            entry.Initalize(server);
            entry.transform.SetParent(transform);
            entry.SetColor(current % 2 == 0 ? colorEven : colorOdd);

            current++;
        }
    }
}
