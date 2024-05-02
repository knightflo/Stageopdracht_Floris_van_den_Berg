using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;

public class CampaignManager : MonoBehaviour
{
    private Scoremanager scoremanager;

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;

    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<Scoremanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoremanager.doing)
        {
            if (scoremanager.score == 1f)
            {
                score.GetComponent<Image>().sprite = one;
                scoremanager.score = 0f;
                scoremanager.doing = false;
            }
            else if (scoremanager.score == 2f)
            {
                score.GetComponent<Image>().sprite = two;
                scoremanager.score = 0f;
                scoremanager.doing = false;
            }
            else if (scoremanager.score == 3f)
            {
                score.GetComponent<Image>().sprite = three;
                scoremanager.score = 0f;
                scoremanager.doing = false;
            }
            else
            {
                score.GetComponent<Image>().sprite = zero;
                scoremanager.score = 0f;
                scoremanager.doing = false;
            }
        }
    }

    public void logout()
    {
        SceneManager.LoadScene("Authentication");
    }
    public void startgame()
    {
        SceneManager.LoadScene("Microgame");
    }
}
