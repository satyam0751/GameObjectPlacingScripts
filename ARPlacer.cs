using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;


public class ARPlacer : MonoBehaviour
{
    ARSessionOrigin arSessionOrigin;

    List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();



    //this is the prefab to be instantiated
    public GameObject ARObjectPrefab;

    //this is the gameobject that is instantiated after successful raycast intersction with a plane
    private GameObject spawnedARObject; 




    private void Awake()
    {
        arSessionOrigin = GetComponent<ARSessionOrigin>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            if (arSessionOrigin.Raycast(touch.position, raycast_hits, TrackableType.PlaneWithinPolygon))
            {
                //getting the pose of the hit
                Pose pose = raycast_hits[0].pose;

                if (spawnedARObject == null)
                {
                    spawnedARObject = Instantiate(ARObjectPrefab, pose.position, Quaternion.Euler(0, 0, 0));
                   
                }
                else
                {
                    spawnedARObject.transform.position = pose.position;
                    
                }

            }



        }

    }
}
