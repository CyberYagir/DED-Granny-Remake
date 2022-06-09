using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    public Rigidbody Rb;
    public Vector3 StartSize;

    public static PickUp selectedItem;
    
    private bool picked;
    private bool triggered;
    [SerializeField] private string itemName;

    private float pickupCooldown;
    void Start()
    {
        StartSize = transform.localScale;
    }
    void LateUpdate()
    {
        pickupCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Drop();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (triggered && pickupCooldown <= 0)
                {
                    if (selectedItem && selectedItem.transform != transform)
                    {
                        selectedItem.Drop();
                    }
                    
                    picked = true;
                    Rb.isKinematic = true;
                    transform.parent = GameObject.FindGameObjectWithTag("Hand").transform;
                    transform.position = transform.parent.position;
                    transform.rotation = new Quaternion();
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<MeshCollider>().enabled = false;
                    transform.localScale = new Vector3(StartSize.x, StartSize.y / 2, StartSize.z);

                    GameObject.FindGameObjectWithTag("Hint").GetComponent<Text>().text = itemName;

                    selectedItem = this;
                }
            }
        }
    }

    public void Drop()
    {
        if (picked)
        {
            transform.transform.parent = null;
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetComponent<Collider>().enabled = true;
            transform.GetComponent<MeshCollider>().enabled = true;
            transform.localScale = StartSize;
            picked = false;
            GameObject.FindGameObjectWithTag("Hint").GetComponent<Text>().text = "";
            selectedItem = null;
            pickupCooldown = 0.2f;
        }
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.transform.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            triggered = false;
        }
    }
}
