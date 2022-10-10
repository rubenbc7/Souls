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

    float timeEnd = 6.0f;

    Score score;
    ScoreP2 scoreP2;
    
    void Awake()
    {
        score = FindObjectOfType<Score>();
        scoreP2 = FindObjectOfType<ScoreP2>();
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
                winnerText.text = PlayerPrefs.GetString("name1") + " Wins";
                Destroy (GameObject.FindWithTag("soul"));
            }
            if (scoreP2.score > score.score)
            {
                winnerText.text = PlayerPrefs.GetString("name2") + " Wins";
                Destroy (GameObject.FindWithTag("soul"));
            }
            if (score.score == scoreP2.score)
            {
                winnerText.text = "Draw";
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
