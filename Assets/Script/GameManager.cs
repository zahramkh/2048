using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<int> movingObjects = new List<int>();

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this); 
        }
        else
        {
            Destroy(this.gameObject); 
        }

       
    }

    private void OnEnable()
    {      
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Test")
        {
            Destroy(this.gameObject);
        }
    }

    public bool hasMoved = false;

    private BaseState currentState;
    //Other Script
    public InputState inputState;
    public LoseState loseState;
    public StartState startState;
    public MoveState moveState;
    public DataClass dataClass;
    public ProcessState processState;
    public Base squarePrefab;
    public Number TileNumberPrefab;
    public Timer timer;
    //public UiTween uiTween;

    //About Score And HighScore
    public int score = 0;
    public int highscore = 0;
    public TextMeshProUGUI highscoretext;
    public TextMeshProUGUI scoretext;
    //Grid Size On Board
    public int gridSizeX;
    public int gridSizeY;
    public float distance = 1.1f;
    // Shared DataClass grid for all states
    public DataClass[,] dataGrid; 
    public int moveCount;

    public enum playerInput
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
    public playerInput lastInput = playerInput.None;
    void Start()
    {
        dataGrid = new DataClass[gridSizeX , gridSizeY];
        //Debug.Log("Initializing states...");
        inputState = new InputState();
        moveState = new MoveState();
        dataClass = new DataClass();
        processState = new ProcessState();
        loseState = new LoseState();    
        startState = new StartState(squarePrefab, TileNumberPrefab, gridSizeX, gridSizeY, distance, this.transform );

        if (startState == null)
        {
            return;
        }

        currentState = startState;
        currentState.EnterState(this);
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoretext.text = "" + highscore;     
    }

    void Update()
    {
        if (currentState == null)
        {
            return;
        }

        currentState.UpdateState(this);
        scoretext.text = score.ToString();
    }

    public void ChangeState(BaseState newState)
    {
        if (newState == null)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

    public void Reset()
    {
       
        for (int x = 1; x < gridSizeX; x++)
        {
            for (int y = 1; y < gridSizeY; y++)
            {
                if (dataGrid[x, y].number != null)
                {

                    Destroy(dataGrid[x, y].number.gameObject);
                    dataGrid[x, y].number = null;


                }
               
            }
        }
        startState.SpawnTile(this);
        startState.SpawnTile(this);
        UpdateHighScre();
       timer.elapsedTime = 0;
        timer.isRunning=true;

    }


    public void UpdateHighScre()
    {
        int saveHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > saveHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highscore = score;
            highscoretext.text =" " + highscore;

            score = 0;
            scoretext.text = "" + score;
        }
        else
        {
            score = 0;
            scoretext.text = "" + score;
        }
    }

    public void WinPanel()
    {
        int scoree = score;
        string teaxtscore = "score : " + score;
        ClientCoordinator.Instance.OpenOverlay<Panel_Win>().Setup("You Win", teaxtscore);
    }
    public void LosePanel()
    {
        int scoree = score;
        string teaxtscore = "score : " + score;
        ClientCoordinator.Instance.OpenOverlay<Panel_Lose>().Setup("You Lose", teaxtscore);
    }

}


