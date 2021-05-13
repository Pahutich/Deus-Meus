using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public TileType[] tileTypes;

    int[,] tiles;

    //Normally, coords are x and y but technically for Unity it is x and z, so I will be using sometimes y and sometimes z for 2nd coord
    //Sizes are often double because the position itself requires to be double
    double mapSizeX = 10;
    double mapSizeY = 10;

    void Start()
    {
        GenerateMapData();
        GenerateMapVisual();
    }

    private void GenerateMapData()
    {
        tiles = new int[Convert.ToInt32(mapSizeX), Convert.ToInt32(mapSizeY)];

        double x, z;

        //build grass
        for ( x = 0; x < mapSizeX; x+=1)
        {
            for (z = 0; z < mapSizeY; z+=1)
            {
                tiles[Convert.ToInt32(x), Convert.ToInt32(z)] = 0;
                
            }
            
        }

        //build swamps
        for (x = 3; x <= 5; x += 1)
        {
            for (z = 0; z < 4; z += 1)
            {
                tiles[Convert.ToInt32(x), Convert.ToInt32(z)] = 1;
            }
        }

        //build mountains
        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        tiles[3, 5] = 2;
        tiles[4, 6] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;
    }

    void GenerateMapVisual()
    {
        //to stack tiles by z axis correctly
        float zpos = 0f;
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeY; z++, zpos+=0.2f)
            {
                TileType tt = tileTypes[tiles[x, z]];

                //every second row of tiles is shifted because of hex tiles
                GameObject go;
                 if (z % 2 > 0)
                 {
                    //Spawning an actual tile
                    go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x + 0.5f, 0, z - 0.2f * z), Quaternion.identity);
                }
                 else
                {
                    //Spawning an actual tile
                    go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, 0, z - 0.2f * z), Quaternion.identity);
                }
                 //Giving coordinates to a new spawned tile
                Tile tile = go.GetComponent<Tile>();
                tile.tileX = x;
                tile.tileY = z;
            }
        }
    }
    void Update()
    {
        
    }
}
