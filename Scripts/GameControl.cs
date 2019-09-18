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

    void Start()
    {
        MaxScore = PlayerPrefs.GetInt("MaxScore");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuGame");
        
    }

}
