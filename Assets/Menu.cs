using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Go(string g)
    {
        SceneManager.LoadScene(g);
    }
    public void Credits(GameObject Object)
    {
        Object.SetActive(!Object.active);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
