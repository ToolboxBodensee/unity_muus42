using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public Vector3 offset;
    public int tilesize = 4;

    private int levelwidth = 8;
    private int levelheight = 8;
    private int numfloors = 4;
    
    private char[,,] level = { { {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'} },

                                 { {'#', '#', ' ', '#', '#', '#', '#', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', '#', '#', '#', '#', ' ', '#'},
                                   {'#', ' ', '#', '#', ' ', '#', ' ', '#'},
                                   {'#', ' ', '#', ' ', ' ', '#', ' ', '#'},
                                   {'#', ' ', '#', '#', ' ', '#', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'} },

                                 { {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', ' ', ' ', ' ', ' ', '#', '#'},
                                   {'#', '#', ' ', ' ', ' ', ' ', '#', '#'},
                                   {'#', '#', ' ', ' ', ' ', ' ', '#', '#'},
                                   {'#', '#', ' ', ' ', ' ', ' ', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'} },

                                 { {'#', '#', '#', '#', '#', '#', '#', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                                   {'#', '#', '#', '#', '#', '#', '#', '#'} } };

    // Start is called before the first frame update
    void Start()
    {
        for(int y=0; y<numfloors; y++)
        {
            for(int z=0; z<levelheight; z++)
            {
                for(int x=0; x<levelwidth; x++)
                {
                    char tile = level[y,x,z];
                    Vector3 pos = new Vector3(offset.x + x * tilesize, offset.y + y * tilesize, offset.z + z * tilesize);
                    
                    switch(tile)
                    {
                    case '#':
                        Instantiate(wallPrefab, pos, Quaternion.identity);       
                        break;
                    }
                }
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
