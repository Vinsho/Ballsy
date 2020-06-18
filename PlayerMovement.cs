using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform groundCheck;
    public float startTime,groundCheckRadius,touchTime = 0;
    public LayerMask whatIsGround;
    private bool onGround, firstClick,clicked;
    public Sprite defaultSprite,clickedSprite,  clickedSprite2,clickedSprite3;
    public SpriteRenderer spRend;
    public bool helpJump = false;
    public double helpCount = 0;
    protected ProgressManager progress = new ProgressManager();
    protected bool movinPermission = true;
    [SerializeField]
    protected GameObject deathMenu;
    [SerializeField]
    protected GameObject helpJumpParticles;   
    protected PlayerManagment playerMng;
    protected void Start()
    {
        progress.Start();
        playerBody = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = defaultSprite;
        // playerMng = new PlayerManagment(playerBody,this);
    }
    // public void OnGUI() {
    //     playerMng.DoGUI();
    // }
    
 
    // Update is called once per frame
    protected void Update()
    {
        if(movinPermission){
            playerBody.velocity = new Vector2(4, playerBody.velocity.y);
        }else{
            playerBody.velocity = new Vector2(0, playerBody.velocity.y);

        }
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(clicked){
            touchTime = Time.time - startTime;
        }
        if(touchTime>1){
            spRend.sprite = clickedSprite3;
        }
        else if(touchTime>0.5){
            spRend.sprite = clickedSprite2;
        }
        else if(touchTime>0.01){
            spRend.sprite = clickedSprite;
        }
        //start timer after touch
        if (Input.GetMouseButtonDown(0))
        {
            firstClick = true;
            clicked = true;
            startTime = Time.time;
            spRend.sprite = defaultSprite;
            
        }
        //when finger is released add force
        if(Input.GetMouseButtonUp(0)&&firstClick)
            {
                clicked = false;
                if(touchTime > 1.0){ 
                    touchTime = 1;
                }
                if (onGround)
                    playerBody.AddForce(new Vector2(0, touchTime * 12), ForceMode2D.Impulse);
                else if(helpJump){
                    float tmp = 12.0f * touchTime;
                    // if(playerBody.velocity.y<1.0){
                    //     tmp = touchTime*10.0f;
                    // }
                    
                    playerBody.velocity = new Vector2(4, tmp);
                    helpJump = false;
                    helpJumpParticles.SetActive(false);
                    helpCount = playerBody.position.x;
                }
                
            }

        
        
        
    }
}
