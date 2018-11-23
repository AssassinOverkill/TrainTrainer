using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMovement : MonoBehaviour {
    #region variables
    public Transform[] obstacleSpawn = new Transform[2];  //  points where obstacles will spawn
    public Transform trainStart;
    public List<GameObject> nodes = new List<GameObject>(); //  path A will be even numbers, path B will be odd numbers (excluding 1)
    public float speed;
    public bool travelPathA = false;    //  true means the train will go down path A. false, path B

    private int nodeIndex = 0;  //  index of the next node the train will travel towards
    #endregion

    public void resetGame()
    {
        Debug.Log("Train reached end of the node path!");
        this.transform.position = trainStart.position;
        this.transform.rotation = trainStart.rotation;
        nodeIndex = 0;  //  first node
        GetComponentInParent<TrackScript>().genRandomTime();    //  reset time
        Destroy(GetComponentInParent<ObstacleScript>().obstacleClone);  //  get rid of old obstacle
        GetComponentInParent<ObstacleScript>().genObstacle();   //  generate new one
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIScript.gameOver && GetComponentInParent<TrackScript>().timeTillTrainMoves <= 0f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nodes[nodeIndex].transform.position, Time.deltaTime * speed);
            this.transform.LookAt(nodes[nodeIndex].transform);
            Debug.Log("Current Node Index: " + nodeIndex);

            if (Input.GetKeyDown(KeyCode.E) && nodeIndex == 0 && LevelScript.index == GetComponentInParent<TrackScript>().trackID)
            {
                Debug.Log("Track switched!");
                if (travelPathA)
                {
                    travelPathA = false;
                }
                else
                {
                    travelPathA = true;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.position == nodes[nodeIndex].transform.position)
        {
            if (nodeIndex == nodes.Count - 1 || nodeIndex == nodes.Count - 2)   //  reset track
            {
                Debug.Log("Train reached end of the node path!");
                this.transform.position = trainStart.position;
                this.transform.rotation = trainStart.rotation;
                nodeIndex = 0;  //  first node
                GetComponentInParent<TrackScript>().genRandomTime();    //  reset time
                Destroy(GetComponentInParent<ObstacleScript>().obstacleClone);  //  get rid of old obstacle
                GetComponentInParent<ObstacleScript>().genObstacle();   //  generate new one
                UIScript.numberOfSafeTrains++;   //  increase score
            }
            else
            {
                if (travelPathA && nodeIndex == 0)
                {
                    nodeIndex += 2;
                }
                else if (!travelPathA && nodeIndex == 0)
                {
                    nodeIndex++;
                }
                else if(travelPathA && currentIndexEvenOrOdd())
                {
                    nodeIndex += 2;
                }
                else if(!travelPathA && !currentIndexEvenOrOdd())
                {
                    nodeIndex += 2;
                }
            }           
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            UIScript.gameOver = true;
        }
    }

    //  true means it is even
    private bool currentIndexEvenOrOdd()
    {
        if ((nodeIndex % 2) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}