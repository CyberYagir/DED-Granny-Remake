using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffEffects : MonoBehaviour {
    public ParticleSystem[] AllParticles;
    public MonoBehaviour[] EffectsScripts; 
    void Start()
    {
        AllParticles = FindObjectsOfType<ParticleSystem>();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < EffectsScripts.Length; i++) {
                EffectsScripts[i].enabled = !EffectsScripts[i].enabled;
            }
            for (int i = 0; i < AllParticles.Length; i++)
            {
                AllParticles[i].gameObject.SetActive(!AllParticles[i].gameObject.active);
            }
        }
	}
}
