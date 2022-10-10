using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreP2 : MonoBehaviour
{
    Text txtScore;
    public int score = 0;
    public int combo = 1;
    public float timeComboValue = 0;
    public float seconds;
    public float ms;

    void Awake() => txtScore = GetComponent<Text>();
    void FixedUpdate() {
        if (timeComboValue > 0){
            timeComboValue -=Time.deltaTime;
        }
        else{
            timeComboValue = 0;
            ResetComboP2();
        }
        DisplayTime(timeComboValue);
    }
    public void AddPointsP2(int points)
    {
        score += (points * this.combo);
        txtScore.text = $"Souls: {score} x{combo} {ms}";
    }
    public void IncreaseComboP2(){
        this.combo++;
        this.timeComboValue = 5;
        txtScore.text = $"Souls: {score} x{combo} {ms}";
    }
    public void ResetComboP2(){
        this.combo = 1;
        this.timeComboValue = 0;
        txtScore.text = $"Souls: {score} x{combo} {ms}";
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        this.seconds = Mathf.FloorToInt(timeToDisplay % 60);
        this.ms = Mathf.FloorToInt(timeToDisplay * 1000);
        this.ms = this.ms % 1000;

        txtScore.text = $"Souls: {score} x{combo} {seconds}.{ms}";
    }
}