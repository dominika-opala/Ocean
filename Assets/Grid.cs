using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int Column, Row;
    public int RandomNumberMax; 
    private Vector3[] vertices;
    public int ChooseYourNumber;
    private Mesh mesh;
    int n;

    private void Awake() {
        Generate();
    }

    private void Generate() {

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Pyramid Grid";

        vertices = new Vector3[(Column + 1) * (Row + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= Row; y++) {
            for (int x = 0; x <= Column; x++, i++) {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / Column, (float)y / Row);

            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[Column * Row * 6];
        for (int ti = 0, vi = 0, y = 0; y < Row; y++, vi++) {
            for (int x = 0; x < Column; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + Column + 1;
                triangles[ti + 5] = vi + Column + 2;
            }
        }
        mesh.triangles = triangles;

        for (int i = 0, y = 0; y <= Row; y++) {
            for (int x = 0; x <= Column; x++, i++) {
                n = Random.Range(0, RandomNumberMax);
                print(n);
                vertices[i] = new Vector3(x, y, n < ChooseYourNumber?1:2);
            }
        }
    }
}