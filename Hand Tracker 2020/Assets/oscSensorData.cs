using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC; // https://github.com/jorgegarcia/UnityOSC


public class oscSensorData : MonoBehaviour
{

    private OSCReciever reciever;

    public int port = 7779;

    private float movementSpeed = 5f;

    [SerializeField] ParticleSystem magicDust;

    // Use this for initialization
    void Start()
    {
        reciever = new OSCReciever();
        reciever.Open(port);
        magicDust.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        if (reciever.hasWaitingMessages())
        {
            OSCMessage msg = reciever.getNextMessage();
            string message = DataToString(msg.Data);
            //Debug.Log(string.Format("message received: {0} {1}", msg.Address, message));
            int messageInt = int.Parse(message);
          
            if (messageInt < 255)
            {
				Debug.Log(messageInt);
				magicDust.Play(); 
            }
            else
            {
				magicDust.Stop();
            }

        }
    }

    private string DataToString(List<object> data)
    {
        string buffer = "";

        for (int i = 0; i < data.Count; i++)
        {
            buffer += data[i].ToString() + " ";
        }

        buffer += "\n";

        return buffer;
    }
}
