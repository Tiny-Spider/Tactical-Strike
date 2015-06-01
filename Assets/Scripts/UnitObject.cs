using UnityEngine;
using System.Collections;

public class UnitObject : ScriptableObject {

    public Texture2D image;
    public string name;
    public float baseDamage, baseMovementSpeed, baseAttackRange;
    public State[] state;

}
