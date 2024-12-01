
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner
{
    private int bombNumber;

    public BombSpawner(int bombNumber)
    {
        this.bombNumber = bombNumber;
    }

    public void SpawnBombs(int currentRow,int currentCol, int totalCols, int totalRows)
    {
        List<GridObject> gridObjects=BoardManager.Instance.GetGridObjects();
        List<int> nonBombIndexes= GetNonBombIndexes(gridObjects,currentRow,currentCol,totalCols, totalRows);
        int temp2=bombNumber;
        while(temp2!=0)
        {
            int temp = Random.Range(0, gridObjects.Count);
            if (!nonBombIndexes.Contains(temp))
            {
                if (gridObjects[temp].GetBomb() == false)
                {
                    gridObjects[temp].SetBomb(true);
                    temp2--;
                }
            }
        }
    }

    private List<int> GetNonBombIndexes(List<GridObject> gridObjects,int i, int j, int totalCols,int totalRows)
    {
        List<int>NonBombIndexes=new List<int>();
        if (i > 0 && j > 0)
        {
            int ind = (i - 1) * totalCols + (j - 1);
            NonBombIndexes.Add(ind);
        }
        if (i > 0)
        {
            int ind = (i - 1) * totalCols + (j);
            NonBombIndexes.Add(ind);
        }
        if (i > 0 && j < totalCols - 1)
        {
            int ind = (i - 1) * totalCols + (j + 1);
            NonBombIndexes.Add(ind);
        }
        if (j > 0)
        {
            int ind = i * totalCols + (j - 1);
            NonBombIndexes.Add(ind);
        }
        if (j < totalCols - 1)
        {
            int ind = i * totalCols + (j + 1);
            NonBombIndexes.Add(ind);
        }
        if (i < totalRows - 1 && j > 0)
        {
            int ind = (i + 1) * totalCols + (j - 1);
            NonBombIndexes.Add(ind);
        }
        if (i < totalRows - 1 && j < totalCols - 1)
        {
            int ind = (i + 1) * totalCols + (j + 1);
            NonBombIndexes.Add(ind);
        }
        if (i < totalRows - 1)
        {
            int ind = (i + 1) * totalCols + j;
            NonBombIndexes.Add(ind);
        }
        NonBombIndexes.Add(i * totalCols + j);
        return NonBombIndexes;
    }
}