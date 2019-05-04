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

    // Start is called before the first frame update
    void Start()
    {
        TextAsset txt = (TextAsset)Resources.Load("level1", typeof(TextAsset));  
        string[] lines = txt.text.Split('\n');

        int.TryParse(lines[0], out levelwidth);
        int.TryParse(lines[1], out levelheight);
        int.TryParse(lines[2], out numfloors);
        
        Debug.Log("" + levelwidth + " " + levelheight + " " + numfloors);
        
        for(int y=0; y<numfloors; y++)
        {
            for(int z=0; z<levelheight; z++)
            {
                for(int x=0; x<levelwidth; x++)
                {
                    string tileline = lines[y * (levelheight + 1) + 4 + z];
                    char tile = tileline[x];
                    
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
