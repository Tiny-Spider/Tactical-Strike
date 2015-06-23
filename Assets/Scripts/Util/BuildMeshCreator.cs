using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BuildMeshCreator : MonoBehaviour {
    [Tooltip("The Unity unit size (1 = default)")]
    public Vector2 TileWorldSize = new Vector2(1, 1);

    [Tooltip("The amount of tiles on the Tile Sheet")]
    public Vector2 TileAmount = new Vector2(10, 10);

    [Tooltip("The default tile, normally 0,0")]
    public Vector2 DefaultTile;

    private int _gridWidth;
    private int _gridHeight;

    //private float _gridHalfWidth;
    //private float _gridHalfHeight;

    private Vector2 offset;

    [HideInInspector]
    public MeshFilter meshFilter;

    void Awake() {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void UpdateGrid(Vector2 gridIndex, Vector2 tileIndex) {
        Mesh mesh = meshFilter.mesh;
        Vector2[] uvs = mesh.uv;

        float tileSizeX = 1.0f / TileAmount.x;
        float tileSizeY = 1.0f / TileAmount.y;

        uvs[(int)(_gridHeight * gridIndex.x + gridIndex.y) * 4 + 0] = new Vector2(tileIndex.x * tileSizeX, tileIndex.y * tileSizeY);
        uvs[(int)(_gridHeight * gridIndex.x + gridIndex.y) * 4 + 1] = new Vector2((tileIndex.x + 1) * tileSizeX, tileIndex.y * tileSizeY);
        uvs[(int)(_gridHeight * gridIndex.x + gridIndex.y) * 4 + 2] = new Vector2((tileIndex.x + 1) * tileSizeX, (tileIndex.y + 1) * tileSizeY);
        uvs[(int)(_gridHeight * gridIndex.x + gridIndex.y) * 4 + 3] = new Vector2(tileIndex.x * tileSizeX, (tileIndex.y + 1) * tileSizeY);

        mesh.uv = uvs;
    }

    public void CreatePlane(int gridWidth, int gridHeight) {
        _gridWidth = gridWidth;
        _gridHeight = gridHeight;

        //_gridHalfWidth = _gridWidth / 2.0F;
        //_gridHalfHeight = _gridHeight / 2.0F;

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        float tileSizeX = 1.0f / TileAmount.x;
        float tileSizeY = 1.0f / TileAmount.y;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        int index = 0;

        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {

                AddVertices((int)TileWorldSize.y, (int)TileWorldSize.x, y, x, vertices);

                index = AddTriangles(index, triangles);

                AddNormals(normals);
                AddUvs((int)DefaultTile.y, (int)DefaultTile.x, tileSizeY, tileSizeX, uvs);
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.normals = normals.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
    }

    private void AddVertices(int tileHeight, int tileWidth, int y, int x, ICollection<Vector3> vertices) {
        //x = x - (int)_gridHalfWidth;
        //y = y - (int)_gridHalfHeight;

        vertices.Add(new Vector3((x * tileWidth), 0, (y * tileHeight)));
        vertices.Add(new Vector3((x * tileWidth) + tileWidth, 0, (y * tileHeight)));
        vertices.Add(new Vector3((x * tileWidth) + tileWidth, 0, (y * tileHeight) + tileHeight));
        vertices.Add(new Vector3((x * tileWidth), 0, (y * tileHeight) + tileHeight));
    }

    private int AddTriangles(int index, ICollection<int> triangles) {
        triangles.Add(index + 2);
        triangles.Add(index + 1);
        triangles.Add(index);
        triangles.Add(index);
        triangles.Add(index + 3);
        triangles.Add(index + 2);

        index += 4;

        return index;
    }

    private void AddNormals(ICollection<Vector3> normals) {
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
    }

    private void AddUvs(int tileRow, int tileColumn, float tileSizeY, float tileSizeX, ICollection<Vector2> uvs) {
        uvs.Add(new Vector2(tileColumn * tileSizeX, tileRow * tileSizeY));
        uvs.Add(new Vector2((tileColumn + 1) * tileSizeX, tileRow * tileSizeY));
        uvs.Add(new Vector2((tileColumn + 1) * tileSizeX, (tileRow + 1) * tileSizeY));
        uvs.Add(new Vector2(tileColumn * tileSizeX, (tileRow + 1) * tileSizeY));
    }
}
