using System;
using UnityEngine;

public class LobbyController
{
    private LobbyView lobbyView;
    private int boardCols;
    private int boardRows;
    private int bombNumber;

    public int BoardCols {  get { return boardCols; } }
    public int BoardRows {  get { return boardRows; } }
    public int BombNumber {  get { return bombNumber; } }

    public LobbyController(LobbyView lobbyView)
    {
        this.lobbyView = lobbyView;
        lobbyView.SetController(this);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameService.Instance.BoardManager.StartGame(bombNumber,boardRows,boardCols);
    }

    public void SetBoardCols(int boardCols)=>this.boardCols = boardCols;

    public void SetBoardRows(int boardRows)=>this.boardRows = boardRows;

    public void SetBombNumber(int bombNumber)=>this.bombNumber = bombNumber;

}