using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    FactionType faction;
    string playerName;
    HashSet<Unit> units;
    HashSet<Structure> structures;
    Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
