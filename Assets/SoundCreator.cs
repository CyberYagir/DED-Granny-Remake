using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreator : MonoBehaviour {
    public GameObject SoundLabel;

    void Start()
    {
        R();
    }

    void R()
    {
        float f = Random.Range(10, 20);
        StartCoroutine(wait(f));
    }
    IEnumerator wait (float f)
    {
        yield return new WaitForSeconds(f);
        Instantiate(SoundLabel, transform.position, Quaternion.identity);
        R();
    }
}
