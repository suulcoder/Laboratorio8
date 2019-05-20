using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {

    public Light[] DiscoLight;
    public Light FlashLight;
    public Text MyText;
    public AudioSource play;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            play.Play();
            if (FlashLight.intensity == 0)
            {
                FlashLight.intensity = 10;
            }
            else if (FlashLight.intensity == 10)
            {
                FlashLight.intensity = 0;
            }
        }
        Ray myRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hitInfo;
        if (Physics.Raycast(myRay, out hitInfo))
        {
            if (hitInfo.collider.tag != "Untagged")
            {
                MyText.text = "Type Object: " + hitInfo.collider.tag;
            }
            else
            {
                MyText.text = "Type Object: None";
            }
            
        }
    }





    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "disco")
        {
            for(int i = 0; i < DiscoLight.Length; i++)
            {
                DiscoLight[i].intensity = 0.5f;
                int number = Random.Range(0, 8);
                if (number == 0)
                {
                    DiscoLight[i].color = Color.red;
                }
                else if (number == 1)
                {
                    DiscoLight[i].color = Color.blue;
                }
                else if (number == 2)
                {
                    DiscoLight[i].color = Color.green;
                }
            }
            
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "disco")
        {
            for (int i = 0; i < DiscoLight.Length; i++)
            {
                DiscoLight[i].intensity = 0;
            }
        }
    }
}
