using UnityEngine;
using System.Collections;

public class UnitData : ScriptableObject {

    public Unit unit;
    public UnitType unitType;
    public Texture2D image;
    public string name;
    public float baseDamage, baseMovementSpeed, baseAttackRange;
    public State[] state;

}
