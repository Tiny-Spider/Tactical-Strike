using UnityEngine;
using System.Collections;

public class QueueItem : MonoBehaviour {

    int unitID;


    public QueueItem(int unitID){
        this.unitID = unitID;
    }

    public int GetUnitID() {

        return unitID;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
