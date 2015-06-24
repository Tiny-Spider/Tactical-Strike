using UnityEngine;
using System.Collections;

public class tempPathsetHack : MonoBehaviour {
    public Unit unit;
    public Transform target;

    private Vector3 pos = Vector3.zero;

    void Update() {
        if (target.transform.position != pos) {
            pos = target.transform.position;

            unit.SetTargetPosition(pos);
        }
    }
}
