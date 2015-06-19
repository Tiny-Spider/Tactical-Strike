using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit: MonoBehaviour, IDamageable, ISelectable {

    int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();
    NavMeshAgent navMesh;
	UnitData unitData;

	// Use this for initialization
	void Start () {
		unitData = UnitManager.instance.GetUnitData(gameObject.name); // hier was ik. op welke manier apply je unit data op de unit?

		if (GetComponent<NavMeshAgent>())
			navMesh = GetComponent<NavMeshAgent>();

		navMesh.speed = unitData.baseMovementSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int Gethealth() {
        throw new System.NotImplementedException();
    }

    public void Damage(Dictionary<DamageType, int> damage) {
        throw new System.NotImplementedException();
    }

    public bool HasStances() {
        throw new System.NotImplementedException();
    }

    public CursorType GetCursorType() {
        throw new System.NotImplementedException();
    }

    public void Select(){
        throw new System.NotImplementedException();
    }


}
