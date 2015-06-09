using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButton : MonoBehaviour {

	public Stance stance;
	public Text textChild;
	private int enumID;

	void Awake()
	{
		UpdateGeneralActions();
	}

	void UpdateGeneralActions()
	{
		enumID = (int)stance;

		switch (stance)
		{
			case Stance.Aggressive:
			//if(ISelectable.currentTarget == unit)
			//{
				textChild.text = "Attack";
				//textChild.transform.parent.GetComponent<Button>().enabled = true;
			//}
			//else if(ISelectable.currentTarget == Structure)
			//textChild.text = "Waypoint";
			break;
			case Stance.Defensive:
			//if(ISelectable.currentTarget == unit)
			textChild.text = "Defend";
			//else if(ISelectable.currentTarget == Structure)
			//{ 
			//textChild.transform.parent.GetComponent<Button>().enabled = false;
			//textChild.text = "";
			//}
			break;
			case Stance.Guard:
			//if(ISelectable.currentTarget == unit)
			textChild.text = "Guard";
			//else if(ISelectable.currentTarget == Structure)
			//{ 
			//textChild.transform.parent.GetComponent<Button>().enabled = false;
			//textChild.text = "";
			//}
			break;
			case Stance.Hold:
			//if(ISelectable.currentTarget == unit)
			textChild.text = "Hold";
			//else if(ISelectable.currentTarget == Structure)
			//{ 
			//textChild.transform.parent.GetComponent<Button>().enabled = false;
			//textChild.text = "";
			//}
			break;
		}
	}
}
