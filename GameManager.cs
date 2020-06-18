using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;



public class GameManager : MonoBehaviour
{
    private int currentLvl;
    [SerializeField]
    private GameObject lvlButton;
    [SerializeField]
    private GameObject lvlSelectMenu;
    ProgressManager progress = new ProgressManager();
    
    public void Start(){
        progress.Start();
    }
    public void tryAgain(){  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount")+1);
    }

    public void loadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex!=SceneManager.sceneCountInBuildSettings-1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("DeathCount",0);
        }
    }

    public void EndlessMode(){
        SceneManager.LoadScene(1);
    }

    public void loadMenu(){
        SceneManager.LoadScene(0);
    }

    public void loadLevels(){
        PlayerPrefs.SetInt("DeathCount",0);
        if(progress.LoadProgress()==0){
            SceneManager.LoadScene(2);
        }
        else{
            lvlSelectMenu.SetActive(true);
            int y = 140;
            int x = -420;
            for(int i = 1; i<progress.LoadProgress() ;i++){
                if(i%7==0){
                    y-=70;
                    x = -420;
                }
                x += 70;
                
                GameObject obj = Instantiate(lvlButton,new Vector3(x,y,0),Quaternion.identity);
                Button button = obj.GetComponent<Button>();
                button.transform.SetParent(lvlSelectMenu.transform,false); 
                button.GetComponentInChildren<TextMeshProUGUI>().text=(i).ToString();  
                button.onClick.AddListener(delegate{SceneManager.LoadScene(Int32.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text)+1);});
            }
        }
        
    }

    public void quitGame(){
        Application.Quit();
    }
    
}

