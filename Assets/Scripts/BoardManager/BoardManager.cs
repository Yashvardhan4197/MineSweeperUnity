
using System.Collections.Generic;
using UnityEngine;

public class BoardManager 
{
    private GameObject gridPrefab;
    private GameObject boardPrefab;
    private GameObject boardHolder;
    private Transform startPos;
    private int boardRows;
    private int boardCols;
    private int bombNumber;
    private float spacing;
    private float padding;
    private GridSpawner gridSpawner;
    private BombSpawner bombSpawner;
    private WinManager winManager;
    private bool FirstGridObjectClickCheck;
    private List<GridObject> gridObjects;
    private GameObject board;
    public BoardManager(GameObject boardPrefab,GameObject gridPrefab,GameObject boardHolder,Transform boardStartPos,float boardPadding)
    {
        this.gridPrefab = gridPrefab;
        this.boardPrefab = boardPrefab;
        this.boardHolder = boardHolder;
        startPos = boardStartPos;
        padding = boardPadding;
        Init();
        GameService.Instance.LOSTGAME += OpenAllBoxes;
        GameService.Instance.WONGAME+= OpenAllBoxes;
    }

    public void StartGame(int bombNumber,int boardRows,int boardCols)
    {
        Object.Destroy(board?.gameObject);
        bombSpawner.SetBombNumber(bombNumber);
        gridSpawner.Init(boardRows,boardCols);
        winManager.SetTotalBombs(bombNumber);
        this.boardCols = boardCols;
        this.boardRows= boardRows;
        this.bombNumber = bombNumber;
        board=InstantiateBoard();
        gridObjects = gridSpawner.SpawnGrid();
        if (boardCols <= 10)
        {
            board.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
        if(boardCols>=15||boardRows>=15)
        {
            board.transform.localScale = new Vector3(1.3f, 1.3f, 0);
        }
        FirstGridObjectClickCheck = true;
    }


    public void RestartGame()
    {
        Object.Destroy(board.gameObject);
        bombSpawner.SetBombNumber(bombNumber);
        gridSpawner.Init(boardRows, boardCols);
        winManager.SetTotalBombs(bombNumber);
        board = InstantiateBoard();
        gridObjects = gridSpawner.SpawnGrid();
        if (boardCols <= 10)
        {
            board.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
        if (boardCols >= 15 || boardRows >= 15)
        {
            board.transform.localScale = new Vector3(1.3f, 1.3f, 0);
        }
        FirstGridObjectClickCheck = true;
    }


    private void Init()
    {
        gridSpawner = new GridSpawner(gridPrefab, spacing);
        bombSpawner = new BombSpawner();
        winManager = new WinManager();

    }

    private GameObject InstantiateBoard()
    {
        GameObject board=Object.Instantiate(boardPrefab,new Vector3(0,0,0),boardPrefab.transform.rotation);
        board.GetComponent<RectTransform>().SetParent(Object.FindObjectOfType<Canvas>().transform);
        board.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        float totalWidth= (gridPrefab.GetComponent<RectTransform>().rect.width+spacing)*boardCols-spacing;
        float totalHeight=(gridPrefab.GetComponent<RectTransform>().rect.height+spacing)*boardRows-spacing;

        board.GetComponent<RectTransform>().sizeDelta=new Vector2((totalWidth + padding), (totalHeight + padding));
        Vector2 boardPos = board.GetComponent<RectTransform>().position;

        Vector3 newStartPos = new Vector3(boardPos.x - (totalWidth / 2) + (gridPrefab.GetComponent<RectTransform>().rect.width / 2),
            boardPos.y + (totalHeight / 2)- (gridPrefab.GetComponent<RectTransform>().rect.height / 2), startPos.position.z);
        
        gridSpawner.SetTransform(newStartPos,board.GetComponent<RectTransform>());
        board.GetComponent<RectTransform>().SetParent(boardHolder.transform);
        return board;
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
            currentGridObject.ExplodeBomb();
            GameService.Instance.LOSTGAME?.Invoke();
        }
        else
        {
            OpenBoxes(currentGridObject,currentRows,currentCols);
        }
        winManager.CheckWinCondition(gridObjects);
    }

    private void OpenAllBoxes()
    {
        foreach (GridObject gridObject in gridObjects)
        {
            gridObject.OpenGridObject();  
        }
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

    private void SetNumbersOnBoard()
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
