using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{

    public GameObject tile;


    TileScript[,] tileArray = new TileScript[10, 10];


    TileScript SelectedTile;

    // Use this for initialization
    void Start()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                GameObject spawnedTile = (GameObject)Instantiate(tile, new Vector3(i * 1.1f, 0, j * 1.1f), Quaternion.identity);
                tileArray[i + 5, j + 5] = spawnedTile.GetComponent<TileScript>();
            }
        }
        AStar.FindPath(tileArray, new Vector2(0, 0), new Vector2(5, 5));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (tileArray[i, j] != SelectedTile)
                    tileArray[i, j].tileType = TileType.Default;
            }
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.Log(ray.direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40))
        {
            if (hit.collider.gameObject.name.Contains("Tile"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (SelectedTile)
                        SelectedTile.tileType = TileType.Default;
                    SelectedTile = hit.collider.gameObject.GetComponent<TileScript>();
                    SelectedTile.tileType = TileType.Selected;
                }
                else
                {
                    if (hit.collider.gameObject.GetComponent<TileScript>() != SelectedTile)
                        hit.collider.gameObject.GetComponent<TileScript>().tileType = TileType.Hovered;
                }
            }
        }
    }
}
