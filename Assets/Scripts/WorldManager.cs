using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {
    public List<GameObject> _renderers;

    bool playerIsOverlapping = false;

    // Use this for initialization
    void Start ()
    {
        _renderers = new List<GameObject>();
        GetAllRendersRecursive(gameObject);

        DisableRenders();


	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            EnableRenders();
            Debug.Log("entered " + gameObject.name);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            DisableRenders();
            Debug.Log("exited " + gameObject.name);
        }
    }

    void DisableRenders()
    {
        foreach(var renderer in _renderers)
        {
            renderer.GetComponent<Renderer>().enabled = false;
        }
    }

    void EnableRenders()
    {
        foreach (var renderer in _renderers)
        {
            renderer.GetComponent<MeshRenderer>().enabled = true;
        }

    }

    private void GetAllRendersRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            if (child.gameObject.layer == 9)
                _renderers.Add(child.gameObject);
            GetAllRendersRecursive(child.gameObject);
        }
    }

}
