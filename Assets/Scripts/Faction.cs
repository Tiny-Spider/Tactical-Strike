using UnityEngine;
using System.Collections;

public class Faction : ScriptableObject {
    public string techName;
    public string displayName;

    public StructureCreation[] structures;

    public struct StructureCreation {
        public Structure structure;
        public string[] requiredStructures;
    }
}
