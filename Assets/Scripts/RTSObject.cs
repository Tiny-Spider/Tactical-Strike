using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RTSObject : MonoBehaviour, IDamageable, ISelectable{

    public string techName;
    public string displayName;
    public int team;

    int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();
    public Sprite image;

    public int Gethealth() {
        throw new System.NotImplementedException();
    }

    public void Damage(System.Collections.Generic.Dictionary<DamageType, int> damage) {
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

    public void AddToSelection() {
        throw new System.NotImplementedException();
    }

    public RTSObject GetRTSObject() {
        return this;   
    }
}
