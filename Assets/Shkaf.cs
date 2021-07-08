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


    void Start()
    {
        PressE = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void OnTriggerStay(Collider Player)
    {
        if (Player.transform.tag == "Player")
        {
            if (Droped == false)
            {
                PressE.PressE.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Player.transform.tag == "Player")
            {
                if (Droped == false)
                {
                    if (Drop != null)
                    {
                        GameObject h = GameObject.FindGameObjectWithTag("Hand");
                        Instantiate(Drop, new Vector3(h.transform.position.x- 0.282f, h.transform.position.y+0.2f, h.transform.position.z), Quaternion.identity);
                    }
                    Droped = true;
                }
            }
        }
    }
    void OnTriggerExit(Collider Player)
    {
        PressE.PressE.SetActive(false);
    }
    void LateUpdate()
    {
        if (Animate == true)
        {
            if (Droped == false)
            {
                ANM.Play("ShafClose");
            }
            if (Droped == true)
            {
                ANM.Play("ShafOpen");
            }
        }
    }
}
