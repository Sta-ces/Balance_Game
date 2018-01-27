using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public PlayerMovement Gil;
    public PlayerMovement Raphael;
    public int PointsToWin;
    private int GilPoints = 0;
    private int RaphaelPoints = 0;

	// Use this for initialization
	void Start ()

    {
		
	}
	
	// Update is called once per frame
	void Update ()

    {
		if (Gil.Dead)
        {
            RaphaelPoints++;
            if(RaphaelPoints >= PointsToWin)
            {
                Debug.Log("Raphael Wins!");
            }
            else
            SceneManager.LoadScene("Level1");
        }

        if (Raphael.Dead)
        {
            GilPoints++;
            if(GilPoints >= PointsToWin)
            {
                Debug.Log("Gil Wins!");
            }
            SceneManager.LoadScene("Level1");
        }
	}
}
