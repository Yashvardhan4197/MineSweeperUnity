
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner
{
    private int bombNumber;

    private List<int> GetNonBombIndexes(int i, int j, int totalCols, int totalRows)
    {
        List<int> NonBombIndexes = new List<int>();
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

    public void SetBombNumber(int bombNumber)
    {
        this.bombNumber = bombNumber;
    }

    public void SpawnBombs(int currentRow,int currentCol, int totalCols, int totalRows)
    {
        List<GridObject> gridObjects=GameService.Instance.BoardManager.GetGridObjects();
        List<int> nonBombIndexes= GetNonBombIndexes(currentRow,currentCol,totalCols, totalRows);
        int temp2=bombNumber;
        if (bombNumber <= 2)
        {
            ExtendNonBombIndexes(nonBombIndexes, totalRows, totalCols);
        }
        while (temp2!=0)
        {
            int temp;
            temp = Random.Range(0, gridObjects.Count);
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

    private void ExtendNonBombIndexes(List<int> nonBombIndexes, int totalRows, int totalCols)
    {
        for (int i = 0; i < totalRows; i++)
        {
            nonBombIndexes.Add(i * totalCols + 0);
            nonBombIndexes.Add(i * totalCols + totalCols - 1);
        }
        for(int j=0;j<totalCols;j++)
        {
            nonBombIndexes.Add(0*totalCols + j);
            nonBombIndexes.Add((totalRows - 1) * totalCols + j);
        }
    }

}