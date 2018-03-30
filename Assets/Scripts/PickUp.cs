using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    float throwForce = 600;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public bool isHolding = false;
    float distance;
    bool firstFrame;
    Transform realParent;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        realParent = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, guide.transform.position);

        if (isHolding)
        {
            if (firstFrame)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().detectCollisions = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                firstFrame = false;


            }
            else
            {
                item.transform.position =new Vector3 (guide.transform.position.x, Mathf.Max( 1.5f, guide.transform.position.y), guide.transform.position.z);
                item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;
            }
        }
        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = realParent;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isHolding)
            {
                if (distance <= 1.5f)
                {
                    isHolding = true;
                    firstFrame = true;
                }
            }
            else
                isHolding = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            audioSource.Play();
        }

        isHolding = false;
    }
}
