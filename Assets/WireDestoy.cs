using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireDestoy : MonoBehaviour {

    public Material EmmiRed;
    public HorrorAI AI;
    public GameObject SoundPoint;
    void OnTriggerStay(Collider Safe)
    {
        if (Safe.transform.tag == "Wire1")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                MainDoor md = GameObject.FindGameObjectWithTag("Finish").GetComponent<MainDoor>();
                GameObject[] f = GameObject.FindGameObjectsWithTag("Wire1Light");
                for (int i = 0; i < f.Length; i++)
                {
                    f[i].GetComponent<Renderer>().material = EmmiRed;
                }
                md.Wire1 = true;
            }
        }
        if (Safe.transform.tag == "Wire2")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                MainDoor md = GameObject.FindGameObjectWithTag("Finish").GetComponent<MainDoor>();
                GameObject[] f = GameObject.FindGameObjectsWithTag("Wire2Light");
                for (int i = 0; i < f.Length; i++)
                {
                    f[i].GetComponent<Renderer>().material = EmmiRed;
                }
                md.Wire2 = true;
            }
        }
    }
}
