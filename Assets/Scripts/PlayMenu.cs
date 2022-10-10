using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] InputField txtPlayer1;
    [SerializeField] InputField txtPlayer2;
    [SerializeField] GameObject music;

    public void Play()
    {
        Destroy(music.gameObject);
        PlayerPrefs.SetString("name1", txtPlayer1.text);
        PlayerPrefs.SetString("name2", txtPlayer2.text);
        SceneManager.LoadScene("SampleScene");
    }
}
