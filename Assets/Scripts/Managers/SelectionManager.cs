using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {

	public static SelectionManager instance { private set; get; }

	public delegate void StructureSelectEvent(Structure structure);
	public event StructureSelectEvent OnSelectEvent = delegate { };

	void Awake()
	{
		instance = this;
	}

    void Update() {
        bool click = false;
        //On click
        if (Input.GetAxis("Fire1") > 0 && !click)
        {
            
        }

    }
	
}
