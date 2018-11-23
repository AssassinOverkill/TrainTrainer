using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour {
    #region variables
    public int trackID; //  set in editor
    public GameObject pathA, pathB;
    public Material redMat, untravelledMat; //  redMat = path currently being taken by the train
    public float timeTillTrainMoves = 10.0f;
    #endregion

    private void Start()
    {
        genRandomTime();
    }

    // Update is called once per frame
    void Update () {
        if (timeTillTrainMoves <= 0 && !UIScript.gameOver)
        {
            if (GetComponentInChildren<TrainMovement>().travelPathA)
            {
                for (int i = 0; i < 3; i++)  //  3 because there's only 3 track components
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
        else
        {
            timeTillTrainMoves -= Time.deltaTime;
        }
	}

    public void genRandomTime() { timeTillTrainMoves = Random.Range(5f, 30f); }
}
