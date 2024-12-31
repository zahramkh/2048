using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
  
    public abstract void EnterState(GameManager gameManager);
    public abstract void ExitState(GameManager gameManager);
    public abstract void UpdateState(GameManager gameManager);
}
