﻿public class UIService
{
    private LobbyController lobbyController;
    private InGameUIController inGameUIController;

    public UIService(LobbyView lobbyView,InGameUIView inGameUIView)
    {
        lobbyController = new LobbyController(lobbyView);
        inGameUIController = new InGameUIController(inGameUIView);

    }

    public LobbyController GetLobbyController()=>lobbyController;

    public InGameUIController GetInGameUIController()=>inGameUIController;
}