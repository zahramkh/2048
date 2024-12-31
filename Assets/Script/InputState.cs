using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static GameManager;

public class InputState : BaseState
{
  
    public override void EnterState(GameManager gameManager)
    {
    }
    public override void ExitState(GameManager gameManager)
    {

    }
    public override void UpdateState(GameManager gameManager)
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameManager.lastInput = playerInput.Left;
            gameManager.ChangeState(gameManager.processState);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameManager.lastInput = playerInput.Right;
            gameManager.ChangeState(gameManager.processState);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            gameManager.lastInput = playerInput.Up;
            gameManager.ChangeState(gameManager.processState);

        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManager.lastInput = playerInput.Down;
            gameManager.ChangeState(gameManager.processState);

        }
    }
}
    
   








