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
        if (Input.GetAxis("Fire1") > 0 && !click)
        {
            bool addToSelection = Input.GetButton("KeyModifier1");
            click = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit);
            Unit _unit = hit.collider.gameObject.GetComponent<Unit>();
            if (_unit)
            {
                Debug.Log("Unit hit " + _unit.name);
                //needs team check.

            }
        }
        else if (Input.GetAxis("Fire1") <= 0)
        {
            click = false;
        }

    }
	
}
