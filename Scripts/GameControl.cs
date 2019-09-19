using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    public static GameControl Instance; //экземпляр

    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;
    public int MaxScore;
    public Text scoreText;
    public Text MaxScoreText;
    
    public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject readyPanel;

    public AdMobInterstitial ad;
    public static int deadCounter = 0; //счётчик смертей

    private static PlayerData playerData;

    void Start()
    {
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        readyPanel.SetActive(true);
        Time.timeScale = 0;
        //playerData = FindObjectOfType<PlayerData>();
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != null)
        {
            Destroy(gameObject);
        }

       
    }

    void Update()
    {
        //if(isGameOver && Input.GetMouseButtonDown(0))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        if(MaxScore < score)
        {
            MaxScore = score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);
        }
        if(MaxScore > score)
        {
            MaxScoreText.text = "Рекорд: " + MaxScore;
        }
    }

    public void Score()
    {
        if(isGameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Очки: " + score;
    }

    public void Die()
    {
        isGameOver = true;      
        Invoke("GameOverTextActiv", 1f);
    }

    void GameOverTextActiv()
    {
        //gameOverText.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        
        //PlayerPrefs.SetInt("deadCounter", deadCounter);
        deadCounter++;
        Debug.Log(deadCounter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

    public void ReadyPanel()
    {
        readyPanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void Exit()
    {
        SceneManager.LoadScene("MenuGame");
        
    }

    public void AdmobShow()
    {
        if (deadCounter % 3 == 0)
        {
            ad.ShowAds();
            Debug.Log(deadCounter);
            Debug.Log("показ баннера");
        }
    }

    public void SavePlayer()
    {
        SaveScript.SavePlayer(this);
        Debug.Log("Сохранили");

    }

    public void Load()
    {
        
        // SceneManager.LoadScene("ChoiceLevels");
       // PlayerData data = SaveScript.LoadPlayer();
       // GameControl.deadCounter = data.deadCounter;
        Debug.Log("Загрузили");
    }

}
