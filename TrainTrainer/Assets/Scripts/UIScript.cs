using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    #region variables
    public static bool centerScreenActive = false;
    public static bool gameOver = false;    //  did the player fail to stop a train?

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            centerScreenActive = true;
            this.transform.GetChild(0).GetComponent<Text>().text = "You Failed!";
            this.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        }
	}
}
