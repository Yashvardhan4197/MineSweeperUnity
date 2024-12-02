
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] Slider bombNumberSlider;
    [SerializeField] Slider boardColsSlider;
    [SerializeField] Slider boardRowsSlider;

    [SerializeField] GameObject SetGridPopUp;
    [SerializeField] Button setGridAndStartButton;
    [SerializeField] Button GoBackFromSetGridPopUpButton;
    [SerializeField] TextMeshProUGUI boardColNumberText;
    [SerializeField] TextMeshProUGUI boardRowsNumberText;
    [SerializeField] TextMeshProUGUI bombNumberText;


    [SerializeField] int minColsAccepted;
    [SerializeField] int maxColsAccepted;
    [SerializeField] int minRowsAccepted;
    [SerializeField] int maxRowsAccepted;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartGameButtonClicked);
        exitButton.onClick.AddListener(ExitGame);

        InitializeSliderValues();

        boardColsSlider.onValueChanged.AddListener(ChangeColumnsValue);
        boardRowsSlider.onValueChanged.AddListener(ChangeRowsValue);
        bombNumberSlider.onValueChanged.AddListener(ChangeBombValue);
        setGridAndStartButton.onClick.AddListener(StartGame);
        GoBackFromSetGridPopUpButton.onClick.AddListener(GobackToLobby);
    }

    private void InitializeSliderValues()
    {
        bombNumberSlider.minValue = 0;
        boardColsSlider.minValue = minColsAccepted;
        boardRowsSlider.minValue = minRowsAccepted;
        boardColsSlider.maxValue = maxColsAccepted;
        boardRowsSlider.maxValue = maxRowsAccepted;
        lobbyController.SetBoardRows(minRowsAccepted);
        lobbyController.SetBoardCols(minColsAccepted);
        ChangeRowsValue(minColsAccepted);
        ChangeColumnsValue(minColsAccepted);

        ChangeBombMaxValue((lobbyController.BoardRows * lobbyController.BoardCols) - 8);
    }

    private void ChangeBombMaxValue(int bomb)
    {
        if (bomb > 0)
        {
            bombNumberSlider.maxValue = bomb;
        }
        else
        {
            bombNumberSlider.maxValue = 0;
        }
        
        if(bombNumberSlider.value>=bomb)
        {
            bombNumberSlider.value = bomb;
            lobbyController.SetBombNumber(bomb);
        }
    }


    private void ChangeBombValue(float bomb)
    {
        int temp = (int)bomb;
        bombNumberText.text=temp.ToString();
        lobbyController.SetBombNumber(temp);
    }

    private void ChangeRowsValue(float row)
    {
        int temp = (int)row;
        boardRowsNumberText.text=temp.ToString();
        lobbyController.SetBoardRows(temp);
        ChangeBombMaxValue((lobbyController.BoardRows * lobbyController.BoardCols) - 8);
    }

    private void ChangeColumnsValue(float col)
    {
        int temp = (int)col;
        boardColNumberText.text = temp.ToString();
        lobbyController.SetBoardCols(temp);
        ChangeBombMaxValue((lobbyController.BoardRows * lobbyController.BoardCols) - 8);
    }

    private void ExitGame()
    {
        lobbyController.ExitGame();
    }

    private void OnStartGameButtonClicked()
    {
        SetGridPopUp.SetActive(true);
    }

    private void StartGame()
    {
        lobbyController.StartGame();

        this.gameObject.SetActive(false);
        SetGridPopUp.SetActive(false);
    }

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    public void OpenLobby()
    {
        this.gameObject.SetActive(true);
        SetGridPopUp.SetActive(false);
        InitializeSliderValues();
    }

    private void GobackToLobby()
    {
        SetGridPopUp.SetActive(false);
    }

}
