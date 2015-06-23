using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Structure : RTSObject {

    public Vector2 size;

    public UnitCreation[] units;
    public bool hasUnits {
        get {
            return units.Length > 0;
        }
    }
}

[System.Serializable]
public struct UnitCreation {
    public Unit unit;
    public int buildTime;
    public Cost[] cost;
}
