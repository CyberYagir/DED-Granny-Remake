using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Rigidbody Rb;
    public AudioSource Sound;
    public bool On = false;
    void OnTriggerEnter()
    {
        if (Rb.isKinematic == false)
        {
            if (On == false)
            {
                Sound = GameObject.FindGameObjectWithTag("FallAudio").GetComponent<AudioSource>();
                Sound.enabled = false;
                Sound.enabled = true;
                On = true;
            }
        }
    }
    void OnTriggerExit()
    {
        On = false;
    }
}
