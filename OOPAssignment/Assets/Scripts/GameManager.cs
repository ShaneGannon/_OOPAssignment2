using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference to the game objects
    public GameObject playButton;
    public GameObject playerShip;

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

                break;

            case GameManagerState.Gameplay:

                break;

            case GameManagerState.GameOver:

                break;
        }
    }

    //function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
}
