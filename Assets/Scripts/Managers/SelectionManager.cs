using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {

	public static SelectionManager instance { private set; get; }
	public delegate void StructureSelectEvent(Structure structure);
	public event StructureSelectEvent OnSelectEvent = delegate { };

    [Tooltip("Layers that should get detected by the raycast")]
    public LayerMask SelectionLayers;

    private List<RTSObject> currentSelection = new List<RTSObject>();
    private Dictionary<int, List<RTSObject>> controlGroups = new Dictionary<int,List<RTSObject>>();
    private bool click = false;
	void Awake()
	{
        //needed?
		instance = this;


        InitializeControlGroups();
	}

    void InitializeControlGroups() {
        //Clear lists before initializing
        controlGroups.Clear();
        //Used magic number for now (9)
        for (int i = 0; i < 9; i++) {
            List<RTSObject> tempList = new List<RTSObject>();
            controlGroups.Add(i,tempList);
        }
    }

    void Update() {      
        //On click
        if (Input.GetButtonDown("Fire1"))
        {
            bool addToSelection = Input.GetButton("KeyModifier1");
            click = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            ISelectable _selectable = hit.collider.gameObject.GetComponent<ISelectable>();
            if (_selectable != null)
                RTSObjectClick(_selectable);
            else
                OtherClick();
        }
    }

    /// <summary>
    /// handles other clicks
    /// </summary>
    public void OtherClick() {
        currentSelection.Clear();
        Debug.Log("Cleared current selection");
    }

    /// <summary>
    /// Handles the funtions that happen when clicked on a RPGObject
    /// </summary>
    /// <param name="_selectable"></param>
    public void RTSObjectClick(ISelectable _selectable) {
        //Checks if units belongs to players team.
        if (_selectable.GetOwner().team.Equals(GameManager.instance.game.GetPlayer().team)) {
            currentSelection.Clear();
            currentSelection.Add(_selectable.GetOwner());
            Debug.Log("Current selected = " + currentSelection[0]);
        }
    }

    /// <summary>
    /// Switch between saved control groups
    /// </summary>
    public void SelectControlGroup() {
        //Used
    }
	
}
