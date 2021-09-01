using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControll : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void isPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;        
    }
    public void isPlay()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Playerscore", camera_AI.bestScore);
    }
}
