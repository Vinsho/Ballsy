using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField]
    private GameObject collumn;
    [SerializeField]
        private GameObject end;
    public int currentLevel;

    // Start is called before the first frame update
    //              {0,1,2,3,4,5,6,7,8,9}
    float[] level1 ={2,2,3,4,4};
    float last_x=8;
    void Start()
    //generate random level for endless mode
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i<50; i++)
        {
            CreateCollumn(last_x, 2);
            last_x = last_x + rnd.Next(2,5);
        }
    }
    

    // Update is called once per frame
    private void CreateCollumn(float x,float y)
    {
        Instantiate(collumn, new Vector3(x, y,0), Quaternion.identity);
    }
    private void CreateEnd(float x,float y)
    {
        Instantiate(end, new Vector3(x, y,0), Quaternion.identity);
    }

}
