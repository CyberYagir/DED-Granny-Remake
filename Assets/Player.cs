using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject Cam;
    public float speed;
    public float sense;
    public bool Hide;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.visible = false;
        }
            }
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float yrot = Input.GetAxisRaw("Mouse X");
        Vector3 rot = new Vector3(0, yrot, 0f) * 1;
        transform.rotation = (transform.rotation * Quaternion.Euler(rot));
        float xrot = Input.GetAxisRaw("Mouse Y");
        Vector3 camrot = new Vector3(-xrot, 0, 0f) * 1;
        Cam.transform.rotation = (Cam.transform.rotation * Quaternion.Euler(camrot));
    }
}
