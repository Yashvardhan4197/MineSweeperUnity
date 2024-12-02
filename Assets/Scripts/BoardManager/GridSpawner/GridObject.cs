
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gridObjectNumberText;
    [SerializeField] Button gridObjectButton;
    private int gridObjectNumber = 0;
    private bool isBomb = false;
    private bool isOpened = false;
    private void Start()
    {
        gridObjectButton.onClick.AddListener(OnGridObjectClicked);
        gridObjectNumberText.text = "";
        gridObjectNumberText.gameObject.SetActive(false);
        isOpened = false;
        isBomb = false;
    }

    private void OnGridObjectClicked()
    {
        //GridSpawner.Instance.OnGridObjectClicked(this);
        GameService.Instance.BoardManager.OnGridObjectSelected(this);
    }

    public int GetGridObjectNumber() => gridObjectNumber;

    public void SetGridObjectNumber(int number)
    {
        gridObjectNumber= number;
        if (!isBomb)
        {
            if (number == 0)
            {
                gridObjectNumberText.text = "";
            }
            else
            {
                gridObjectNumberText.text = number.ToString();
            }
        }
        else
        {
            gridObjectNumberText.text = "X";
        }
    }

    public void OpenGridObject()
    {
        gridObjectNumberText.gameObject.SetActive(true);
        isOpened = true;
        this.gameObject.GetComponent<Image>().color= Color.grey;
    }

    public void SetBomb(bool bomb) { isBomb = bomb; }

    public bool GetBomb() => isBomb;

    public bool GetIsOpened()
    {
        return isOpened;
    }

}
