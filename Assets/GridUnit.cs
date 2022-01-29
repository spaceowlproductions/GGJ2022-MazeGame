using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridUnit : MonoBehaviour
{
    public bool northWall, eastWall, southWall, westWall;
    public GameObject nWall, eWall, sWall, wWall;

    public GameObject setFloor;

    public enum FloorType { Dirt, Grass, Cobblestone };
    public FloorType floorType;

    public enum WallType { Brush, Brick };
    public FloorType wallType;

    public bool myBool;

    List<GameObject> currentWalls = new List<GameObject>();

    MapGrid mapGrid;

    // Start is called before the first frame update
    void Start()
    {
        mapGrid = GetComponentInParent<MapGrid>();

    }

    // Update is called once per frame
    void Update()
    {
        if (northWall && nWall == null)
        {
            GameObject newWall = Instantiate(mapGrid.nWall, transform);
            nWall = newWall;
        }
        else if(!northWall && nWall != null)
        {
            DestroyImmediate(nWall.gameObject);
            nWall = null;
        }

        if (eastWall && eWall == null)
        {
            GameObject newWall = Instantiate(mapGrid.eWall, transform);
            eWall = newWall;
        }
        else if (!eastWall && eWall != null)
        {
            DestroyImmediate(eWall.gameObject);
            eWall = null;
        }

        if (southWall && sWall == null)
        {
            GameObject newWall = Instantiate(mapGrid.sWall, transform);
            sWall = newWall;
        }
        else if (!southWall && sWall != null)
        {
            DestroyImmediate(sWall.gameObject);
            sWall = null;
        }

        if (westWall && wWall == null)
        {
            GameObject newWall = Instantiate(mapGrid.wWall, transform);
            wWall = newWall;
        }
        else if (!westWall && wWall != null)
        {
            DestroyImmediate(wWall.gameObject);
            wWall = null;
        }

        if(setFloor == null)
        {
            GameObject floor = Instantiate(mapGrid.dirtFloor, transform);
            setFloor = floor;
        }
    }
}
