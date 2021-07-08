using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalayDestroy : MonoBehaviour {

    public bool LoockAt = false;
    GameObject Player;
	// Use this for initialization
	void Start () {
        StartCoroutine(g());
	}
	void LateUpdate()
    {
        if (LoockAt == true)
        {
            if (Player == null)
            {
                Player = GameObject.FindGameObjectWithTag("Player");
            }
            transform.LookAt(Player.transform.position);
            
        }
    }
    IEnumerator g()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
