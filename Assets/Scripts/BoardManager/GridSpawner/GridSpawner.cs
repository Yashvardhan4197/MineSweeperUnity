using System.Collections.Generic;
using UnityEngine;

public class GridSpawner
{

    private int rows;
    private int col;
    private float gridprefabWidth;
    private float spacing = 2f;
    private float gridprefabHeight;
    private List<GridObject> gridObjects = new List<GridObject>();
    private GameObject gridPrefab;
    private Vector2 startPos;
    private RectTransform parentTransform;

    public GridSpawner(GameObject gridPrefab, int rows, int cols,float spacing)
    {
        this.gridPrefab = gridPrefab;
        this.rows = rows;
        this.col = cols;
        this.spacing = spacing;
    }

    public List<GridObject> SpawnGrid()
    {
        gridprefabHeight = gridPrefab.GetComponent<RectTransform>().rect.height;
        gridprefabWidth = gridPrefab.GetComponent<RectTransform>().rect.width;
        for (int i=0;i<rows;i++)
        {
            for(int j=0;j<col;j++)
            {
                Vector3 newPos = new Vector3(startPos.x + (j * (gridprefabWidth+spacing)), startPos.y - (i * (gridprefabHeight+spacing)),0);
                GridObject newObj = Object.Instantiate<GridObject>(gridPrefab.GetComponent<GridObject>(),newPos,gridPrefab.gameObject.transform.rotation);
                gridObjects.Add(newObj);
                newObj.gameObject.transform.SetParent(parentTransform);
            }
        }
        return gridObjects;
    }

    public void SetTransform(Vector3 newStartPos,RectTransform parentTransform)
    {
        this.parentTransform=parentTransform;
        startPos= newStartPos;
    }
}
