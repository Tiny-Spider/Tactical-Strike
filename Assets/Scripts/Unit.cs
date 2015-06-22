using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit: MonoBehaviour, IDamageable, ISelectable {

    public string techName;
    public string displayName;

    public Texture2D image;
    public float baseDamage, baseMovementSpeed, baseAttackRange;
    public State[] state;

    int unitID;
    int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();
    NavMeshAgent navMesh;

	// Use this for initialization
	void Start () {
	    //UnitManager.instance.GetUnitData// hier was ik. op welke manier apply je unit data op de unit?
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void initialize() {

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

    public void Select() {
        throw new System.NotImplementedException();
    }

    public void AddToSelection()
    {
        throw new System.NotImplementedException();
    }
}
