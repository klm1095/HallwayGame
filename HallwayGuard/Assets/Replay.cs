using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Replay : MonoBehaviour
{
    public Text restartText;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}
