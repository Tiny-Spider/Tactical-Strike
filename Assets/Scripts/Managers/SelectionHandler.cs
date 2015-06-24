using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour {

    public Camera myCamera;
    public Canvas canvas;
    RectTransform rectTransform;

    bool dragging;

	// Use this for initialization
	void Start () {
        dragging = false;
        myCamera = Camera.main;

        GameObject go = new GameObject();
        rectTransform = go.AddComponent<RectTransform>();
        rectTransform.transform.parent = canvas.transform;
        go.AddComponent<Image>();
        
	}
	


	// Update is called once per frame
	void Update () {


        if (Input.GetAxis("Fire1") > 0 && dragging) {
            Ondrag();
        }
        else
        {
            dragging = false;
        }

        if(Input.GetButtonDown("fire1")){
            dragging = true;
        }
        
	}

    void Ondrag() {
        Vector3 mousePosition = Input.mousePosition;
        rectTransform.position = mousePosition;
    }
}
