using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
	Text textGold;
	Text textIron;
	Player player;
	GameObject unitSelection;
	GameObject buildQueue;

	void Start()
	{
		//NetworkManager networkManager = NetworkManager.instance;

		if (!player)
			return;

		//player.UpdateResources += RefreshResources;
	}

	void OnDestroy()
	{
		if (!player)
			return;

		//player.UpdateResources += RefreshResources;
	}

	void RefreshResources()
	{
		//Gold.text = player.resources.gold; (ofzo)
		//Iron.text = player.resources.iron; (ofzo)
	}
}
