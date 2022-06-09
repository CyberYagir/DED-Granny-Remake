using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainDoor : MonoBehaviour {
    public bool Key, Wire1, Wire2,Shild;


    void OnTriggerEnter(Collider Player)
    {
        if(Player.transform.CompareTag("Player"))
        {
            if ((Key) && (Wire1) && (Wire2)&& (Shild))
            {
                print("WIN");
                SceneManager.LoadScene("End");
            }
        }
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("House");
        }
    }
}
