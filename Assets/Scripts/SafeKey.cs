using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;
    public GameObject Drop;
    public bool Droped;
    
    private Manager mn;

    private void Start()
    {
        mn = FindObjectOfType<Manager>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Safe"))
        {
            mn.PressLMB.SetActive(false);
        }
    }
    
    
    void OnTriggerStay(Collider Safe)
    {
        if (Safe.transform.CompareTag("Safe"))
        {
            mn.PressLMB.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Droped == false)
                {
                    AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                    GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                    GameObject f = Instantiate(Drop, transform.position, Quaternion.identity);
                    AI.target = g.transform;
                    AI.SetDestination();
                    Droped = true;
                    mn.PressLMB.SetActive(false);
                }
            }
        }
    }
}
