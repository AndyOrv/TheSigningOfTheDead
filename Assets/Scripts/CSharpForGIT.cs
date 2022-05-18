using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class CSharpForGIT : MonoBehaviour
{
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    Vector3 receivedPos = Vector3.zero;

    bool running;
    private string msgGrab;
    protected string controllerInput;
    public GameObject[] zombies;

    private void Update()
    {
        transform.position = receivedPos; //assigning receivedPos in SendAndReceiveData()

        ManualControllerInputs();
        grabMessage();
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();

        zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    //recieve messages from python
    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }
    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string

        if (dataReceived != null)
        {
            //---Using received data---
            //receivedPos = StringToVector3(dataReceived); //<-- assigning receivedPos value from Python
            Debug.Log("received python data, " + "'"+ dataReceived + "'"); //debug stuff
            msgGrab = dataReceived;

            //---Sending Data to Host----
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
    }

    void ManualControllerInputs()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            print("M");
            SetInput("Hello");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            print("N");
            SetInput("I Love You");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            print("B");
            SetInput("Thank You");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            print("V");
            SetInput("Yes");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            print("C");
            SetInput("No");
        }
    }

    void grabMessage()
    {
        if (msgGrab != null)
        {
            SetInput(msgGrab);
            msgGrab = null;
        }
    }

    public void SendControlMessage(string control)
    {
        zombies = null;
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombieChar in zombies)
        {
            zombieChar.SendMessage("RecieveInput", control);
        }
    }

    void SetInput(string control)
    {

        controllerInput = control;
        SendControlMessage(controllerInput);
        //print(controllerInput);
    }
}