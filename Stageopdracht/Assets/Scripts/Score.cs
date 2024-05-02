using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Scoremanager scoremanager;
    private ServerManager serverManager; // Add this variable

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;


    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<Scoremanager>();
        serverManager = FindObjectOfType<ServerManager>(); // Initialize the serverManager
    }

    // Update is called once per frame
    void Update()
    {
        if (scoremanager.doing)
        {
            if (scoremanager.score == 1f)
            {
                GetComponent<Image>().sprite = one;

            }
            else if (scoremanager.score == 2f)
            {
                GetComponent<Image>().sprite = two;

            }
            else if (scoremanager.score == 3f)
            {
                GetComponent<Image>().sprite = three;

            }
            else
            {
                GetComponent<Image>().sprite = zero;

            }
        }


            //SendScoreToServer(scoremanager.score);

    }


    public void back()
    {
        SceneManager.LoadScene("Campaign");
    }


    /*
    // Method to send the score to the server
    void SendScoreToServer(float score)
    {

        string IDToken = "1234"; 
        string GameName = "quiz"; 

        // Call the PostScore method from the ServerManager
        serverManager.PostScore(IDToken, (int)score, GameName, HandlePostScoreResponse);
    }

    // Callback function to handle the response from the server
    void HandlePostScoreResponse(ServerManager.NetworkResponse response)
    {
        if (response.isSuccess)
        {
            Debug.Log("Score posted successfully!");
        }
        else
        {
            Debug.LogError("Failed to post score: " + response.message);
        }
    }*/

}
