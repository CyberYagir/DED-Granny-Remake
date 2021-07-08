using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;
    public GameObject Drop;
    public bool Droped;
    void OnTriggerStay(Collider Safe)
    {
        if (Safe.transform.tag == "Safe")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Droped == false)
                {
                    AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                    GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                    GameObject f = Instantiate(Drop, transform.position, Quaternion.identity);
                    AI.target = g.transform;
                    AI.SetDestination();
                    Droped = true;
                }
            }
        }
    }
}
