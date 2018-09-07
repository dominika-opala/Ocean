using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int Column, Row;
    private Mesh mesh;
    private Vector3[] wavePoints;
    private float odd;
    private Vector3 wavePoint;

    [Range(0f, 1f)] // Attribute used to make a float or int variable in a script be restricted to a specific range.
    // When this attribute is used, the float or int will be shown as a slider in the Inspector instead of the default number field.
    public float ChooseYourNumber;

    [Range(0f, 1f)]
    public float Frequency;
    [Range(0f, 1f)]
    public float Gradient;
    [Range(-50f, 50f)]
    public float Scale = 1f;
    [Range(-1f, 1f)]
    public float Xoffset = 0.5f;
    [Range(-1f, 1f)]
    public float Yoffset = 0.5f;


    private void Start() {

        wavePoint.y = 0f;
        wavePoint.z = 0f;
        wavePoint.x = 0f;
        wavePoints = new Vector3[(Column + 1) * (Row + 1)]; // In that function we can manipulate the position and form of our grid.

        Generate();
    }

    private void Generate() {

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Ocean Grid";

        wavePoints = new Vector3[(Column + 1) * (Row + 1)];
        Vector2[] uv = new Vector2[wavePoints.Length];  // To make the texture/material to fit our entire grid, simply divide the position of the vertex by the grid dimensions.

        int i = 0;
        for (int y = 0; y <= Row; y++) {
            for (float x = 0; x <= Column; x++){
                 wavePoints[i] = new Vector3(x, y, 0f);
                uv[i] = new Vector2((float)x / Column, (float)y / Row);

                i++;
            }
        }

        mesh.vertices = wavePoints; // mesh.vertices is a fixed property of the Mesh class. 
        mesh.uv = uv;

        int[] triangles = new int[Column * Row * 6]; // creating traingles so that our grid would be visible (and filled).

        for (int ti = 0, vi = 0, y = 0; y < Row; y++, vi++) {
            for (int x = 0; x < Column; x++, ti += 6, vi++) {

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

    private void Update() {

        Vector3[] wavePoints = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < wavePoints.Length)
        {
            wavePoints[i] += normals[i] * Mathf.Sin(Time.time);
            i++;
        }
        mesh.vertices = wavePoints;

        //int i = 0;
        //for (int y = 0; y <= Row; y++){
        //    for (int x = 0; x <= Column; x++){
        //        wavePoints[i] = wavePoint;
        //        wavePoint.y = Mathf.Sin(Mathf.PI * (wavePoint.x + Time.time));
        //        i++;
        //    }
        //}
        //mesh.vertices = wavePoints;


    }


    public float AddXY(float x, float y) { // That's a function that, if invoked, sets the graph in a linear function.
        return x + y;
    }

    public float Sine(float x, float y) { // This function creates sine waves in our graph. 
        return Mathf.Sin(x + y) * Frequency;
    }

    public float RandomOceanWaves(float x, float y) { // This function creates pyramids in our graph (which we can manipulate thanks to [Range(0f,1f)].
        float z;
        if (Random.value > ChooseYourNumber) {
            z = 0;
        }
        else {
            z = -1;
        }

        return z;
    }

    public float Waves(float x, float y) {
        x = Mathf.Sin((x / Column) * Frequency);  // Normalize x to be 0 <= x <= 1. 
        y = Mathf.Sin((y / Row) * Frequency);
        return x + y;
    }

    public float scale(float v, float offset) { // scale takes a value in the range 0...1 and remaps it to be in the range -Scale...+Scale (for example -10 to +10). However it also allows an offset to be applied first so the value is shifted by a constant amount before being scaled.
        return (v - 0.5f - offset) * Scale;
    }

    public float normalise(float v, float maxVal) { // Normalize takes a value that can be in the range 0...maxVal and remaps it to be in the range 0...1
        return v / maxVal;
    }

    public float RippleEffect(float x, float y) {

        x = scale(normalise(x, Column), Xoffset);
        y = scale(normalise(y, Row), Yoffset);

        x = Mathf.Sqrt((x * x + y * y));
        return Mathf.Sin(x * Frequency);
    }

}


