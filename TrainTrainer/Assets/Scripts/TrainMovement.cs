using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {
    #region variables
    public List<GameObject> nodes = new List<GameObject>(); //  path A will be even numbers, path B will be odd numbers (excluding 1)
    public float speed;
    public bool travelPathA = false;    //  true means the train will go down path A. false, path B
    private int nodeIndex = 0;  //  index of the next node the train will travel towards

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, nodes[nodeIndex].transform.position, Time.deltaTime * speed);
        Debug.Log("Current Node Index: " + nodeIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Train hit node!");
        if (other.gameObject.transform.position == nodes[nodeIndex].transform.position)
        {
            if (nodeIndex == nodes.Count - 1 || nodeIndex == nodes.Count - 2)
            {
                Debug.Log("Train reached end of the node path!");
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
