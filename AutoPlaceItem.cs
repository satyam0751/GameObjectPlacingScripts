using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class AutoPlaceItem : MonoBehaviour {

    public GameObject GameObjectToPlace;

    ARSessionOrigin m_SessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void Update()
    {
           

        if (m_SessionOrigin.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0)), s_Hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = s_Hits[0].pose;
            GameObjectToPlace.transform.position = hitPose.position;
            if (!GameObjectToPlace.activeSelf)
            {
                GameObjectToPlace.SetActive(true);
            }
        }

    }
}
