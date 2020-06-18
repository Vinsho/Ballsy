using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public GameObject Object;
    private Vector3 startingPosition;
    private Vector3 point;
    private Vector3 moveByVector = new Vector3(4,0,0);
    public bool reverse;
    public bool up;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = Object.transform.position;
        if(reverse && !up){
            moveByVector = new Vector3(-4,0,0);
        }
        if(up){
            if(reverse){
                moveByVector = new Vector3(0,-4,0);
            }else{
                moveByVector = new Vector3(0,4,0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Object.tag == "Floater"){
            if(Object.transform.position == startingPosition){
                point = startingPosition + moveByVector;
            }
            if(Object.transform.position == point){
                point = startingPosition;
            }
            
        }
        if(Object.tag == "Projectile"){
            point = new Vector3(0,startingPosition.y,0);
        }
        Object.transform.position = Vector3.MoveTowards(Object.transform.position,point,speed*Time.deltaTime);
    }
}
