using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISee : MonoBehaviour
{
    public HorrorAI AI;

    void LateUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f), transform.forward, out hit, 10000))
        {
            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Instantiate(AI.PlayerPoint, hit.transform.position, Quaternion.identity);
                    AI.target = hit.transform;
                    AI.GetComponent<HorrorAI>().SetDestination();
                }
            }
        }
    }
}