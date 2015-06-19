using UnityEngine;
using System.Collections;

public class UnitData : ScriptableObject {

    public string name;
    public string displayName;
    public Unit unit;
    public Texture2D image;
    public float baseDamage, baseMovementSpeed, baseAttackRange;
    public State[] state;
}
