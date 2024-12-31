using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

using static GameManager;

public class ProcessState : BaseState
{
    public override void EnterState(GameManager gameManager)

    {
        if (gameManager.lastInput == playerInput.Right)
        {
            ProcessRight(gameManager);

        }
        else if (gameManager.lastInput == playerInput.Left)
        {
            ProcessLeft(gameManager);
        }
        else if (gameManager.lastInput == playerInput.Up)
        {
            ProcessUp(gameManager);
        }
        else if (gameManager.lastInput == playerInput.Down)
        {
            ProcessDown(gameManager);
        }

    }
    public override void ExitState(GameManager gameManager)
    {
        if (gameManager.hasMoved)
        {
            gameManager.startState.SpawnTile(gameManager);
            gameManager.hasMoved = false;

        }
    }
    public override void UpdateState(GameManager gameManager)
    {
        if (GameManager.instance.movingObjects.Count == 0)
        {
            gameManager.ChangeState(gameManager.inputState);
        }
    }
    public void ProcessRight(GameManager gameManager)
    {

        for (int y = 1; y < gameManager.gridSizeY; y++)
        {
            int MoveCount = 0;
            int LastNumber = 0;

            for (int x = gameManager.gridSizeX - 1; x >= 1; x--)
            {
                ManageProcessX(gameManager, x, y , ref LastNumber,  ref MoveCount);
            }

        }

    }
    public void ProcessLeft(GameManager gameManager)
    {
        for (int y = 1; y < gameManager.gridSizeY; y++)
        {
            int MoveCount = 0;
            int LastNumber = 0;
            for (int x = 1; x < gameManager.gridSizeX; x++)
            {
                ManageProcessX(gameManager, x, y, ref LastNumber, ref MoveCount);
            }
        }
 }
    public void ProcessUp(GameManager gameManager)
    {
        for (int x = 1; x < gameManager.gridSizeX; x++)
        {
            int MoveCount = 0;
            int LastNumber = 0;

            for (int y = gameManager.gridSizeY - 1; y >= 1; y--)
            {
                ManageProcessY(gameManager, x, y, ref LastNumber, ref MoveCount);
            }
        }
    }
    public void ProcessDown(GameManager gameManager)
    {
        for (int x = 1; x < gameManager.gridSizeX; x++)
        {
            int MoveCount = 0;
            int LastNumber = 0;

            for (int y = 1; y < gameManager.gridSizeY; y++)
            {
                ManageProcessY(gameManager, x, y, ref LastNumber, ref MoveCount);
            }
        }
    }

    public void ManageProcessX(GameManager gameManager ,int x,int y , ref int LastNumber, ref int MoveCount)
    {
       
        if (gameManager.dataGrid[x, y].number != null)
        { 
            int curentNumber = gameManager.dataGrid[x, y].number.value;
            Vector2 currentPos = gameManager.dataGrid[x, y].number.transform.position;
            if (LastNumber == 0)
            {
                LastNumber = curentNumber;
            }
            else if (LastNumber == curentNumber)
            {
                //int mergenumber = curentNumber * 2;
                //gameManager.dataGrid[x, y].number.SetNumber(mergenumber);
                //GameObject.Destroy(gameManager.dataGrid[x, y].number.gameObject);
                //gameManager.dataGrid[x, y].number=null;

                //MoveCount++;
                LastNumber = 0;
            }
            else
            {
                LastNumber = curentNumber;
            }
            if (gameManager.dataGrid[x,y].number != null)
            {
                gameManager.dataGrid[x, y].number.NumberMove = new Vector2(MoveCount, 0);
                Debug.Log($"-- {gameManager.dataGrid[x, y].number.NumberMove.x}");

                gameManager.dataGrid[x, y].number.Move(gameManager);
            }

        }
        else 
        {
            MoveCount++;

        }
    }
    public void ManageProcessY(GameManager gameManager, int x, int y, ref int LastNumber, ref int MoveCount)
    {
        if (gameManager.dataGrid[x, y].number != null)
        {
            int curentNumber = gameManager.dataGrid[x, y].number.value;

            if (LastNumber == 0)
            {
                LastNumber = curentNumber;
            }
            else if (LastNumber == curentNumber)
            {
                //MoveCount++;
                LastNumber = 0;
            }
            else
            {
                LastNumber = curentNumber;
            }

            if (gameManager.dataGrid[x, y].number != null)
            {
                gameManager.dataGrid[x, y].number.NumberMove = new Vector2(0, MoveCount);
                Debug.Log($"-- {gameManager.dataGrid[x, y].number.NumberMove.x}");

                gameManager.dataGrid[x, y].number.Move(gameManager);
            };
        }
        else
        {
            MoveCount++;

        }
    }



}


