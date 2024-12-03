
public class BoardSetPopUpController
{
    private BoardSetPopUpView boardSetPopUpView;
    private int boardCols;
    private int boardRows;
    private int bombNumber;
    public int BoardCols { get { return boardCols; } }
    public int BoardRows { get { return boardRows; } }
    public int BombNumber { get { return bombNumber; } }


    public BoardSetPopUpController(BoardSetPopUpView boardSetPopUpView)
    {
        this.boardSetPopUpView=boardSetPopUpView;
        boardSetPopUpView.SetController(this);
    }

    public void OpenPopUp()
    {
        boardSetPopUpView.InitializeSliderValues();
        boardSetPopUpView.OpenPopUp();
    }

    public void StartGame()
    {
        GameService.Instance.STARTGAME.Invoke();
        GameService.Instance.BoardManager.StartGame(bombNumber, boardRows, boardCols);
        boardSetPopUpView.ClosePopUp();
    }


    public void SetBoardCols(int boardCols) => this.boardCols = boardCols;

    public void SetBoardRows(int boardRows) => this.boardRows = boardRows;

    public void SetBombNumber(int bombNumber) => this.bombNumber = bombNumber;

}

