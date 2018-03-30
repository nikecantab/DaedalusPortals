using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalActivation : MonoBehaviour {

    public bool isDown;
    public GameObject button;
    AudioSource audioSource;

    bool moving;
    

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        if (isDown) gameObject.transform.position -= new Vector3(0,10,0);
        moving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moving)
        {
            gameObject.transform.position += new Vector3(0, 0.2f, 0);
            button.transform.position -= new Vector3(0, 0.215f, 0);
            if (gameObject.transform.position == new Vector3(0,0,0))
            {
                moving = false;
                isDown = false;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PuzzleCube")
        {
            if (!other.GetComponent<PickUp>().isHolding)
            {
                if (isDown)
                {
                    if (moving == false)
                        audioSource.PlayDelayed(0.5f);//audioSource.PlayOneShot(activation, 1);
                    moving = true;
                }
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (moving == false)
        {
            if (other.tag == "PuzzleCube")
            {
                if (!other.GetComponent<PickUp>().isHolding)
                {
                    if (moving == false)
                        audioSource.PlayDelayed(0.5f);//audioSource.PlayOneShot(activation, 1);
                    moving = true;
                }
            }
        }

    }
}
