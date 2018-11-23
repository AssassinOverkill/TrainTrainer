using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInputManager : MonoBehaviour {

    SerialPort sp = new SerialPort("COM6", 9600);
    public int input;

    // Use this for initialization
    void Start () {
        sp.Open();
        sp.ReadTimeout = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (sp.IsOpen)
        {
            try
            {
                WriteToSerial(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
    }

    void WriteToSerial (int Value)
    {
        input = Value;
    }
}
