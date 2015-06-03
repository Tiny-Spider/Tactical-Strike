using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
	Text Gold;
	Text Iron;
	Player player;
	GameObject UnitSelection;
	GameObject BuildQueue;

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

	public void SpawnUnit(DamageType type)
	{

	}

	public void ActivateGeneralAction(int enumNumber)
	{
		switch(enumNumber)
		{
			case 1:
				//HoldUnit(ISelectable.currentUnit);
			break;
			case 2:
				//AgressiveUnit(ISelectable.currentUnit);
			break;
			case 3:
				//DefensiveUnit(ISelectable.currentUnit);
			break;
			case 4:
				//GuardUnit(ISelectable.currentUnit);
			break;
			case 5:
				//ChangeWaypointPosition(ISelectable.currentBuilding);
			break;
		}
	}

	void HoldUnit(GameObject[] unit)
	{
		
	}

	void AgressiveUnit(GameObject unit)
	{

	}

	void DefensiveUnit(GameObject unit)
	{

	}

	void GuardUnit(GameObject unit)
	{

	}

	void ChangeWaypointPosition(GameObject structure)
	{
		
	}
}
