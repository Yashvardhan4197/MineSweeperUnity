
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    private InGameUIController inGameUIController;
    [SerializeField] Image backgroundIMG;
    [SerializeField] Button pauseButton;
    [SerializeField] TextMeshProUGUI winLoseText;
    [SerializeField] GameObject popUpWindow;

    [SerializeField] Button restartButton;
    [SerializeField] Button setGridButton;
    [SerializeField] Button exitButton;

    [SerializeField] TextMeshProUGUI bombMarkerText;

    private bool gamePaused;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitToLobby);
        setGridButton.onClick.AddListener(OpenSetGridButton);
        popUpWindow.SetActive(false);
        bombMarkerText.gameObject.SetActive(false);
        gamePaused = false;
    }

    private void OpenSetGridButton()
    {
        inGameUIController.OpenBoardSetPopUp();
    }

    private void ExitToLobby()
    {
        inGameUIController.ExitGame();
        pauseButton.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        inGameUIController.RestartGame();
        popUpWindow?.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        bombMarkerText.gameObject.SetActive(true);
        gamePaused = false;
    }

    private void PauseGame()
    {
        if (gamePaused)
        {
            popUpWindow.SetActive(false);
            winLoseText.gameObject.SetActive(false);
            gamePaused = false;
        }
        else
        {
            popUpWindow.SetActive(true);
            winLoseText.gameObject.SetActive(false);
            gamePaused=true;
        }
        backgroundIMG.color = Color.grey;
        ChangeBackgroundAlphaColor();
    }

    public void SetController(InGameUIController inGameUIController)
    {
        this.inGameUIController = inGameUIController;
    }

    public void OnGameStart()
    {
        this.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        popUpWindow?.SetActive(false);
        bombMarkerText.gameObject.SetActive(true);
        gamePaused = false;
    }

    public void OnGameWon()
    {
        popUpWindow.SetActive(true);
        winLoseText.text = "YOU WON";
        backgroundIMG.color = Color.green;
        ChangeBackgroundAlphaColor();
        pauseButton.gameObject.SetActive(false);
        bombMarkerText.gameObject.SetActive(false);
    }

    public void OnGameLose()
    {
        popUpWindow.SetActive(true);
        winLoseText.text = "YOU LOST";
        backgroundIMG.color = Color.red;
        ChangeBackgroundAlphaColor();
        pauseButton.gameObject.SetActive(false);
        bombMarkerText.gameObject.SetActive(false);
    }

    private void ChangeBackgroundAlphaColor()
    {
        var temp = backgroundIMG.color;
        temp.a = 0.6f;
        backgroundIMG.color = temp;
    }

    public void SetMarkedBombUI(int markedBombs,int totalBombs)
    {
        bombMarkerText.text= markedBombs.ToString()+"/"+totalBombs.ToString()+" Bombs FOUND";
    }

}
