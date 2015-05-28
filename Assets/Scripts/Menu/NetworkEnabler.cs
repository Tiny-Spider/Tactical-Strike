using UnityEngine;
using System.Collections;

public class NetworkEnabler : MonoBehaviour {
    public bool showForClient = false;
    public bool showForServer = false;

    void Start() {
        switch (Network.peerType) {
            case NetworkPeerType.Client:
                gameObject.SetActive(showForClient);
                break;
            case NetworkPeerType.Server:
                gameObject.SetActive(showForServer);
                break;
        }
    }
}
