using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;

    private Manager mn;

    private void Start()
    {
        mn = FindObjectOfType<Manager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Finish"))
        {
            mn.PressLMB.SetActive(false);
        }
    }

    void OnTriggerStay(Collider Finish)
    {
        if (Finish.transform.CompareTag("Finish"))
        {
            mn.PressLMB.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                GameObject z = GameObject.FindGameObjectWithTag("Zamok");
                Destroy(z);
                mn.PressLMB.SetActive(false);
                Finish.GetComponent<MainDoor>().Key = true;
            }
        }
    }
}
