using System;
using UnityEngine;

public class LobbyController
{
    private LobbyView lobbyView;

    public LobbyController(LobbyView lobbyView)
    {
        this.lobbyView = lobbyView;
        lobbyView.SetController(this);
        GameService.Instance.STARTGAME += StartGame;
    }

    public void OpenLobbyScreen()
    {
        lobbyView.OpenLobby();
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        lobbyView.CloseLobby();
        //GameService.Instance.UIService.GetInGameUIController().OnGameStart();
    }

}