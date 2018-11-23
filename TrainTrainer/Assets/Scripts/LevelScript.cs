using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {
    #region variables
    public Camera cam;
    public List<GameObject> cameraSpawns = new List<GameObject>();
    public static int index = 0;

    private int numberOfSafeTrains = 0; //  how many trains safely made it by
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if(index < cameraSpawns.Count - 1) { index++; }           
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (index > 0) { index--; }
        }

        GameObject.Find("Main Camera").transform.position = cameraSpawns[index].transform.position;
	}
}
