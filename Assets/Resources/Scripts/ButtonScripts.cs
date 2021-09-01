using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScripts : MonoBehaviour
{
    
    public GameObject LoadingScren;
    public GameObject LoadingScren2;
    public GameObject PrivasyPolisy;
    public GameObject welcomText;
    public GameObject PlayGame;
    public GameObject NextText;
    public Slider Bar;
    private int Scene;
    int goPlay = 0;

    private void Awake()
    {
        goPlay = PlayerPrefs.GetInt("goPlay");
        //вывод таблицы рекордов на экран
        if (goPlay==1)
        {
            welcomText.SetActive(false);
            NextText.SetActive(false);
            PlayGame.SetActive(true);
            camera_AI.bestScore = PlayerPrefs.GetInt("Playerscore");
            GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>().text = camera_AI.bestScore + "";

        }

    }

    public void DeliteKey()
    {
        PlayerPrefs.DeleteKey("Playerscore");
        PlayerPrefs.DeleteKey("goPlay");
    }

    public void Privacy()
    {
        PrivasyPolisy.SetActive(!PrivasyPolisy.activeSelf);
    }

    public void Start()
    {
        Scene = 1;
        StartCoroutine(ShowText());
    }  

    public void PlayScene()
    {
        LoadingScren.SetActive(true);
        LoadingScren2.SetActive(false);        
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene);
        asyncLoad.allowSceneActivation = false;

        
        while (!asyncLoad.isDone)
        {
            Bar.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    //пропуск текста
    public void ScipText()
    {
        welcomText.SetActive(false);
        PlayGame.SetActive(true);
        goPlay = 1;
        PlayerPrefs.SetInt("goPlay", goPlay);//сохранение на приветствие
        NextText.SetActive(false);
    }

    //эффект печати текста
    
    private string fullText = "Приветствую тебя игрок! Эта игра очень проста, наслаждаясь " +
        "музыкой, попробуй продержаться как можно больше времени!";
    private string currentText = "";

    IEnumerator ShowText()
    {
        if (goPlay==0)
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                //проверка на отключение текста
                if (goPlay == 0)
                {
                    yield return null;
                    GameObject.Find("WelcomeText").GetComponent<UnityEngine.UI.Text>().text = currentText;
                }
                currentText = fullText.Substring(0, i);

                yield return new WaitForSeconds(0.1f);                
            }

            yield return new WaitForSeconds(1.5f);
            fullText = "правила тут простые, нажимая на стрелочки ты вращаешь треугольник, тебе нужно выйти из лабиринта не задев края сжимающихся кругов. ";
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                if (goPlay == 0)
                {
                    yield return null;
                    GameObject.Find("WelcomeText").GetComponent<UnityEngine.UI.Text>().text = currentText;
                }
                yield return new WaitForSeconds(0.1f);

            }

            yield return new WaitForSeconds(1.5f);
            fullText = "после 1 минуты как ты продержался игра только начинается! Искренне желаю тебе удачи! ";
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                if (goPlay == 0)
                {
                    yield return null;
                    GameObject.Find("WelcomeText").GetComponent<UnityEngine.UI.Text>().text = currentText;
                }
                yield return new WaitForSeconds(0.1f);
                
            }
            goPlay = 1;
            PlayerPrefs.SetInt("goPlay",goPlay);//сохранение на приветствие
            welcomText.SetActive(false);
            NextText.SetActive(false);
            PlayGame.SetActive(true);
        }
        

    }
}
