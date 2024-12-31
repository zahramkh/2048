using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class StartState : BaseState
{
    // A 2D array to store the grid squares
    public GameObject[,] gridArray; 

    //Prefab Background And Tile
    public Base squarePrefab;
    //Prefab TileNumber
    public Number TileNumberPrefab;
    //public TextMeshPro TextInTile;
    private UnityEngine.Transform parentTransform;

    //for Set squarePrefab on it
    public GameObject square;
    //for Set TileNumberPrefab on it
    public GameObject tile;

    public int gridSizeX;
    public int gridSizeY;
    public float distance = 1.1f;
    public GameManager gameManager;
    public StartState(Base squarePrefab , Number TileNumberPrefab, int gridSizeX, int gridSizeY, float distance, UnityEngine.Transform parentTransform )
    {
        this.squarePrefab = squarePrefab;
        this.gridSizeX = gridSizeX;
        this.gridSizeY = gridSizeY;
        this.distance = distance;
        this.parentTransform = parentTransform;
        this.TileNumberPrefab = TileNumberPrefab;
        //this.TextInTile = TextInTile;
        
    }

    public override void EnterState(GameManager gameManager)
    {
        Debug.Log("Enter State");
        CreateGrid(gameManager);
        SpawnTile(gameManager);
        SpawnTile(gameManager);
        gameManager.ChangeState(gameManager.inputState);

    }
    public override void ExitState(GameManager gameManager)
    {

    }
    public override void UpdateState(GameManager gameManager)
    {

    }
    //--------------------------------------------------------------------
    //Creating Grid
    public void CreateGrid(GameManager gameManager )
    {
        // Initialize the 2D grid array and columns list
        gridArray = new GameObject[gridSizeX, gridSizeY];
        gameManager.dataGrid = new DataClass[gridSizeX, gridSizeY];


        float midInScreen = (gridSizeY - 1) * distance / 2;

        for (int y = 1; y < gridSizeX; y++)
        {
            // Create a new list for each column
            for (int x = 1; x < gridSizeY; x++)
            {
                // Calculate the position of the grid square
                Vector3 squarePosition = new Vector3(x * distance, y * distance - midInScreen, 0);

                // Instantiate the grid square
                square = GameObject.Instantiate(squarePrefab.gameObject, squarePosition, Quaternion.identity, parentTransform);

                // Store the square in the 2D array
                gameManager.dataGrid[x, y] = new DataClass();
                gameManager.dataGrid[x, y].basePrefab = square.GetComponent<Base>();
              
            }
        }
    }
    
    public void SpawnTile(GameManager gameManager)
    {
        List<Vector2Int> emptyPositions = new List<Vector2Int>();

        for (int x = 1; x < gameManager.gridSizeX; x++)
        {
            for (int y = 1; y < gameManager.gridSizeY; y++)
            {
                if (gameManager.dataGrid[x, y].number == null) 
                {
                    emptyPositions.Add(new Vector2Int(x, y)); 
                }
            }
        }

        // 
        if (emptyPositions.Count == 0)
        {
            Debug.LogWarning("No empty positions available for spawning a tile!");
            return;
        }
        else
        {
            // 
            Vector2Int randomPosition = emptyPositions[Random.Range(0, emptyPositions.Count)];

            // 
            Vector3 tilePosition = new Vector3(randomPosition.x * gameManager.distance, randomPosition.y * gameManager.distance - ((gameManager.gridSizeY - 1) * gameManager.distance / 2), 0);
            GameObject tile = GameObject.Instantiate(gameManager.TileNumberPrefab.gameObject, tilePosition, Quaternion.identity, parentTransform);

            // 
            tile.transform.SetParent(gameManager.dataGrid[randomPosition.x, randomPosition.y].basePrefab.transform);
            gameManager.dataGrid[randomPosition.x, randomPosition.y].number = tile.GetComponent<Number>();

            TextMeshPro textComponent = tile.GetComponentInChildren<TextMeshPro>();
            int value = UnityEngine.Random.Range(0f, 1f) < 0.9f ? 2 : 4;
            textComponent.text = value.ToString();
            gameManager.dataGrid[randomPosition.x, randomPosition.y].number.SetNumber(value);
            Vector2 currentPosition = new Vector2(randomPosition.x, randomPosition.y);
            gameManager.dataGrid[randomPosition.x, randomPosition.y].number.curentPosition = currentPosition;
        }

        
    }



}


