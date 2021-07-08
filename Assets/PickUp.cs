using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Rigidbody Rb;
    public Vector3 StartSize;
    void Start()
    {
        StartSize = transform.localScale;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject[] All = GameObject.FindGameObjectsWithTag("Item");
            for (int i = 0; i < All.Length; i++)
            {
                All[i].transform.parent = null;
                All[i].GetComponent<Rigidbody>().isKinematic = false;
                All[i].GetComponent<Collider>().enabled = true;
                All[i].GetComponent<MeshCollider>().enabled = true;
                All[i].transform.localScale = All[i].GetComponent<PickUp>().StartSize;
            }
        }
    }
    void OnTriggerStay(Collider Player)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Player.transform.tag == "Player")
            {
                GameObject[] All = GameObject.FindGameObjectsWithTag("Item");
                for (int i = 0; i < All.Length; i++)
                {
                    All[i].transform.parent = null;
                    All[i].GetComponent<Rigidbody>().isKinematic = false;
                    All[i].GetComponent<Collider>().enabled = true;
                    All[i].GetComponent<MeshCollider>().enabled = true;
                    All[i].transform.localScale = All[i].GetComponent<PickUp>().StartSize;
                }
                Rb.isKinematic = true;
                transform.parent = GameObject.FindGameObjectWithTag("Hand").transform;
                transform.position = transform.parent.position;
                transform.rotation = new Quaternion();
                transform.GetComponent<Collider>().enabled = false;
                transform.GetComponent<MeshCollider>().enabled = false;
                transform.localScale = new Vector3(StartSize.x, StartSize.y / 2, StartSize.z);
            }
        }
    }
}
