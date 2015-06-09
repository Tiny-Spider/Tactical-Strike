using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyHandler : MonoBehaviour {
    public Image mapImage;
    public Text mapInfo;

    void Awake() {
        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnPlayerJoin += OnPlayerJoin;

        NetworkHandler networkHandler = NetworkHandler.instance;
        networkHandler.OnMapChanged += Refresh;
	}

    void OnDestroy() {
        NetworkManager networkManager = NetworkManager.instance;
        networkManager.OnPlayerJoin -= OnPlayerJoin;

        NetworkHandler networkHandler = NetworkHandler.instance;
        networkHandler.OnMapChanged -= Refresh;
    }

    void OnPlayerJoin(NetworkPlayer networkPlayer) {
        if (networkPlayer.Equals(Network.player)) {
            NetworkHandler.instance.SetName(GameManager.instance.playerName);
        }
    }

	void Refresh(MapData map) {
        mapImage.sprite = map.image;
        mapInfo.text = map.GetInfo();
	}
}
