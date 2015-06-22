using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public BuildMeshCreator buildMeshCreator;

    public LayerMask noBuild;
    public LayerMask terrain;

    private Vector2 canBuild = new Vector2(0, 1);
    private Vector2 cantBuild = new Vector2(1, 1);
    private Vector2 canBuildUp = new Vector2(0, 0);
    private Vector2 cantBuildUp = new Vector2(1, 0);

    private Structure structure;
    private Vector2 buildSelection;

    private bool building = false;

    public void StartBuild(Structure structure) {
        Debug.Log("[BuildManager] Starting building of: " + structure.displayName);

        this.structure = structure;
        buildSelection = structure.size;

        buildMeshCreator.CreatePlane((int)buildSelection.x, (int)buildSelection.y);

        for (int y = 0; y < buildSelection.y; y++) {
            for (int x = 0; x < buildSelection.x; x++) {
                buildMeshCreator.UpdateGrid(new Vector2(x, y), (y == buildSelection.y - 1) ? canBuildUp : canBuild);
            }
        }

        building = true;
    }

    void Update() {
        if (!building)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, terrain)) {
            Vector3 point = hit.point;

            point.x = (int)point.x;
            point.z = (int)point.z;

            if (structure.size.x % 2 == 0) {
                point.x += .5F;
            }

            if (structure.size.y % 2 == 0) {
                point.z += .5F;
            }

            transform.position = point;
        }
    }
}
