using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HorrorAI : MonoBehaviour {
    [SerializeField]
    public Animator Anim;
    public GameObject PlayerPoint,Cam;
    public Transform target,StartTarget;
    public NavMeshAgent Bot;
    // Use this for initialization
    void Start()
    {
        SetDestination();
    }

    // Update is called once per fr

    void LateUpdate()
    {
        if (target == null)
        {
            if (Bot.isOnNavMesh == true)
            {
                target = StartTarget;
                Vector3 vector = target.position;
                Bot.SetDestination(vector);
            }
        }
    }
    public void SetDestination()
    {
        StartCoroutine(CoolDown());
    }


    void OnTriggerEnter(Collider Player)    
    {
        if (Player.transform.tag == "Player")
        {
            Player.GetComponent<Player>().enabled = false;
            transform.LookAt(Player.transform.position);
            Bot.enabled = false;
            transform.GetComponent<HorrorAI>().enabled = false;
            Player.transform.LookAt(transform.position);
            Anim.Play("Screem");
            Cam.SetActive(true);
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        if (target != null)
        {
            if (Bot.isOnNavMesh == true)
            {
                Vector3 vector = target.position;
                Bot.SetDestination(vector);
            }
        }
    }
}
