
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridObject : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI gridObjectNumberText;
    [SerializeField] Button gridObjectButton;
    [SerializeField] Sprite[] bombStateImages;
    [SerializeField] GameObject bombImageHolder;
    [SerializeField] GameObject markerImageHolder;
    private int gridObjectNumber = 0;
    private bool isBomb = false;
    private bool isOpened = false;
    private bool isMarked = false;
    private void Start()
    {
        gridObjectNumberText.text = "";
        gridObjectNumberText.gameObject.SetActive(false);
        bombImageHolder.SetActive(false);
        markerImageHolder.SetActive(false);
        isOpened = false;
        isBomb = false;
        isMarked = false;
    }

    private void OnGridObjectClicked()
    {
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
            gridObjectNumberText.text = "";
            bombImageHolder.GetComponent<Image>().sprite = bombStateImages[0];
        }
    }

    public void OpenGridObject()
    {
        if(isMarked==true)
        {
            markerImageHolder.gameObject.SetActive(false);
            isMarked = false;
            GameService.Instance.BoardManager.ReduceMarkedNumber();
        }

        if (!isBomb)
        {
            gridObjectNumberText.gameObject.SetActive(true);
        }
        else
        {
            bombImageHolder.gameObject.SetActive(true);
        }
        isOpened = true;
        this.gameObject.GetComponent<Image>().color= Color.grey;
    }

    public void SetBomb(bool bomb) { isBomb = bomb; }

    public bool GetBomb() => isBomb;

    public bool GetIsOpened()
    {
        return isOpened;
    }

    public bool GetIsMarked() => isMarked;

    public void ExplodeBomb()
    {
        bombImageHolder.GetComponent<Image>().sprite= bombStateImages[1];
    }


    public void SetIsMarked(bool  marker)
    {
        if(marker)
        {
            isMarked = true;
            markerImageHolder.gameObject.SetActive(true);
        }
        else
        {
            isMarked = false;
            markerImageHolder.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Right)
        {
            GameService.Instance.BoardManager.MarkGridObject(this);
        }
        else if (eventData.button==PointerEventData.InputButton.Left)
        {
            OnGridObjectClicked();
        }
    }
}
