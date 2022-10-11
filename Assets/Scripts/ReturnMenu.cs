using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnMenu : MonoBehaviour
{

    public void GoToMenu(int sceneIndex)
    { 
        SceneManager.LoadScene(sceneIndex);
    }
}
