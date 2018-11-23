using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    #region variables
    public List<GameObject> obstacles = new List<GameObject>();
    public float obstacleInterval;  //  every how many seconds until next obstacle
    public GameObject obstacleClone;

    private List<bool> activeObstacles = new List<bool>();  //  keep track of what obstacles are active  
    private int whichTrack = 0; //  0 for initialization
    private float t = 0.0f; //  time until next obstacle spawns
    #endregion

    // Use this for initialization
    void Start () {
        genObstacle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void genObstacle()
    {
        int num = Random.Range(0, this.transform.Find("Train").GetComponent<TrainMovement>().obstacleSpawn.Length);
        Debug.Log("Obstacle Index: " + num);
        obstacleClone = Instantiate(obstacles[0], this.transform.Find("Train").GetComponent<TrainMovement>().obstacleSpawn[num]);
    }
}
