using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugActivate : MonoBehaviour {
    public GameObject Debug;
    public GameObject DED;


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.SetActive(!Debug.active);
            DED.SetActive(!DED.active);
        }
    }
}
