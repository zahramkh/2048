using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : BaseState
{
    public override void EnterState(GameManager gameManager)
    {

    }
    public override void ExitState(GameManager gameManager)
    {

    }
    public override void UpdateState(GameManager gameManager)
    {

    }

    public void Lose(GameManager gameManager , int x, int y)
    {
        if (gameManager.dataGrid[x, y].number != null)
        {
            Debug.Log("GameOver");
            gameManager.panelLose.SetActive(true);
        }
    }
}
