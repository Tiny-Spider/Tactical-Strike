using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour {

    public LayerMask affectedLayers;
    public GUIStyle selectionSkin;
    public Camera myCamera;
    public Canvas canvas;
    public RectTransform rectTransform;

    SelectionManager selectionManager;

    bool startDragging;
    bool dragging;
    Vector3 startMousePosition;
    Vector2 temp;

    Vector3 selectionPointA;
    Vector3 selectionPointB;

    Vector3 centerPoint;
    float distance;

    public LayerMask terrainMask;
    public float maxDistanceRay = 100f;


	// Use this for initialization
	void Start () {
        selectionManager = GetComponent<SelectionManager>();
        startDragging = false;
        myCamera = Camera.main;
        
	}

    void OnGUI() {
        if (dragging) {
            GUI.Box(new Rect(startMousePosition.x, Screen.height - startMousePosition.y , Input.mousePosition.x - startMousePosition.x  ,
                Screen.height - Input.mousePosition.y - (Screen.height - startMousePosition.y)), "", selectionSkin);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2")) {
            OnDragExit();
        }


        if (Input.GetButtonUp("Fire1") && dragging) {
            OnDragConfirm();
        }
        else if (startDragging) {
            dragging = true;
            startDragging = false;
        }
        else if (Input.GetButtonDown("Fire1")) {
            startDragging = true;
            print("Start Drag");
            startMousePosition = Input.mousePosition;
            print(startMousePosition);
        }


        
	}

    void Ondrag() {

     

        
    }

    void OnDragConfirm() {
        Debug.Log("Drag Confirm");
        dragging = false;
        Debug.Log("StartMousePos : " + startMousePosition);
        Debug.Log("CurrentMousPos : " + Input.mousePosition);

        selectionPointA = GetTargetPosition(myCamera, startMousePosition);
        selectionPointB = GetTargetPosition(myCamera, Input.mousePosition);

        if (selectionPointA == Vector3.zero || selectionPointB == Vector3.zero)
            return;

        //Vector3 a =  GetTargetPosition(myCamera, (startMousePosition + Input.mousePosition) / 2);
        centerPoint = (selectionPointA + selectionPointB) / 2f;

        Debug.DrawLine(myCamera.transform.position, centerPoint, Color.black, 5f);


        Debug.DrawLine(myCamera.transform.position, selectionPointA, Color.magenta, 5f);
        Debug.DrawLine(myCamera.transform.position, selectionPointB, Color.cyan, 5f);

        Debug.Log(selectionPointA);
        Debug.Log(selectionPointB);

       // centerPoint = selectionPointA + selectionPointB * .5f;
        distance = Vector3.Distance(selectionPointA, selectionPointB) / 2;

        Collider[] colliders = Physics.OverlapSphere(centerPoint, distance, affectedLayers);
        List<RTSObject> withinSelection = new List<RTSObject>();
        Rect rect = new Rect(selectionPointA.x, selectionPointA.z, selectionPointA.x - selectionPointB.x, selectionPointA.y - selectionPointB.y);
        foreach (Collider collider in colliders) {
            Vector2 position;
            position.x = collider.transform.position.x;
            position.y = collider.transform.position.z;

            if(rect.Contains(position)){
                ISelectable iselectable = collider.GetComponent<ISelectable>();
                withinSelection.Add(iselectable.GetOwner());
            }
        }
        selectionManager.NewCurrentselection(withinSelection.ToArray());
       
    }

    void OnDragExit() {
        Debug.Log("Drag Exit");
        dragging = false;
        rectTransform.gameObject.SetActive(false);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(centerPoint,distance);
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    public Vector3 GetTargetPosition(Camera cam, Vector2 screenPos) {
        Ray ray = cam.ScreenPointToRay (screenPos);
        RaycastHit hit;
        Vector3 targetPosition = Vector3.zero;

        Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green, 5f);

        if (Physics.Raycast(ray, out hit, maxDistanceRay, terrainMask)) {
            targetPosition = hit.point;
        }

        return targetPosition;
    }
}
