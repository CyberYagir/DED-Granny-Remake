using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drell : MonoBehaviour {
    public float DoorSheadHp = 100;
    public GameObject Particles;
    public HorrorAI AI;
    public GameObject SoundPoint;
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Shild.transform.tag == "Shild")
            {
                Particles.SetActive(true);
                StartCoroutine(Spawn());
                if (DoorSheadHp <= 0)
                {
                    Destroy(Shild.gameObject);
                    GameObject.FindGameObjectWithTag("Finish").GetComponent<MainDoor>().Shild = true;
                }
            }
        }
        
    }
    void OnTriggerExit()
    {
        Particles.SetActive(false);
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
