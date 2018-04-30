using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //references to the game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;//reference to enemy spawner
    public GameObject GameOverGo;
    public GameObject scoreUITextGo;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start ()
    {
        GMState = GameManagerState.Opening;
	}

    //Function to update the game manager state
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //hide game over screen 
                GameOverGo.SetActive(false);

                //set play button visible
                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                //reset score
                scoreUITextGo.GetComponent<GameScore>().Score = 0;

                //hide play button during gameplay
                playButton.SetActive(false);

                //set player visible and initialise lives
                playerShip.GetComponent<PlayerControl>().Init();

                //start enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                break;

            case GameManagerState.GameOver:

                //stop enemy spawns
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //display game over screen
                GameOverGo.SetActive(true);

                //change game manager state to opening after 8 seconds
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }

    //function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //function to be called by clicking on the play button
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //function to change game manager to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
