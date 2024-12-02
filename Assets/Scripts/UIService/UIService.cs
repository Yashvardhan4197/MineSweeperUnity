public class UIService
{
    private LobbyController lobbyController;
    private levelUIController levelUIController;

    public UIService(LobbyView lobbyView)
    {
        lobbyController = new LobbyController(lobbyView);
    }

}