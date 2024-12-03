public class UIService
{
    private LobbyController lobbyController;
    private InGameUIController inGameUIController;
    private BoardSetPopUpController boardSetPopUpController;

    public UIService(LobbyView lobbyView,InGameUIView inGameUIView, BoardSetPopUpView boardSetPopUpView)
    {
        lobbyController = new LobbyController(lobbyView);
        inGameUIController = new InGameUIController(inGameUIView);
        boardSetPopUpController=new BoardSetPopUpController(boardSetPopUpView);

    }

    public LobbyController GetLobbyController()=>lobbyController;

    public InGameUIController GetInGameUIController()=>inGameUIController;

    public BoardSetPopUpController GetBoardSetPopUpController()=>boardSetPopUpController;
}