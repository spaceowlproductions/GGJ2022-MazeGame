using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridUnit : MonoBehaviour
{
    public bool northWall, eastWall, southWall, westWall;
    public GameObject nWall, eWall, sWall, wWall;

    public GameObject setFloor;
    public Material currentMat;

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

        PaintFloor();

    }

    void PaintFloor()
    {
        Material setMat = setFloor.GetComponent<Renderer>().sharedMaterial;

        switch (floorType)
        {
            case FloorType.Dirt:
                if (!northWall && !southWall && eastWall && westWall)
                {
                    setMat = mapGrid.dirtThru;
                }
                else if (northWall && southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.dirtThru;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (northWall && !southWall && eastWall && westWall)
                {
                    setMat = mapGrid.dirtEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.dirtEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && eastWall && westWall)
                {
                    setMat = mapGrid.dirtEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (northWall && southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.dirtEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (northWall && !southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.dirtOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.dirtOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (!northWall && !southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.dirtOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (!northWall && !southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.dirtOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && !southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.dirtCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && !southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.dirtCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.dirtCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (!northWall && southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.dirtCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if(!northWall && !southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.dirtOpen;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                break;

            case FloorType.Cobblestone:
                if (eastWall && westWall && !southWall && !northWall)
                {
                    setMat = mapGrid.cobbleThru;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (northWall && southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.cobbleThru;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                break;
            case FloorType.Grass:
                if (!northWall && !southWall && eastWall && westWall)
                {
                    setMat = mapGrid.grassThru;
                }
                else if (northWall && southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.grassThru;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (northWall && !southWall && eastWall && westWall)
                {
                    setMat = mapGrid.grassEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.grassEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && eastWall && westWall)
                {
                    setMat = mapGrid.grassEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (northWall && southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.grassEnd;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (northWall && !southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.grassOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && !eastWall && !westWall)
                {
                    setMat = mapGrid.grassOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (!northWall && !southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.grassOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (!northWall && !southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.grassOne;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && !southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.grassCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWall && !southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.grassCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if (!northWall && southWall && eastWall && !westWall)
                {
                    setMat = mapGrid.grassCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (!northWall && southWall && !eastWall && westWall)
                {
                    setMat = mapGrid.grassCorner;
                    setFloor.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                break;
        }
        setFloor.GetComponent<Renderer>().material = setMat;
    }
}
