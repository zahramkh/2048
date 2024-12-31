using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static UnityEngine.GraphicsBuffer;


public class MoveState : BaseState
{
    private InputState inputState;
    public override void EnterState(GameManager gameManager)
    {
        if (gameManager.lastInput == playerInput.Left)
        {
            for (int y = 1; y < gameManager.gridSizeY; y++)
            {
                for (int x = 1; x < gameManager.gridSizeX; x++)

                {

                    if (gameManager.dataGrid[x, y].number != null)
                    {
                        gameManager.dataGrid[x, y].number.Move(gameManager);

                    }
                }
            }
        }
        else if (gameManager.lastInput == playerInput.Right)
        {
            for (int y = 1; y < gameManager.gridSizeY; y++)
            {
                for (int x = gameManager.gridSizeX - 1; x >= 1; x--)
                {
                    if (gameManager.dataGrid[x, y].number != null)
                    {
                        gameManager.dataGrid[x, y].number.Move(gameManager);
                    }
                }
            }

        }
        else if (gameManager.lastInput == playerInput.Down)
        {
            for (int x = 1; x < gameManager.gridSizeX; x++)
            {
                for (int y = 11; y < gameManager.gridSizeY; y++)

                {
                    if (gameManager.dataGrid[x, y].number != null)
                    {
                        gameManager.dataGrid[x, y].number.Move(gameManager);

                    }
                }
            }
        }
        else if (gameManager.lastInput == playerInput.Up)
        {
            for (int x = 1; x < gameManager.gridSizeX; x++)
            {
                for (int y = gameManager.gridSizeY - 1; y >= 1; y--)
                {
                    if (gameManager.dataGrid[x, y].number != null)
                    {
                        gameManager.dataGrid[x, y].number.Move(gameManager);
                    }
                }
            }
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
        if(GameManager.instance.movingObjects.Count == 0)
        {
            gameManager.ChangeState(gameManager.inputState);
        }
    }

}




