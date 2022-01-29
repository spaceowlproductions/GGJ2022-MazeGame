using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapGrid : MonoBehaviour
{
    public GameObject nWall, eWall, sWall, wWall;

    public GameObject dirtFloor;

    public GameObject gridUnit;
    public GameObject row;

    List<GameObject> TileRow = new List<GameObject>();

    public Vector2 gridSize;

    public bool mapBuilt;
    public bool buildMap;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(buildMap)
        {
            if(!mapBuilt)
            {
                BuildGrid();
                mapBuilt = true;
            }
        }
    }

    void BuildGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            GameObject newRow = Instantiate(row, transform);
            newRow.transform.position = new Vector3(x * 10, 0, 0);

            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject newTile = Instantiate(gridUnit, newRow.transform);
                newTile.transform.localPosition = new Vector3(0, 0, y * 10);
                TileRow.Add(newTile);
            }
        }
    }
}
