using UnityEngine;
using System.Collections;

public class StructureData : ScriptableObject {
    public Structure structure;

    public UnitCreation[] units;
    public bool hasUnits {
        get {
            return units.Length > 0;
        }
    }

    [System.Serializable]
	public struct UnitCreation {
        public UnitData unitData;
        public int buildTime;
        public Cost[] cost; 

        [System.Serializable]
        public struct Cost {
            public ResourceType resource;
            public int amount;
        }
    }
}
