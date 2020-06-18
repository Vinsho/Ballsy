using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class ProgressManager : MonoBehaviour

{
    public int maxLvl;
    public double highScore;
    public void Start(){
        maxLvl = PlayerPrefs.GetInt("lvl");
        highScore = PlayerPrefs.GetFloat("highScore");
        highScore = System.Math.Round(highScore,2);
    }

    public void SaveProgress(int lvl){
        if(lvl>maxLvl && SceneManager.sceneCountInBuildSettings>lvl){
            PlayerPrefs.SetInt("lvl",lvl);
        }
    }

    public int LoadProgress(){
        return maxLvl;
    }
    public void saveHighScore(float highScore){
        PlayerPrefs.SetFloat("highScore",highScore);
    }

    public double loadHighScore(){
        return highScore;
    }
    
}
