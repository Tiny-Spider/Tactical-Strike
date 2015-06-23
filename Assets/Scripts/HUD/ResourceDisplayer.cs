using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceDisplayer : MonoBehaviour {
    public ResourceDisplay[] resourceDisplays;

	void Start() {
        Player player = GameManager.instance.game.GetPlayer();

        player.OnResourcesChanged += Refresh;

        Refresh();
	}

    void OnDestroy() {
        if (GameManager.instance && GameManager.instance.game != null) {
            Player player = GameManager.instance.game.GetPlayer();
            player.OnResourcesChanged -= Refresh;
        }
    }

    void Refresh() {
        Player player = GameManager.instance.game.GetPlayer();

        Debug.Log("[ResourceDisplayer] Refresh");

        foreach (var resourceAmount in player.GetResources()) {
            foreach (ResourceDisplay resourceDisplay in resourceDisplays) {
                if (resourceDisplay.resourceType == resourceAmount.Key) {
                    resourceDisplay.valueText.text = resourceAmount.Value.ToString();
                }
            }
        }
	}

    [System.Serializable]
    public struct ResourceDisplay {
        public ResourceType resourceType;
        public Text valueText;
    }
}
