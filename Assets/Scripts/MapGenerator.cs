using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int mapWidth = 5;
    [SerializeField] int mapHeight = 5;
    [SerializeField] Vector3 offset;

    public GameObject[,] allTiles = new GameObject[5, 5];

    public GameObject pathPrefab;
    public GameObject nodePrefab;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; i < mapHeight; j++)
            {
                GameObject node = (GameObject)Instantiate(nodePrefab, transform.position + offset, transform.rotation);
            }
        }

        //// Fill map with other tiles
        //for (int i = 0; i < allTiles.Length; i++)
        //{
        //    for (int j = 0; j < allTiles.Length; j++)
        //    {
        //        GameObject other = Instantiate(otherTile);
        //        other.transform.position = new Vector2(i, j);
        //    }
        //}
    
        //var dir = 0; // direction create til road 0 - up, 1 - down, 2 - left, 3 - right
        //dir = Random.Range(0, 4);
 
        // var pos = Vector2.zero;
 
        // // For example create only 5 tiles
        // for(int i = 0; i < 5; i++) 
        // {
        //     switch(dir) 
        //     {
        //             case 0:
        //             pos.y+= 1;
        //             break;

        //             case 1:
        //             pos.y-= 1;
        //             break;

        //             case 2:
        //             pos.x= 1;
        //             break;

        //             case 3:
        //             pos.x+= 1;
        //             break;
        //     }

        //     GameObject other = Instantiate(tileRoad);
        //     pos.y+= 1;
        //     other.transform.position = new Vector2(pos.x, pos.y);
         }
}
