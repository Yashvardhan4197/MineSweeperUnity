using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    private InGameUIController inGameUIController;

    [SerializeField] Button pauseButton;
    [SerializeField] TextMeshProUGUI winLoseText;
    [SerializeField] GameObject popUpWindow;

    [SerializeField] Button restartButton;
    [SerializeField] Button setGridButton;
    [SerializeField] Button exitButton;


    private bool gamePaused;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitToLobby);
        setGridButton.onClick.AddListener(OpenSetGridButton);
        popUpWindow.SetActive(false);
        gamePaused = false;
    }

    private void OpenSetGridButton()
    {
        Debug.Log("hello bitch");
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
        gamePaused = false;
    }

    public void OnGameWon()
    {
        popUpWindow.SetActive(true);
        winLoseText.text = "YOU WON";
        pauseButton.gameObject.SetActive(false);
    }

    public void OnGameLose()
    {
        popUpWindow.SetActive(false);
        winLoseText.text = "YOU LOST";
        pauseButton.gameObject.SetActive(false);
    }

}
