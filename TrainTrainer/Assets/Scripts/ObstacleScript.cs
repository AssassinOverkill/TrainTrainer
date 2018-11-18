using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    #region variables
    public List<GameObject> obstacles = new List<GameObject>();
    public float obstacleInterval;  //  every how many seconds until next obstacle

    private List<bool> activeObstacles = new List<bool>();  //  keep track of what obstacles are active
    private GameObject obstacleClone;
    private int whichTrack = 0; //  0 for initialization
    private float t = 0.0f; //  time until next obstacle spawns
    #endregion

    // Use this for initialization
    void Start () {
        obstacleClone = Instantiate(obstacles[0], this.transform.Find("Train").GetComponent<TrainMovement>().obstacleSpawn[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
