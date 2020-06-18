using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessMovement : PlayerMovement
{
    [SerializeField]
    private TextMeshProUGUI m_Score;
    [SerializeField]
    private TextMeshProUGUI m_HighScore;
    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        m_HighScore.text=progress.loadHighScore().ToString();
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if(!helpJump&&(playerBody.position.x>helpCount+20)){//helpJump every 20 seconds
            helpJump = true;
            helpJumpParticles.SetActive(true);
        }
        base.Update();
        m_Score.text = System.Math.Round(playerBody.position.x,2).ToString();
        if (playerBody.position.y < 1)
        {
            playerBody.Sleep();
            if(progress.loadHighScore() < playerBody.position.x){ //saves new highscore if its higher
                progress.saveHighScore((float)playerBody.position.x);
                m_HighScore.text=progress.loadHighScore().ToString();
            }
            deathMenu.SetActive(true);
            
        }
    }
}
