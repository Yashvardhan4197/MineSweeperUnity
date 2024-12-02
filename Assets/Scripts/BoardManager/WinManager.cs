

using System.Collections.Generic;
using UnityEngine;

public class WinManager
{
    private int totalBombs;

    public void SetTotalBombs(int  totalBombs)
    {
        this.totalBombs = totalBombs;
    }


    public void CheckWinCondition(List<GridObject>gridObjects)
    {
        int boxesOpened = 0;
        for(int i = 0; i < gridObjects.Count; i++)
        {
            if (gridObjects[i].GetIsOpened()==true)
            {
                boxesOpened++;
            }
        }
        if(boxesOpened==gridObjects.Count-totalBombs)
        {
            Debug.Log("GAME-WON");
        }
    }
}