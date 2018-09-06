//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Foam : MonoBehaviour
//{

//    public Transform prefab;
//    public KeyCode createKey = KeyCode.Space;
//    public KeyCode newGameKey = KeyCode.Tab;

//    List<Transform> objects; // a list works like an arry except that its size isn't fixed. By adding "Transform" we're specifing the list contents. The name of the list is "objects."


//    // Like an array, we have to ensure that we have a list object instance before we use it. We'll do that by creating the new instance in the Awake method. 

//    void Awake()
//    {
//        objects = new List<Transform>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(createKey))
//        { // The Input.GetKeyDown method returns a boolean that tells us whether a specific key was pressed in the current frame.
//            CreateObject(); // that method is invoked when the test result is "true."
//        }
//        else if (Input.GetKey(newGameKey))
//        { // that method starts a new game if Tab is pressed. 
//            BeginNewGame();
//        }
//    }

//    void BeginNewGame()
//    {
//        for (int i = 0; i < objects.Count; i++)
//        { // The length of the list is found via its Count property.
//            Destroy(objects[i].gameObject); // Destroy is a function. 
//        }


//    }

//    //void CreateObject()
//    //{ // Use the static Random.insideUnitSphere property to get a random point, scale it up to a radius of five units, and use that as the final position.
//    //Transform cube = Instantiate(prefab);
//    //shpere.localPosition = Random.insideUnitSphere * 5f;
//    //cube.localRotation = Random.rotation; // we're giving each cube a random rotation.
//    //cube.localScale = Vector3.one * Random.Range(0.1f, 1f); // we're creating random sizes of the cubes by multyplying the vector (remember we work in the 3D environment, and hence need to use a vector) by randomly chosen numbers.
//    //objects.Add(sphere);
//}


