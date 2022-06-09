using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drell : MonoBehaviour {
    public float DoorSheadHp = 100;
    public GameObject Particles;
    public HorrorAI AI;
    public GameObject SoundPoint;
    
     
    private Manager mn;

    private void Start()
    {
        mn = FindObjectOfType<Manager>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Shild"))
        {
            mn.PressLMB.SetActive(false);
            Particles.SetActive(false);
        }
    }
    
    // Use this for initialization
    void FixedUpdate()
    {
        if (Particles.active == true)
        {
            DoorSheadHp -= 0.1f;
        }
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            Particles.SetActive(false);
        }
    }

    void OnTriggerStay(Collider Shild)
    {
        if (Shild.transform.CompareTag("Shild"))
        {
            mn.PressLMB.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Particles.SetActive(true);
                StartCoroutine(Spawn());
                if (DoorSheadHp <= 0)
                {
                    Destroy(Shild.gameObject);
                    GameObject.FindGameObjectWithTag("Finish").GetComponent<MainDoor>().Shild = true;
                    mn.PressLMB.SetActive(false);
                }
            }
        }

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        AI = GameObject.FindGameObjectWithTag("AI").GetComponent<HorrorAI>();
        GameObject g = Instantiate(SoundPoint, transform.position, Quaternion.identity);
        AI.target = g.transform;
        AI.SetDestination();
        StopAllCoroutines();
    }
}
