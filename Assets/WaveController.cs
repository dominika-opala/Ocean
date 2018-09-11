using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float Height; // How heigh the object will be moving up and down.
    public float Time;

	void Start () {
        iTween.MoveBy(this.gameObject, iTween.Hash("y", Height, "time", Time, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutSine)); // We will only be moving the object along the "y" axis.
                                                                                                                                                   // iTween.EaseType.easeInOutSine = a non-liear of an animated object. 
    }

    void Update () {
		
	}
}
