using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int Column, Row;
    public int RandomNumberMax;
    private Vector3[] vertices;
    public int ChooseYourNumber;
    private Mesh mesh;
    int n;


    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Ocean Grid";

        vertices = new Vector3[(Column + 1) * (Row + 1)];

        Vector2[] uv = new Vector2[vertices.Length];
        float r = 10;
        int i = 0;
     

        for (int y = 0; y <= Row; y++){

            for (float angle = 0; angle <= 2 * Mathf.PI; angle += (2f * Mathf.PI)/Column){ //angle <= 2 * Mathf.PI = 360, angle += (2f * Mathf.PI)/Column) -> it moves in 360 depending on the number of Columns. 

                // r = y; // Increase the radius as the y increases giving us a cone shape with the point at the bottom

                r = Mathf.Exp(Mathf.Cos(y/2f));
                float x = Mathf.Cos(angle) * r;
                float z = Mathf.Sin(angle) * r;

                vertices[i] = new Vector3(x, y, z);
                uv[i] = new Vector2((float)x / Column, (float)y / Row);

                i++;

           }
        }


        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[Column * Row * 6];
        for (int ti = 0, vi = 0, y = 0; y < Row; y++, vi++)
        {
            for (int x = 0; x < Column; x++, ti += 6, vi++)
            {

                var pointA = vi;
                var pointB = vi + 1;
                var pointC = vi + Column + 1;
                var pointD = vi + Column + 2;

                triangles[ti] = pointA;
                triangles[ti + 1] = pointC;
                triangles[ti + 2] = pointB; 

                triangles[ti + 3] = pointB;
                triangles[ti + 4] = pointC;
                triangles[ti + 5] = pointD; 


            }
        }
        mesh.triangles = triangles;

    }

    public float Cylinder(float x, float z) {
        return Mathf.Sqrt(x * x + z * z);
    }
}