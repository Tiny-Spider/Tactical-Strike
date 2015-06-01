using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit: IDamageable, ISelectable {

    int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();
    NavMeshAgent navMesh;

	// Use this for initialization
	void Start () {
	
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
}
