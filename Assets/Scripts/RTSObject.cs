using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RTSObject : MonoBehaviour, IDamageable, ISelectable {

    public Sprite image;
    public string techName;
    public string displayName;
    public int team;
    public bool hasStances = true;
    public Stance stance = Stance.Hold;

    public CursorType cursor = CursorType.Normal;

    public int health;
    Dictionary<DamageType, int> armor = new Dictionary<DamageType, int>();

    public void Damage(Dictionary<DamageType, int> damage) {
        /*
        #region debug
        string damageList = "Recived damage:" + Environment.NewLine;

        foreach (var _damage in damage) {
            damageList += _damage.Key + ": " + _damage.Value + Environment.NewLine;
        }

        Debug.Log(damageList);
        #endregion
        */

        foreach (var _damage in damage) {
            int realDamage = armor.ContainsKey(_damage.Key) ? _damage.Value - armor[_damage.Key] : _damage.Value;

            if (realDamage > 0) {
                health -= realDamage;
            }
        }

        if (health <= 0) {
            Die();
        }
    }

    public bool IsDead() {
        return health <= 0;
    }

    public void Die() {
        Destroy(gameObject);
    }

    public bool HasStances() {
        return hasStances;
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
