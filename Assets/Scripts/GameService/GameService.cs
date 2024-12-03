
using UnityEngine;
using UnityEngine.Events;

public class GameService : MonoBehaviour
{
    private static GameService instance;
    public static GameService Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //DATA
    [SerializeField] GameObject gridPrefab;
    [SerializeField] GameObject boardPrefab;
    [SerializeField] GameObject boardHolder;
    [SerializeField] Transform startPos;
    [SerializeField] float padding;

    //VIEWS
    [SerializeField] LobbyView lobbyView;
    [SerializeField] InGameUIView inGameUIView;
    [SerializeField] BoardSetPopUpView boardSetPopUpView;
    //Services
    private BoardManager boardManager;
    private UIService uIService;
    public BoardManager BoardManager {  get { return boardManager; } }
    public UIService UIService { get { return uIService; } }

    //EVENTS
    public UnityAction STARTGAME;
    public UnityAction LOSTGAME;
    public UnityAction WONGAME;
    private void Init()
    {
        boardManager=new BoardManager(boardPrefab,gridPrefab,boardHolder,startPos,padding);
        uIService= new UIService(lobbyView,inGameUIView,boardSetPopUpView);
        OpenLobby();
    }
    public void OpenLobby()
    {
        uIService.GetLobbyController().OpenLobbyScreen();
    }

    public void EndGame()
    {
        
    }
}
