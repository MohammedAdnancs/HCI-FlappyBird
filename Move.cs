using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Move : MonoBehaviour
{
    public float speed = 5.0f;
    //string serverAddress = "MohammedAdnan";
    //int port = 8000;
    //private TcpClient client;
    //pr//ivate NetworkStream stream;
    //private bool isListening = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    
}
