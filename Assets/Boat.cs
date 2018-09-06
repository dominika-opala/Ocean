using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {


    private float speed;
    public float MaxSpeed;

    private void Start() {

        speed = Random.Range(-MaxSpeed, MaxSpeed);
    }

    void Update () {

        transform.Translate(speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
