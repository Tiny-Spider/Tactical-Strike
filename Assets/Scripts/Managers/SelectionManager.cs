using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {

	public static SelectionManager instance { private set; get; }

	public delegate void StructureSelectEvent(Structure structure);
	public event StructureSelectEvent OnSelectEvent = delegate { };

    [Tooltip("Layers that should get detected by the raycast")]
    public LayerMask SelectionLayers;

    bool click = false;
	void Awake()
	{
		instance = this;
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
            {
                //Checks if units belongs to players team.
                //_selectable.GetRTSObject

            }
        }
    }

    public void UnitClick() {

    }
	
}
