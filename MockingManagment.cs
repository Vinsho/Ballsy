using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MockingManagment : MonoBehaviour
{
    private TextMeshProUGUI mockText;
    private int deathCount = 0;
    private int level = 0;
    public MockingManagment(TextMeshProUGUI newMockText){
        mockText=newMockText;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    public void MockingUpdate()
    {
        deathCount = PlayerPrefs.GetInt("DeathCount");
        level = SceneManager.GetActiveScene().buildIndex-1;
        if(level == 4){
            if(deathCount>20){
                mockText.text = "Judging by your performance, you took quite a lot of them pills.";
            }
            if(deathCount>35){
                mockText.text = "You should really stop taking them pills...";
            }
        }
    }
}
