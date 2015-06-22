using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Structure : MonoBehaviour, IDamageable, ISelectable {
    public string techName;
    public string displayName;
    public Sprite image;
    public Vector2 size;

    public UnitCreation[] units;
    public bool hasUnits {
        get {
            return units.Length > 0;
        }
    }

    float health;

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

[System.Serializable]
public struct UnitCreation {
    public Unit unit;
    public int buildTime;
    public Cost[] cost;
}
