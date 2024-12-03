
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


    [SerializeField] int minColsAccepted;
    [SerializeField] int maxColsAccepted;
    [SerializeField] int minRowsAccepted;
    [SerializeField] int maxRowsAccepted;

    private void Start()
    {
        this.gameObject.SetActive(false);
        boardColsSlider.onValueChanged.AddListener(ChangeColumnsValue);
        boardRowsSlider.onValueChanged.AddListener(ChangeRowsValue);
        bombNumberSlider.onValueChanged.AddListener(ChangeBombValue);
        setGridAndStartButton.onClick.AddListener(StartGame);
        GoBackFromSetGridPopUpButton.onClick.AddListener(GobackToLobby);
        InitializeSliderValues();
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
        boardColsSlider.value = minColsAccepted;
        boardRowsSlider.value = minRowsAccepted;
        boardSetPopUpController.SetBoardRows(minRowsAccepted);
        boardSetPopUpController.SetBoardCols(minColsAccepted);
        bombNumberSlider.value = 0;
        ChangeRowsValue(minColsAccepted);
        ChangeColumnsValue(minColsAccepted);

        ChangeBombMaxValue((boardSetPopUpController.BoardRows * boardSetPopUpController.BoardCols) - 8);
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

        this.gameObject.SetActive(false);
    }

    private void GobackToLobby()
    {
        this.gameObject.SetActive(false);
    }

    public void ClosePopUp()
    {
        this.gameObject.SetActive(false);
    }


}
