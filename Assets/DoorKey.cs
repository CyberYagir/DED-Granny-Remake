using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;

    void OnTriggerStay(Collider Finish)
    {
        if (Finish.transform.tag == "Finish")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                GameObject z = GameObject.FindGameObjectWithTag("Zamok");
                Destroy(z);
                Finish.GetComponent<MainDoor>().Key = true;
            }
        }
    }
}
