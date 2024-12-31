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
    public Vector2 curentPositionMerge;
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
            HandelMoveAndMerg(gameManager, new Vector3Int((int)targetPosition.x,(int)targetPosition.y));
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

        if (targetX >=1 && targetX<gameManager.gridSizeX 
            && targetY >=1 && targetY < gameManager.gridSizeY)
        {
            return new Vector3(targetX, targetY);
        }
        return Vector3.zero;

    }

    public void HandelMoveAndMerg(GameManager gameManager, Vector3Int targetIndex)
    {
        Debug.LogError(targetIndex,this.gameObject);

        int currentX = Mathf.RoundToInt(curentPosition.x);
        int currentY = Mathf.RoundToInt(curentPosition.y);

        Vector3 targetpozition = gameManager.dataGrid[targetIndex.x, targetIndex.y].basePrefab.transform.position;

        GameManager.instance.movingObjects.Add(this.gameObject.GetInstanceID());

        gameManager.dataGrid[currentX, currentY].number = null;

            LeanTween.move(gameObject, targetpozition, 0.2f).setOnComplete(() =>
            {
                Number targetNumber = gameManager.dataGrid[targetIndex.x, targetIndex.y].number;
                GameManager.instance.hasMoved = true;
                if (targetNumber != null)
                {
                    Destroy(targetNumber.gameObject);
                    SetNumber(value * 2);
                }
                gameManager.dataGrid[targetIndex.x, targetIndex.y].number = this;
                curentPosition = new Vector2(targetIndex.x, targetIndex.y);

                GameManager.instance.movingObjects.Remove(this.gameObject.GetInstanceID());
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
