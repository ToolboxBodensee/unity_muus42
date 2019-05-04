using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseballSpawner : MonoBehaviour
{
    public GameObject cheeseballPrefab;
    private float startTime;
    
    public int maximum;
    private int howmany;
    
    private static System.Random rnd = new System.Random();
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        maximum = 500;
        howmany = 0;
        
        for(int i=0; i<maximum; i++)
        {
            float rnd1 = rnd.Next(-5, 5);
            float rnd2 = rnd.Next(-5, 5);
            float rnd3 = rnd.Next(0, maximum / 4);
            Vector3 pos = new Vector3(transform.position.x + rnd1, transform.position.y - 1 + rnd3, transform.position.z + rnd2);
            Instantiate(cheeseballPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (howmany == maximum)
            return;
            
        howmany++;
        
        if (howmany % 100 == 0)
            Debug.Log(howmany);
        
        
        //if ((int)((Time.time - startTime) * 1000) % 100 < 20)

    }
}
