using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour
{
    private static Scoremanager scoremanager;

    public float score = 0;

    public bool doing;

    private void Awake()
    {
        

        // Ensure there's only one instance of the singleton
        if (scoremanager != null && scoremanager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // If this is the first instance, set it as the singleton instance
            scoremanager = this;
            DontDestroyOnLoad(gameObject); // Keep the singleton object between scene changes
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Score")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Microgame")
        {
            doing = true;
        }
    }
}
