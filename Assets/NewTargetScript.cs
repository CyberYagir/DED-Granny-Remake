using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTargetScript : MonoBehaviour {
    public GameObject[] Point;
    public bool Prefab;
    public float Dtime = 10f;
    void Start()
    {
        if (Prefab == true) {
            StartCoroutine(Wait());
        }
    }
    void OnTriggerEnter(Collider DED)
    {
        if (DED.transform.tag == "AI")
        {
            print("Triggered");
            Point = GameObject.FindGameObjectsWithTag("PlayerPoint");
            if (Point.Length == 0)
            {
                Point = GameObject.FindGameObjectsWithTag("Point");
            }
            bool End = false;
            GameObject NextPoint = Point[Random.Range(0, Point.Length)];
            while (End == false)
            {
                if (NextPoint.transform != transform)
                {
                    End = true;
                }
                else
                {
                    NextPoint = Point[Random.Range(0, Point.Length)];
                }
            }
            DED.GetComponent<HorrorAI>().target = NextPoint.transform;
            DED.GetComponent<HorrorAI>().SetDestination();
            if (Prefab == true)
            {
                Destroy(gameObject);
            }

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Dtime);
        Destroy(gameObject);
    }
}
