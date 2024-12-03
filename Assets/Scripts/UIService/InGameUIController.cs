
public class InGameUIController
{
    private InGameUIView inGameUIView;

    public InGameUIController(InGameUIView inGameUIView)
    {
        this.inGameUIView = inGameUIView;
        inGameUIView.SetController(this);
        GameService.Instance.STARTGAME += OnGameStart;
        GameService.Instance.LOSTGAME += GameLost;
        GameService.Instance.WONGAME += GameWon;
    }

    public void OnGameStart()
    {
        inGameUIView.OnGameStart();
    }

    public void OpenBoardSetPopUp()
    {
        GameService.Instance.UIService.GetBoardSetPopUpController().OpenPopUp();
    }

    public void RestartGame()
    {
        GameService.Instance.BoardManager.RestartGame();

    }

    public void GameWon()
    {
        inGameUIView.OnGameWon();
    }

    public void GameLost()
    {
        inGameUIView.OnGameLose();
    }

    public void ExitGame()
    {
        GameService.Instance.UIService.GetLobbyController().OpenLobbyScreen();
    }

    public void SetMarkedBombUI(int markedBombs, int totalBombs)
    {
        inGameUIView.SetMarkedBombUI(markedBombs, totalBombs);
    }
}