using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauzemanager : MonoBehaviour
{
    public GameObject pauzescreen;
    public GameObject Continuebutton;
    public GameObject Stopbutton;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public void Pauze()
    {
        pauzescreen.SetActive(true);

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }
    public void Continue()
    {
        pauzescreen.SetActive(false);

        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }
    public void Stop()
    {
        SceneManager.LoadScene("Campaign");
    }
}
