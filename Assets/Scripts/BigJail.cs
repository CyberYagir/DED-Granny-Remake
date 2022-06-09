using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigJail : MonoBehaviour {

    public HorrorAI AI;
    public GameObject SoundPoint;
    
    private Manager mn;

    private void Start()
    {
        mn = FindObjectOfType<Manager>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("BigJail"))
        {
            mn.PressLMB.SetActive(false);
        }
    }
    
	void OnTriggerStay(Collider Jail)
    {
        if (Jail.transform.CompareTag("BigJail"))
        {
            mn.PressLMB.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
                GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
                AI.target = g.transform;
                AI.SetDestination();
                Destroy(Jail.gameObject);
                mn.PressLMB.SetActive(false);
            }
        }
    }
}
