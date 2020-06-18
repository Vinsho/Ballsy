using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StoryMovement : PlayerMovement
{
    [SerializeField]
    protected GameObject endMenu;
    private bool freeze = false;
    [SerializeField]
    protected TextMeshProUGUI mockText;
    public GameObject deathParticles;
    
    // Start is called before the first frame update
    [SerializeField]
    private int deathCount = 0 ;

    private MockingManagment mocker;
    void Start()
    {
        base.Start();
        mocker = new MockingManagment(mockText);
        mocker.MockingUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        mocker.MockingUpdate();
        if (playerBody.position.y < 1)
        {
            playerBody.Sleep();
            deathMenu.SetActive(true);
        }else{
            if(freeze){
                playerBody.Sleep(); 
            }
            base.Update();
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks for a match with the specified name on any GameObject that collides with GameObject
        if (collision.gameObject.tag == "Finish")
        {
            progress.SaveProgress((SceneManager.GetActiveScene().buildIndex+1));
            endMenu.SetActive(true);
            freeze=true;
        }
        if (collision.gameObject.tag == "Floater"){
            movinPermission=false;
            playerBody.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Projectile"){
            deathMenu.SetActive(true);
            deathParticles.SetActive(true);
            movinPermission= false;
        }
        
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        //freeze when player touches floater
        if (collisionInfo.gameObject.tag == "Floater"){
            movinPermission=true;
            playerBody.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //set helpjump to true after picking up blue pill
        if(other.gameObject.tag == "HelpJump"){
            base.helpJump = true;
            base.helpJumpParticles.SetActive(true);
            Destroy(other.gameObject);
        }
        //resize player after picking up redpill
        if(other.gameObject.tag == "RedPill"){
            if(playerBody.transform.localScale.x==1){
                playerBody.transform.localScale -= new Vector3(0.5f,0.5f,0);
            }
            else{
                playerBody.transform.localScale += new Vector3(0.5f,0.5f,0);
            }
            //remove picked up object
            Destroy(other.gameObject);
        }
    }
}
