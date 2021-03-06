﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {
    #region variables
    public Camera cam;
    public GameObject[] tracks = new GameObject[6];
    public List<GameObject> cameraSpawns = new List<GameObject>();
    public static int index = 0;
    #endregion

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) && UIScript.gameOver)
        {
            for (int i = 0; i < 6; i++)
            {
                tracks[i].GetComponentInChildren<TrainMovement>().resetGame();
                UIScript.numberOfSafeTrains = 0;
                UIScript.gameOver = false;
                UIScript.centerScreenActive = false;
            }
        }
        else
        {
            index = GameObject.Find("World").GetComponent<ArduinoInputManager>().input;
            GameObject.Find("Main Camera").transform.position = cameraSpawns[index].transform.position;
        }
	}
}
