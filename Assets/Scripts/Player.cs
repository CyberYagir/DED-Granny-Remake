using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject Cam;
    public float speed;
    public float sense;

    private bool active;
    private Rigidbody rb;
    
    public float xAngle;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active) return;
        rb.AddRelativeForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed,  ForceMode.VelocityChange);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.distance > 2)
            {
                rb.AddForce(Vector3.down * 1000, ForceMode.Force);
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            active = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        

        if (!active) return;
        float yrot = Input.GetAxisRaw("Mouse X");
        Vector3 rot = new Vector3(0, yrot, 0f) * sense * Time.deltaTime;
        transform.rotation = (transform.rotation * Quaternion.Euler(rot));
        float xrot = Input.GetAxisRaw("Mouse Y") *sense * Time.deltaTime;
        if (xAngle + xrot > 90 || xAngle + xrot < -90)
        {
            xrot = 0;
        }
        else
        {
            xAngle += xrot;
        }
        Vector3 camrot = new Vector3(-xrot, 0, 0f);
        Cam.transform.rotation = (Cam.transform.rotation * Quaternion.Euler(camrot));
    }
}
