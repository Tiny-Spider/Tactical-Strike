using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RTSObject : MonoBehaviour, IDamageable, ISelectable {
    public static Dictionary<string, Dictionary<StateType, State>> states = new Dictionary<string, Dictionary<StateType, State>>();

    public Sprite image;
    public string techName;
    public string displayName;
    public int team;

    public CursorType cursor = CursorType.Normal;

    public int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();

    public void Damage(System.Collections.Generic.Dictionary<DamageType, int> damage) {
        throw new System.NotImplementedException();
    }

    public bool HasStances() {
        throw new System.NotImplementedException();
    }

    public CursorType GetCursorType() {
        return cursor;
    }

    public int Gethealth() {
        return health;
    }

    public int SetHealth(int amount) {
        health = amount;
        return Gethealth();
    }

    public int Heal(int amount) {
        health += amount;
        return Gethealth();
    }

    public RTSObject GetOwner() {
        return this;
    }
}
