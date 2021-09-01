using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera_AI : MonoBehaviour
{
    int[] angle_list = { 0, 30, 60, 90, 120, 160, 180 };
    public Camera m_OrthographicCamera;
    public int frequency = 20;
    const float angle = 0.8f;
    int timer_mil = 0;
    int timer = 0;
    int iq = 0;
    int mem;

    public GameObject PlayerLevelUp;
    public GameObject Win;
    public GameObject WinText;
    public static int score = 0;
    public static float levelUp = 0.2f;
    public static int bestScore = 0;
    //public Text textScore;
    // int timerScore;
    // int timerScoreMil;


    private GameObject obstacle_1 { get; set; }

    private void Create_Obstacle()
    {
        int angle_index = Random.Range(0, angle_list.Length);

        if (mem == angle_index && angle_index >= 3)
        {
            angle_index -= Random.Range(0, 4);
        }
        else if (mem == angle_index && angle_index <= 3)
        {
            angle_index += Random.Range(1, 3);
        }
        
        mem = angle_index;
        obstacle_1 = new GameObject
        {
            name = "Obstacle_1"
        };

        int gg = Random.Range(1, 10);
        //на мой взгляд это отвечает за появления палок
        if (4 % gg == 0 && timer >= 20)
        {
            obstacle_1.AddComponent<obstacle2_AI>();
        }

        else if (5 % gg == 0 && timer >= 30)
        {
            obstacle_1.AddComponent<obstacle3_AI>();
        }

        else
        {
            obstacle_1.AddComponent<obstacle_AI>();
        }

        obstacle_1.transform.Rotate(0, 0, angle_list[angle_index]);        

    }

    void Start()
    {
        score = 0;
        levelUp = 0.2f;
        Application.targetFrameRate = 60;
        m_OrthographicCamera = this.GetComponent<Camera>();
        GameObject.Find("Timer").GetComponent<UnityEngine.UI.Text>().text = "00:01";
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        timer_mil += 1;

        if (timer_mil == 100)
        {
            timer += 1;
            timer_mil = 0;
        }

        //if (timer % 2 == 0 && timer !=0 && timer !=60 && timer_mil == 0 )
        //{            
        //    StartCoroutine(LevelUp());
            
            
        //    Debug.Log(levelUp);
        //}

        if (timer == 60)
        {
            StartCoroutine(PlayerWin());
        }
              


        GameObject.Find("Timer").GetComponent<UnityEngine.UI.Text>().text = $"{timer:00}:{timer_mil:00}";
        m_OrthographicCamera.orthographicSize = Mathf.Abs(0.7f * Mathf.Sin(frequency * Time.time) - 8f);

        iq += 1;
        if (iq >= 45)
        {
            iq = 0;
            Create_Obstacle();
        }

        transform.Rotate(0, 0, angle);
        
    }

    public static void Score()
    {
        score++;
        GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>().text = score+"";
        if (bestScore<=score)
        {
            bestScore = score;
        }
    }

    IEnumerator LevelUp()
    {
        PlayerLevelUp.SetActive(true);
        yield return new WaitForSeconds(1f);
        PlayerLevelUp.SetActive(false);
        //if (levelUp != 0.4)
        //{
        //    levelUp += (float)0.1;
        //}
        
    }

    IEnumerator PlayerWin()
    {
        timer = 0;        
        Win.SetActive(false);
        WinText.SetActive(true);
        yield return new WaitForSeconds(3f);        
        Win.SetActive(true);
        WinText.SetActive(false);
    }

    public void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetInt("Playerscore", bestScore);
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Playerscore", bestScore);
    }
}
