using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GameControl : MonoBehaviour
{
    public static GameControl Instance; //экземпляр

    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;
    public int MaxScore;
    public Text scoreText;
    public Text MaxScoreText;
    
   // public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject readyPanel;

    public AdMobInterstitial ad;
    public static int deadCounter = 0; //счётчик смертей

    private static PlayerData playerData;

    private ParallaxBackGround parallaxBackGround;

    private PauseButton pause;
    public GameObject pauseButton;

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource[] myAudio;

    private const string leaderboard = "CgkIlf6A1qEQEAIQAQ";  // из Play Console

    void Start()
    {
       
        pause = FindObjectOfType<PauseButton>();
        parallaxBackGround = FindObjectOfType<ParallaxBackGround>();
        toggle = FindObjectOfType<Toggle>();

        MaxScore = PlayerPrefs.GetInt("MaxScore");
        readyPanel.SetActive(true);
        pause.pauzePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
       
    }

    void Update()
    {
        if (MaxScore < score)
        {
            MaxScore = score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);
            
        }

        if (MaxScore > score)
        {
            MaxScoreText.text = "Рекорд: " + MaxScore;
        }
    }

    public void LeaderboardButton()
    {
        MenuGame.ShowLeaderboards();
        //Social.ShowLeaderboardUI();
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

        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = false;
           
            PlayerPrefs.Save();
        }       
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio[0].mute = false;
                myAudio[1].mute = false;               
                toggle.isOn = false;
            }
            else
            {
                myAudio[0].mute = true;
                myAudio[1].mute = true;               
                toggle.isOn = true;
            }
        }
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);            
            myAudio[0].mute = true;
            myAudio[1].mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            myAudio[0].mute = false;
            myAudio[1].mute = false;          
        }
        PlayerPrefs.Save();
    }

    public void Score()
    {
        if (isGameOver)
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
        pauseButton.SetActive(false);
    }

   public void GameOverTextActiv()
    {
        //gameOverText.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {

        MenuGame.ReportScore(PlayerPrefs.GetInt("MaxScore", MaxScore));
        Debug.Log(PlayerPrefs.GetInt("MaxScore", MaxScore));

        //PlayerPrefs.SetInt("deadCounter", deadCounter);
        deadCounter++;
        Debug.Log(deadCounter);    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
              
    }

    public void ReadyPanel()
    {
        pause.pauzePanel.SetActive(false);
        readyPanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.PlaySound("CreateBooble");
        pauseButton.SetActive(true);
    }

    public void Exit()
    {
        MenuGame.ReportScore(PlayerPrefs.GetInt("MaxScore", MaxScore));
        SceneManager.LoadScene("MenuGame");
        //Application.Quit();
        
    }

    public void ExitReadyPanel()
    {
        // MenuGame.ReportScore(PlayerPrefs.GetInt("MaxScore", MaxScore));
         SceneManager.LoadScene("MenuGame");
        //Application.Quit();
        //readyPanel.SetActive(false);
        //gameOverPanel.SetActive(true);

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
