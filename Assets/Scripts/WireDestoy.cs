using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireDestoy : MonoBehaviour {

    public Material EmmiRed;
    public HorrorAI AI;
    public GameObject SoundPoint;
    
    private Manager mn;

    private void Start()
    {
        mn = FindObjectOfType<Manager>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Wire1") || other.transform.CompareTag("Wire2"))
        {
            mn.PressLMB.SetActive(false);
        }
    }
    
    void OnTriggerStay(Collider other)
    {

        if (other.transform.CompareTag("Wire1") || other.transform.CompareTag("Wire2"))
        {
            mn.PressLMB.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                MainDoor md = GameObject.FindGameObjectWithTag("Finish").GetComponent<MainDoor>();

                GameObject[] f = Array.Empty<GameObject>();
                
                if (other.transform.CompareTag("Wire1"))
                {
                    other.transform.tag = "Untagged";
                    f = GameObject.FindGameObjectsWithTag("Wire1Light");
                    md.Wire1 = true;
                    mn.PressLMB.SetActive(false);
                }

                if (other.transform.CompareTag("Wire2"))
                {
                    other.transform.tag = "Untagged";
                    f = GameObject.FindGameObjectsWithTag("Wire2Light");
                    md.Wire2 = true;
                    mn.PressLMB.SetActive(false);
                }
                
                for (int i = 0; i < f.Length; i++)
                {
                    f[i].GetComponent<Renderer>().material = EmmiRed;
                }
            }
        }
    }
}
