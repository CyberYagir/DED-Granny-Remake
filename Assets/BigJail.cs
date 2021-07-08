using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigJail : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;
	void OnTriggerStay(Collider Jail)
    {
        if (Jail.transform.tag == "BigJail")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                Destroy(Jail.gameObject);
            }
        }
    }
}
