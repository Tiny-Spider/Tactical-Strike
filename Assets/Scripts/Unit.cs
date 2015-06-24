using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit: RTSObject {



    NavMeshAgent navMesh;
    public float baseDamage, baseMovementSpeed, baseAttackRange;
    public State[] state;
    

	// Use this for initialization
	void Start () {
	    //UnitManager.instance.GetUnitData// hier was ik. op welke manier apply je unit data op de unit?
	}

	// Update is called once per frame
	void Update () {
	
	}

    void initialize() {

    }
}
