using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }

        set
        {
            this.score = value;
            UpdateScoreUI();
        }
    }

	// Use this for initialization
	void Start ()
    {
        //get the text ui component of this game object
        scoreTextUI = GetComponent<Text>();
	}
	
    //function to update score ui
    void UpdateScoreUI()
    {
        string scoreStr = string.Format("{0:00000}", score);
        scoreTextUI.text = scoreStr;
    }
}
