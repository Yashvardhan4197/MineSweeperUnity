using System;

public class InGameUIController
{
    private InGameUIView inGameUIView;

    public InGameUIController(InGameUIView inGameUIView)
    {
        this.inGameUIView = inGameUIView;
        inGameUIView.SetController(this);
        GameService.Instance.STARTGAME += OnGameStart;
    }

    public void OnGameStart()
    {
        inGameUIView.OnGameStart();
    }

    //Working
    public void RestartGame()
    {
        GameService.Instance.BoardManager.RestartGame();
    }

    public void GameWon()
    {

    }

    public void GameLost()
    {

    }

    public void ExitGame()
    {
        GameService.Instance.UIService.GetLobbyController().OpenLobbyScreen();
    }
}