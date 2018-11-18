using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour {
    #region variables
    public int trackID; //  set in editor
    public bool viewing = false;    //  is the player viewing this currently?
    public GameObject pathA, pathB;
    public Material redMat, untravelledMat; //  redMat = path currently being taken by the train
    #endregion

	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<TrainMovement>().travelPathA)
        {
            for(int i = 0; i < 3; i++)  //  3 because there's only 3 track components
            {
                pathA.transform.GetChild(i).GetComponent<MeshRenderer>().material = redMat;
                pathB.transform.GetChild(i).GetComponent<MeshRenderer>().material = untravelledMat;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)  //  3 because there's only 3 track components
            {
                pathB.transform.GetChild(i).GetComponent<MeshRenderer>().material = redMat;
                pathA.transform.GetChild(i).GetComponent<MeshRenderer>().material = untravelledMat;
            }
        }
	}
}
