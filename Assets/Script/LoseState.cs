using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class LoseState : BaseState
{
    public override void EnterState(GameManager gameManager)
    {
        gameManager.LosePanel();
        gameManager.timer.StopTimer();
    }
    public override void ExitState(GameManager gameManager)
    {

    }
    public override void UpdateState(GameManager gameManager)
    {

    }

    public bool CheckLoseCondition(GameManager gameManager)
    {
        // اگر گرید پر باشد و هیچ ترکیبی ممکن نباشد
        return GridIsFull(gameManager) && !CanMergeTiles(gameManager);
    }

    public bool GridIsFull(GameManager gameManager)
    {
        for (int x = 1; x < gameManager.gridSizeX ; x++)
        {
            for (int y = 1; y < gameManager.gridSizeY ; y++)
            {
                if (gameManager.dataGrid[x,y].number == null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool CanMergeTiles(GameManager gameManager)
    {
        for (int x = 1; x < gameManager.gridSizeX ; x++)
        {
            for(int y = 1;y < gameManager.gridSizeY ; y++)
            {
                Number currentTile =gameManager.dataGrid[x,y].number;
                if(currentTile != null)
                {
                    if ( x>1 && gameManager.dataGrid[x-1,y].number != null &&
                        gameManager.dataGrid[x-1,y].number.value==currentTile.value)
                    {
                        //Can Merge whit Left
                        return true;
                        
                    }
                    if (x < gameManager.gridSizeX - 2 && gameManager.dataGrid[x + 1, y].number != null
                        && gameManager.dataGrid[x + 1, y].number.value == currentTile.value)
                    {
                        return true;
                    }
                    if (y > 1 && gameManager.dataGrid[x,y-1].number !=null 
                        && gameManager.dataGrid[x,y-1].number.value == currentTile.value)
                    {
                        return true;
                    }
                    if(y < gameManager.gridSizeY -2 && gameManager.dataGrid[x,y+1].number != null
                        && gameManager.dataGrid[x,y+1].number.value == currentTile.value)
                    {
                        return true;
                    }
                        

                }
            }
        }
        return false;

    }
}
