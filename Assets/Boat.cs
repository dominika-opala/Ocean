using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    private Transform seaPlane; // Stores the child of the "Sea" game object that we will be floating. 
    private Cloth planeCloth; // Takes all the vertices of the "Sea" grid.
    private int closestVertexIndex = -1; // Holds the index of the closest vertex to the boat.

    private float speed;
    public float MaxSpeed;

    private void Start() {
        seaPlane = GameObject.Find("WaterPlane").transform;
        planeCloth = seaPlane.GetComponent<Cloth>();

        speed = Random.Range(-MaxSpeed, MaxSpeed);
    }

    void Update () {
        GetClosestVertex();
        transform.Translate(speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    void GetClosestVertex(){ // Compares the closestVertexIndex with the index of each vertex on the plane, and gets the one which is closest to the boat.  
        for (int i = 0; i < planeCloth.vertices.Length; i++){
            if(closestVertexIndex == -1){
                closestVertexIndex = i;
            }
            float distance = Vector3.Distance(planeCloth.vertices[i], transform.position); // Distance between closestVertexIndex and the one we're getting/looking for.
            float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);

            if (distance < closestDistance){
                closestVertexIndex = i;
            }
        }

        transform.localPosition = new Vector3(transform.localPosition.x, planeCloth.vertices[closestVertexIndex].y / 10f, transform.localPosition.z);
    }
}
