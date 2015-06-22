using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public BuildMeshCreator buildMeshCreator;

    public delegate void StructureBuildEvent(Structure structure);
    public event StructureBuildEvent OnStructureBuild = delegate { };

    public LayerMask noBuild;
    public LayerMask terrain;

    private Vector2 allowBuild = new Vector2(0, 1);
    private Vector2 disallowBuild = new Vector2(1, 1);
    private Vector2 allowBuildUp = new Vector2(0, 0);
    private Vector2 disallowBuildUp = new Vector2(1, 0);

    private Structure structure;
    private Vector2 structureSize;

    private bool building = false;
    private bool canBuild = false;

    public void StartBuild(Structure structure) {
        Debug.Log("[BuildManager] Starting building of: " + structure.displayName);

        this.structure = structure;
        structureSize = structure.size;
        building = true;

        buildMeshCreator.CreatePlane((int)structureSize.x, (int)structureSize.y);
    }

    void Update() {
        if (!building)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100, terrain)) 
            return;

        Vector3 point = hit.point;

        point.x -= (structureSize.x / 2f);
        point.z -= (structureSize.y / 2f);

        point.x = Mathf.RoundToInt(point.x);
        point.z = Mathf.RoundToInt(point.z);

        transform.position = point;

        canBuild = true;
        for (int x = 0; x < structureSize.x; x++) {
            for (int y = 0; y < structureSize.y; y++) {
                Vector3 worldPos = point + new Vector3(x + 0.5f, 0, y + 0.5f);

                if (Physics.CheckSphere(worldPos, .49f, noBuild)) {
                    buildMeshCreator.UpdateGrid(new Vector2(x, y), (y == structureSize.y - 1) ? disallowBuildUp : disallowBuild);
                    canBuild = false;
                } else {
                    buildMeshCreator.UpdateGrid(new Vector2(x, y), (y == structureSize.y - 1) ? allowBuildUp : allowBuild);
                }
            }
        }

        if (canBuild && Input.GetButtonDown("Fire1")) {
            EndBuild();
        }
    }

    void EndBuild() {
        building = false;
        buildMeshCreator.meshFilter.mesh = null;

        Structure structure = Network.Instantiate(this.structure, transform.position, Quaternion.identity, 0) as Structure;
        OnStructureBuild(structure);
    }

    void OnDrawGizmosSelected() {
        if (!building)
            return;

        for (int x = 0; x < structureSize.x; x++) {
            for (int y = 0; y < structureSize.y; y++) {
                Vector3 worldPos = transform.position + new Vector3(x + 0.5f, 0, y + 0.5f);

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(worldPos, .49f);
            }
        }

    }
}
