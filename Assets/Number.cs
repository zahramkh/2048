using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager;
using static UnityEngine.GraphicsBuffer;

public class Number : MonoBehaviour
{
    public GameObject tile;
    public int value;
    public Color color;
    public Vector3 NumberMove;
    public Vector2 curentPosition;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private TextMeshPro textmesh;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetNumber(int newValue)
    {
        value = newValue;
        textmesh.text = value.ToString();

        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (spriteRenderer != null)
        {
            color =GetColorForValue(value);
            spriteRenderer.color = color;
        }
    }

    public void Move(GameManager gameManager)
    {
        Vector3 targetPosition = CalcuTargetPoz(gameManager);

        if (targetPosition != Vector3.zero)
        {
            HandelMoveAndMerg(gameManager, targetPosition);
        }
        NumberMove = Vector3.zero;
    }
    private Vector3 CalcuTargetPoz(GameManager gameManager)
    {
        int targetX = Mathf.RoundToInt(curentPosition.x);
        int targetY = Mathf.RoundToInt(curentPosition.y);

        if (gameManager.lastInput == playerInput.Right)
        {
            targetX += Mathf.RoundToInt(NumberMove.x);
        }
        else if (gameManager.lastInput == playerInput.Left) {

            targetX -= Mathf.RoundToInt(NumberMove.x);
        }
        else if (gameManager.lastInput == playerInput.Up)
        {

            targetY += Mathf.RoundToInt(NumberMove.y);
        }
        else if (gameManager.lastInput == playerInput.Down)
        {

            targetY -= Mathf.RoundToInt(NumberMove.y);
        }

        if (targetX >=0 && targetX<gameManager.gridSizeX 
            && targetY >=0 && targetY < gameManager.gridSizeY)
        {
            return new Vector3(targetX, targetY);
        }
        return Vector3.zero;

    }

    public void HandelMoveAndMerg(GameManager gameManager , Vector3 targetPosition)
    {
        int targetX = Mathf.RoundToInt(targetPosition.x);
        int targetY = Mathf.RoundToInt(targetPosition.y);

        int currentX = Mathf.RoundToInt(curentPosition.x);
        int currentY = Mathf.RoundToInt(curentPosition.y);


        Number targetNumber = gameManager.dataGrid[targetX, targetY].number;
        Number currenNumber = gameManager.dataGrid[currentX, currentY].number;
      
            gameManager.hasMoved = true;
            Vector3 targetpozition = gameManager.dataGrid[targetX, targetY].basePrefab.transform.position;
            GameManager.instance.movingObjects.Add(this.gameObject.GetInstanceID());
            Debug.Log("add" + GameManager.instance.movingObjects);

            LeanTween.move(gameObject, targetpozition, 0.2f).setOnComplete(() =>
            {
                gameManager.dataGrid[currentX, currentY].number = null;
                gameManager.dataGrid[targetX, targetY].number = this;
                curentPosition = new Vector2(targetX, targetY);
                GameManager.instance.movingObjects.Remove(this.gameObject.GetInstanceID());
                Debug.Log("remove " + GameManager.instance.movingObjects);
            });

      

    }

   

    private Color GetColorForValue(int value)
    {
        switch (value)
        {
            case 2:return Color.gray;
            case 4:return Color.green;
            case 8:return Color.blue;
            case 16:return Color.red;
            case 32:return Color.yellow;
            case 64: return Color.black;
            case 128: return Color.black;
            case 256: return Color.black;
            default: return Color.white;
        }
    }
}
