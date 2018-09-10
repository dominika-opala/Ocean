using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    Light testLight; // Declares and names a new component. 
    public float minWaitTime;
    public float maxWaitTime;

    void Start() {
        testLight = GetComponent<Light>(); // Adds the new component to the Function/Game.
        StartCoroutine(Flashing()); // Calls the coroutine function. 
    }

    IEnumerator Flashing() {
        while (true) { // As long as that is true. 
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime)); // Random. Range allows us to choose the time slot between when the light in on and off.
            testLight.enabled = !testLight.enabled; // Turn it on and off.  
        }
    }
}
