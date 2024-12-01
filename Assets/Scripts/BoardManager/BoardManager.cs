
using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private static BoardManager instance;
    public static BoardManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] GameObject gridPrefab;
    [SerializeField] GameObject boardPrefab;
    [SerializeField] Transform startPos;


    [SerializeField] int boardRows;
    [SerializeField] int boardCols;
    [SerializeField] float spacing;
    [SerializeField] float padding;
    [SerializeField] int bombNumber;

    private GridSpawner gridSpawner;
    private BombSpawner bombSpawner;
    private WinManager winManager;
    private bool FirstGridObjectClickCheck;
    private List<GridObject> gridObjects;
    private void Start()
    {
        gridSpawner = new GridSpawner(gridPrefab,boardRows,boardCols,spacing);
        bombSpawner = new BombSpawner(bombNumber);
        winManager = new WinManager();
        StartGame();
    }

    private void StartGame()
    {
        Init();
    }

    private void Init()
    {
        InstantiateBoard();
        gridObjects = gridSpawner.SpawnGrid();
        FirstGridObjectClickCheck = true;
    }

    private void InstantiateBoard()
    {
        GameObject board=Instantiate(boardPrefab,new Vector3(0,0,0),transform.rotation);
        board.GetComponent<RectTransform>().SetParent(FindObjectOfType<Canvas>().transform);
        board.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        float totalWidth= (gridPrefab.GetComponent<RectTransform>().rect.width+spacing)*boardCols-spacing;
        float totalHeight=(gridPrefab.GetComponent<RectTransform>().rect.height+spacing)*boardRows-spacing;

        board.GetComponent<RectTransform>().sizeDelta=new Vector2((totalWidth + padding), (totalHeight + padding));
        Vector2 boardPos = board.GetComponent<RectTransform>().position;

        Vector3 newStartPos = new Vector3(boardPos.x - (totalWidth / 2) + (gridPrefab.GetComponent<RectTransform>().rect.width / 2),
            boardPos.y + (totalHeight / 2)- (gridPrefab.GetComponent<RectTransform>().rect.height / 2), startPos.position.z);
        
        gridSpawner.SetTransform(newStartPos,board.GetComponent<RectTransform>());
    }

    public void OnGridObjectSelected(GridObject currentGridObject)
    {
        int number = 0;
        foreach (GridObject gridObject in gridObjects)
        {
            if(gridObject == currentGridObject)
            {
                break;
            }
            number++;
        }
        int currentRows = number / boardCols;
        int currentCols = number % boardCols;

        if(FirstGridObjectClickCheck)
        {
            FirstGridObjectClickCheck = false;
            bombSpawner.SpawnBombs(currentRows,currentCols,boardCols, boardRows);
            SetNumbersOnBoard();
        }

        if (currentGridObject.GetBomb() == true)
        {
            Debug.Log("You Lost");
        }
        else
        {
            OpenBoxes(currentGridObject,currentRows,currentCols);
        }
        winManager.CheckWinCondition(gridObjects, bombNumber);
    }

    private void OpenBoxes(GridObject currentGridObject,int i,int j)
    {
        if (currentGridObject.GetIsOpened() == true) { return; }
        if (currentGridObject.GetBomb() == false)
        { 
            currentGridObject.OpenGridObject();
        }
        else { return; }
        if (currentGridObject.GetGridObjectNumber() != 0) { return; }
        if (currentGridObject.GetGridObjectNumber() == 0)
        {
            if (i > 0 && j > 0)
            {
                int ind = (i - 1) * boardCols + (j - 1);
                OpenBoxes(gridObjects[ind], i - 1, j - 1);
            }
            if (i > 0)
            {
                int ind = (i - 1) * boardCols + (j);
                OpenBoxes(gridObjects[ind], i - 1, j);
            }
            if (i > 0 && j < boardCols - 1)
            {
                int ind = (i - 1) * boardCols + (j + 1);
                OpenBoxes(gridObjects[ind], i - 1, j + 1);
            }
            if (j > 0)
            {
                int ind = i * boardCols + (j - 1);
                OpenBoxes(gridObjects[ind], i, j - 1);
            }
            if (j < boardCols - 1)
            {
                int ind = i * boardCols + (j + 1);
                OpenBoxes(gridObjects[ind], i, j + 1);
            }
            if (i < boardRows - 1 && j > 0)
            {
                int ind = (i + 1) * boardCols + (j - 1);
                OpenBoxes(gridObjects[ind],i+1, j -1);
            }
            if (i < boardRows - 1 && j < boardCols - 1)
            {
                int ind = (i + 1) * boardCols + (j + 1);
                OpenBoxes(gridObjects[ind], i + 1, j + 1);
            }
            if (i < boardRows - 1)
            {
                int ind = (i + 1) * boardCols + j;
                OpenBoxes(gridObjects[ind], i + 1, j);
            }
        }
        return;

    }

    public void SetNumbersOnBoard()
    {
        for(int currentInd = 0;currentInd<gridObjects.Count;currentInd++)
        {
            int number = 0;
            int i=currentInd/boardCols;
            int j= currentInd % boardCols;
            if(i>0&&j>0)
            {
                int ind = (i - 1) * boardCols + (j-1);
                if (gridObjects[ind].GetBomb() == true)
                {
                    number++;
                }
            }

            if(i>0)
            {
                int ind= (i - 1) *boardCols + (j);
                if (gridObjects[ind].GetBomb() == true)
                {
                    number++;
                }
            }

            if(i>0&&j<boardCols-1)
            {
                int ind = (i - 1) * boardCols + (j + 1);
                if (gridObjects[ind].GetBomb()==true)
                {
                    number++;
                }
            }

            if(j>0)
            {
                int ind=i*boardCols + (j-1);
                if (gridObjects[ind].GetBomb()==true)
                {
                    number++;
                }
            }

            if(j<boardCols-1)
            {
                int ind=i*boardCols + (j+1);
                if (gridObjects[ind].GetBomb()==true)
                {
                    number++;
                }
            }

            if(i<boardRows-1&&j>0)
            {
                int ind=(i+1)*boardCols + (j-1);
                if (gridObjects[ind].GetBomb() == true)
                {
                    number++;
                }
            }

            if(i<boardRows-1&&j<boardCols-1)
            {
                int ind=(i+1)*boardCols+ (j+1);
                if (gridObjects[ind].GetBomb() == true)
                {
                    number++;
                }
            }

            if(i<boardRows-1)
            {
                int ind = (i + 1) * boardCols + j;
                if (gridObjects[ind].GetBomb() == true)
                {
                    number++;
                }
            }
            gridObjects[currentInd].SetGridObjectNumber(number);
        }
    }

    public GridSpawner GetGridSpawner() => gridSpawner;

    public BombSpawner GetBombSpawner() => bombSpawner;

    public List<GridObject> GetGridObjects() => gridObjects;

}
