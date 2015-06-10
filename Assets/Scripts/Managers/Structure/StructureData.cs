using UnityEngine;
using System.Collections;

public class StructureData : MonoBehaviour {
    public Structure structure;

    public UnitCreation[] units;
    public bool hasUnits {
        get {
            return units.Length > 0;
        }
    }

	public struct UnitCreation {
        public UnitData unitData;
        public int buildTime;
        public Cost[] cost; 

        public struct Cost {
            public ResourceType resource;
            public int amount;
        }
    }
}
