using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shkaf : MonoBehaviour
{
    public Manager PressE;
    public Animator ANM;
    public GameObject Drop;
    public bool Droped = false, Animate = true;


    public bool trigger;

    private GameObject triggeredObject;
    
    void Start()
    {
        PressE = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void OnTriggerStay(Collider Player)
    {
        if (Player.transform.CompareTag("Player"))
        {
            if (Droped == false)
            {
                trigger = true;
                triggeredObject = Player.gameObject;
            }
        }
    }

    private void Update()
    {
        if (trigger && !animated)
        {
            PressE.PressE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (triggeredObject.transform.CompareTag("Player"))
                {
                    if (Droped == false)
                    {
                        if (Drop != null)
                        {
                            GameObject h = GameObject.FindGameObjectWithTag("Hand");
                            Instantiate(Drop, new Vector3(h.transform.position.x - 0.282f, h.transform.position.y + 0.2f, h.transform.position.z), Quaternion.identity);
                        }

                        Droped = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            PressE.PressE.SetActive(false);
            trigger = false;
        }
    }

    private bool animated;
    void LateUpdate()
    {
        if (Animate == true)
        {
            if (Droped)
            {
                if (!animated)
                {
                    PressE.PressE.SetActive(false);
                    StartCoroutine(SmoothOpen());
                    animated = true;
                }
            }
        }
    }

    IEnumerator SmoothOpen()
    {
        float weight = 0;
        while (weight < 1)
        {
            weight += Time.deltaTime * 3;
            ANM.SetLayerWeight(1, weight);
            yield return null;
        }
    }
}
