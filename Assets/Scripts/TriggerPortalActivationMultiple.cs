using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalActivationMultiple : MonoBehaviour {

    public bool isDown;
    public GameObject[] buttons;
    public GameObject[] triggers;
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

            foreach(GameObject button in buttons) 
                button.transform.position -= new Vector3(0, 0.215f, 0);
            if (gameObject.transform.position.y>= 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.parent.position.y, gameObject.transform.position.z);
                moving = false;
                isDown = false;
            }
        }
	}
    

    public void OnButtonTriggered ()
    {
        int tally = 0; 
        foreach (GameObject trigger in triggers)
        {
            if (trigger.GetComponent<SendTriggerEvent>().triggered)
                tally++;
        }

        if (tally == triggers.Length)
        {
            if (moving == false)
            {
                audioSource.PlayDelayed(0.5f);
                moving = true;
            }
        }

        print("triggered" + tally);

    }
}
