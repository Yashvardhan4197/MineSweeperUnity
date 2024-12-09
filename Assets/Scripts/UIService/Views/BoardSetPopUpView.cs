
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardSetPopUpView : MonoBehaviour
{
    private BoardSetPopUpController boardSetPopUpController;
    [SerializeField] Slider bombNumberSlider;
    [SerializeField] Slider boardColsSlider;
    [SerializeField] Slider boardRowsSlider;

    [SerializeField] Button setGridAndStartButton;
    [SerializeField] Button GoBackFromSetGridPopUpButton;
    [SerializeField] TextMeshProUGUI boardColNumberText;
    [SerializeField] TextMeshProUGUI boardRowsNumberText;
    [SerializeField] TextMeshProUGUI bombNumberText;

    [SerializeField] Button decrementBombButton;
    [SerializeField] Button incrementBombButton;

    [SerializeField] Button incrementRowsButton;
    [SerializeField] Button decrementRowsButton;

    [SerializeField] Button incrementColumnButton;
    [SerializeField] Button decrementColumnButton;

    [SerializeField] int minColsAccepted;
    [SerializeField] int maxColsAccepted;
    [SerializeField] int minRowsAccepted;
    [SerializeField] int maxRowsAccepted;
    [SerializeField] int minBombsAccepted;

    private void Start()
    {
        this.gameObject.SetActive(false);
        SetupButtonListeners();
        InitializeSliderValues();
    }

    private void SetupButtonListeners()
    {
        boardColsSlider.onValueChanged.AddListener(ChangeColumnsValue);
        boardRowsSlider.onValueChanged.AddListener(ChangeRowsValue);
        bombNumberSlider.onValueChanged.AddListener(ChangeBombValue);
        setGridAndStartButton.onClick.AddListener(StartGame);
        GoBackFromSetGridPopUpButton.onClick.AddListener(GobackToLobby);
        decrementBombButton.onClick.AddListener(DecrementBombValue);
        incrementBombButton.onClick.AddListener(IncrementBombValue);
        decrementColumnButton.onClick.AddListener(DecrementColumnValue);
        incrementColumnButton.onClick.AddListener(IncrementColumnValue);
        decrementRowsButton.onClick.AddListener(DecrementRowValue);
        incrementRowsButton.onClick.AddListener(IncrementRowValue);
    }


    private void IncrementRowValue()
    {
        if(boardRowsSlider.value < boardRowsSlider.maxValue)
        {
            boardRowsSlider.value++;
            ChangeRowsValue(boardRowsSlider.value);
        }
    }

    private void DecrementRowValue()
    {
        if (boardRowsSlider.value > boardRowsSlider.minValue)
        {
            boardRowsSlider.value--;
            ChangeRowsValue(boardRowsSlider.value);
        }
    }


    private void IncrementColumnValue()
    {
        if (boardColsSlider.value < boardColsSlider.maxValue)
        {
            boardColsSlider.value++;
            ChangeColumnsValue(boardColsSlider.value);
        }
    }

    private void DecrementColumnValue()
    {
        if (boardColsSlider.value > boardColsSlider.minValue)
        {
            boardColsSlider.value--;
            ChangeColumnsValue(boardColsSlider.value);
        }
    }

    private void IncrementBombValue()
    {
        
        if(bombNumberSlider.value < bombNumberSlider.maxValue)
        {
            bombNumberSlider.value++;
            ChangeBombValue(bombNumberSlider.value);
        }
    }

    private void DecrementBombValue()
    {
        
        if (bombNumberSlider.value > bombNumberSlider.minValue)
        {
            bombNumberSlider.value--;
            ChangeBombValue(bombNumberSlider.value);
        }
    }

    public void SetController(BoardSetPopUpController controller)
    {
        boardSetPopUpController = controller;
    }
    public void OpenPopUp()
    {
        this.gameObject.SetActive(true);
    }

    public void InitializeSliderValues()
    {
        bombNumberSlider.minValue = 0;
        boardColsSlider.minValue = minColsAccepted;
        boardRowsSlider.minValue = minRowsAccepted;
        boardColsSlider.maxValue = maxColsAccepted;
        boardRowsSlider.maxValue = maxRowsAccepted;
        bombNumberSlider.minValue=minBombsAccepted;
        boardColsSlider.value = minColsAccepted;
        boardRowsSlider.value = minRowsAccepted;
        bombNumberSlider.value=minBombsAccepted;
        boardSetPopUpController.SetBoardRows(minRowsAccepted);
        boardSetPopUpController.SetBoardCols(minColsAccepted);
        ChangeBombValue(minBombsAccepted);
        ChangeRowsValue(minColsAccepted);
        ChangeColumnsValue(minColsAccepted);
        ChangeBombMaxValue((boardSetPopUpController.BoardRows * boardSetPopUpController.BoardCols) - 8);
    }

    private void ChangeBombMaxValue(int bomb)
    {
        if (bomb > minBombsAccepted)
        {
            bombNumberSlider.maxValue = bomb;
        }
        else
        {
            bombNumberSlider.maxValue = minBombsAccepted;
        }

        if (bombNumberSlider.value >= bomb)
        {
            bombNumberSlider.value = bomb;
            boardSetPopUpController.SetBombNumber(bomb);
        }
    }


    private void ChangeBombValue(float bomb)
    {
        int temp = (int)bomb;
        bombNumberText.text = temp.ToString();
        boardSetPopUpController.SetBombNumber(temp);
    }

    private void ChangeRowsValue(float row)
    {
        int temp = (int)row;
        boardRowsNumberText.text = temp.ToString();
        boardSetPopUpController.SetBoardRows(temp);
        ChangeBombMaxValue((boardSetPopUpController.BoardRows * boardSetPopUpController.BoardCols) - 8);
    }

    private void ChangeColumnsValue(float col)
    {
        int temp = (int)col;
        boardColNumberText.text = temp.ToString();
        boardSetPopUpController.SetBoardCols(temp);
        ChangeBombMaxValue((boardSetPopUpController.BoardRows * boardSetPopUpController.BoardCols) - 8);
    }

    private void StartGame()
    {
        boardSetPopUpController.StartGame();
        GameService.Instance.SoundService.PlaySFX(SoundNames.CLICK);
        this.gameObject.SetActive(false);
    }

    private void GobackToLobby()
    {
        GameService.Instance.SoundService.PlaySFX(SoundNames.CLICK);
        this.gameObject.SetActive(false);
    }

    public void ClosePopUp()
    {
        this.gameObject.SetActive(false);
    }


}
