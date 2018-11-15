using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    #region variables
    public List<GameObject> obstacles = new List<GameObject>();

    private List<bool> activeObstacles = new List<bool>();  //  keep track of what obstacles are active
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
