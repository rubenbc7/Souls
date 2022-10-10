using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] float timeValue;
    [SerializeField] Text timerText;
    [SerializeField] Text winnerText;
     [SerializeField] GameObject drawText;

    float timeEnd = 6.0f;
    [SerializeField] string nulltext;

    Score score;
    ScoreP2 scoreP2;
    
    void Awake()
    {
        score = FindObjectOfType<Score>();
        scoreP2 = FindObjectOfType<ScoreP2>();
        nulltext = "";
    }
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            
            if (score.score > scoreP2.score)
            {  
                if(PlayerPrefs.GetString("name1") == nulltext)
                {
                    nulltext = "P1";
                    
                }
                winnerText.text = PlayerPrefs.GetString("name1") + nulltext+ " WINS";
                Destroy (GameObject.FindWithTag("soul"));
            }
            if (scoreP2.score > score.score)
            {
                if(PlayerPrefs.GetString("name2") == nulltext)
                {
                    nulltext = "P2";
                    
                }
                winnerText.text = PlayerPrefs.GetString("name2") + nulltext + " WINS";
                Destroy (GameObject.FindWithTag("soul"));
            }
            if (score.score == scoreP2.score)
            {
                drawText.SetActive(true);
                Destroy (GameObject.FindWithTag("soul"));
            }
            //SceneManager.LoadScene("Menu");

            if (timeEnd > 0)
            {
                timeEnd -= Time.deltaTime;
            }
            else
            {
                timeEnd = 0;
                SceneManager.LoadScene("Menu");
            }


        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
