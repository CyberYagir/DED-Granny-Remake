using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HorrorAI : MonoBehaviour {
    [SerializeField]
    public Animator Anim;
    public GameObject PlayerPoint,Cam;
    public Transform target;
    public NavMeshAgent Bot;
    public List<Transform> points = new List<Transform>();
    public GameObject Player;

    public AudioSource steps;
    // Use this for initialization
    void Start()
    {
        SetDestination();
    }


    void LateUpdate()
    {
        if (target == null)
        {
            target = points[Random.Range(0, points.Count)];
            Bot.SetDestination(target.position);
        }
        else
        {
            if (Vector3.Distance(new Vector3(transform.position.x, transform.position.z), new Vector3(target.position.x, target.position.z)) < 0.1)
            {
                target = points[Random.Range(0, points.Count)];
            }
        }

        steps.volume = Bot.velocity.magnitude/Bot.speed;
        if (Physics.Raycast(transform.position, Player.transform.position - transform.position, out RaycastHit hit))
        {
            if (hit.collider.gameObject == Player.gameObject)
            {
                Bot.SetDestination(Player.transform.position);
            }
            else
            {
                Bot.SetDestination(target.transform.position);
            }
        }
    }
    public void SetDestination()
    {
        StartCoroutine(CoolDown());
    }


    void OnTriggerEnter(Collider Player)    
    {
        if (Player.transform.CompareTag("Player"))
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
