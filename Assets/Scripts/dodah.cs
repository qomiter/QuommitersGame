using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dodah : MonoBehaviour
{
    public static int gameScore = 0;
    public static int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);


    }

    // Update is called once per frame
    void Update()
    {
        if (gameScore > highScore)
        {
            highScore = gameScore;
        }
            
        if(gameScore <= -1){
            SceneManager.LoadScene(0);
        }
        
    }
    public void OnGUI(){ 
        GUI.Box (new Rect (20, 20, 200,20), "Score: "+ gameScore.ToString());
        GUI.Box(new Rect(20, 40, 200, 20), "High Score: " + highScore.ToString());

    }
}
