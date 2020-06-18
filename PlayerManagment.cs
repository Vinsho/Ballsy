using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private float barDisplay; //current progress
    private Vector2 pos = new Vector2(5,5);
    private Vector2 size = new Vector2(100,50);
    public Texture2D emptyTex;
    public Texture2D fullTex = (Texture2D)Resources.Load("helpBar");
    private PlayerMovement playerMovement; 
     public PlayerManagment(Rigidbody2D square, PlayerMovement player){
        playerBody = square;
        playerMovement = player;
     }
    public void DoGUI() {
        // GUI.Box(new Rect(0,0,200,100),emptyTex);
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
         
        //draw the filled-in part:
                GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
                    
                    GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
                GUI.EndGroup();
        GUI.EndGroup();
     }

    // Update is called once per frame
    public void DoUpdate()
    {
        //update help jump loading bar
        if(playerMovement.helpJump){
            barDisplay=1.0f;
        }else{
            barDisplay = (float)((playerBody.position.x-playerMovement.helpCount) * 0.05);
        }
        
        
    }
}
