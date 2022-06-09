using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Demo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(9.30f);
        SceneManager.LoadScene("Manu");
    }
}
