using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInvertor : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Inverse(transform.parent.rotation);
    }
}
