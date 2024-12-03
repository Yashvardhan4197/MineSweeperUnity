
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartGameButtonClicked);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        lobbyController.ExitGame();
        GameService.Instance.SoundService.PlaySFX(SoundNames.CLICK);
    }

    private void OnStartGameButtonClicked()
    {
        GameService.Instance.UIService.GetBoardSetPopUpController().OpenPopUp();
        GameService.Instance.SoundService.PlaySFX(SoundNames.CLICK);
    }

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    public void OpenLobby()
    {
        this.gameObject.SetActive(true);
    }
    
    public void CloseLobby()
    {
        this.gameObject.SetActive(false);
    }

}
