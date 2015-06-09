using UnityEngine;
using System.Collections;

public class InGameManager : MonoBehaviour {

    Time gameTime;
    public UnitManager unitManager;

	// Use this for initialization
	void Awake () {
        unitManager = GetComponent<UnitManager>();
        unitManager.LoadUnits();
        
	}
	
	// Update is called once per frame
	void Update () {
	}
}
