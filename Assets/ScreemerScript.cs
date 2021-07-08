using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreemerScript : MonoBehaviour {
    public Sprite[] Sprites;
    public AudioSource Audio;
    public Image SomeScreemer;

    void Start()
    {
        SomeScreemer.enabled = false;
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.transform.tag == "Player")
        {
            int g = Random.Range(0, 4);
            if (g == 2)
            {
                SomeScreemer.enabled = true;
                Audio.enabled = true;
                SomeScreemer.sprite = Sprites[Random.Range(0, Sprites.Length)];
                StartCoroutine(Wait());
            }
            print(g);

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        SomeScreemer.enabled = false;
        Audio.enabled = false;
    }
}
