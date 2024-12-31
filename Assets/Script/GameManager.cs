
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public List<int> movingObjects = new List<int>();
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    public bool hasMoved = false;

    private BaseState currentState;
    //Other Script
    public InputState inputState;
    public StartState startState;
    public MoveState moveState;
    public DataClass dataClass;
    public ProcessState processState;
    public Base squarePrefab;
    public Number TileNumberPrefab;
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
    //Panel Lose
    public GameObject panelLose;
    public int moveCount;

    public bool horizontal = false;
    public bool vertical = false;


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
        Debug.Log("Initializing states...");
        inputState = new InputState();
        moveState = new MoveState();
        dataClass = new DataClass();
        processState = new ProcessState();
        startState = new StartState(squarePrefab, TileNumberPrefab, gridSizeX, gridSizeY, distance, this.transform );

        if (startState == null)
        {
            Debug.LogError("StartState initialization failed!");
            return;
        }

        currentState = startState;
        currentState.EnterState(this);

        highscore = PlayerPrefs.GetInt("High score", 0);
        UpdateHighScre();
      
    }

    void Update()
    {
        if (currentState == null)
        {
            Debug.LogError("Current state is null in Update!");
            return;
        }

        currentState.UpdateState(this);
    }

    public void ChangeState(BaseState newState)
    {
        if (newState == null)
        {
            Debug.LogError("Attempting to change to a null state!");
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
       
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
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
    }

    public void UpdateHighScre()
    {
        if (score > highscore)
        {
            highscore = score;

            highscoretext.text ="" + highscore;

            score = 0;
            scoretext.text = "" + score;
        }
    }

    public void PrintGrid(GameManager gameManager)
    {
        for (int x = 1; x < gameManager.gridSizeX; x++)
        {
            for (int y = 1; y < gameManager.gridSizeY; y++)
            {
                if (gameManager.dataGrid[x, y].number != null)
                    Debug.Log($"Tile at ({x}, {y}): {gameManager.dataGrid[x, y].number.value}");
            }
        }
    }
}


