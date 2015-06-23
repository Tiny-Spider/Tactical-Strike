using UnityEngine;
using System.Collections;

public class Faction : ScriptableObject {
    public string techName;
    public string displayName;

    public StructureCreation[] structures;
}

[System.Serializable]
public struct StructureCreation {
    public Structure structure;
    public Cost[] cost;
    public string[] requiredStructures;
}
