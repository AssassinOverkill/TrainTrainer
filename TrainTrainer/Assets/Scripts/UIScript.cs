using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    #region variables
    public static bool centerScreenActive = false;
    public static bool gameOver = false;    //  did the player fail to stop a train?
    public static int numberOfSafeTrains = 0; //  how many trains safely made it by

    #endregion

	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            centerScreenActive = true;
            this.transform.GetChild(0).GetComponent<Text>().text = "You Failed! \n Press R to restart!";
            this.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        }
        else
        {
            this.transform.GetChild(1).GetComponent<Text>().text = "Score: " + numberOfSafeTrains;
            this.transform.GetChild(2).GetComponent<Text>().text = "Track #" + (LevelScript.index + 1);

            if (!centerScreenActive)
            {
                this.transform.GetChild(0).GetComponent<Text>().text = "";
            }
        }
	}
}
