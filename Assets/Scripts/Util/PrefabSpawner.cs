using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour {
    public Vector3 offset;
    public int amount;
    public GameObject prefab;
    private Vector3 startPosition;

    public void GeneratePrefabs() {
        startPosition = transform.position;

        for (int i = 0; i < amount; i++) {
            Instantiate(prefab, startPosition + (offset * i), prefab.transform.rotation);
        }
    }
}
