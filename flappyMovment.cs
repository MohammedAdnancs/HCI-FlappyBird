using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class FlappyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public gameOver Gameover;

    // Socket-related fields
    private TcpClient tcpClient;
    private NetworkStream stream;
    private byte[] data = new byte[1024];  
    //private float moveSpeed = 10f;  
    private bool isConnected = false;

    // Start is called once before the first execution of Update
    async void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(isConnected == false)
        {
            await ConnectToServer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async Task ConnectToServer()
    {
        try
        {
            tcpClient = new TcpClient("MohammedAdnan", 8000);  
            stream = tcpClient.GetStream();
            isConnected = true;
            
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(data, 0, data.Length)) != 0)
            {
                string receivedMessage = Encoding.ASCII.GetString(data, 0, bytesRead);
                Debug.Log("Received from Python: " + receivedMessage);

                
                ProcessReceivedMessage(receivedMessage);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error: " + ex.Message);
        }
    }

    private void ProcessReceivedMessage(string message)
    {
        
        if (float.TryParse(message, out float yPosition))
        {
            
            float screenHeight = Camera.main.orthographicSize * 2;

            float worldYPosition = -(yPosition - 0.5f) * screenHeight;

            rb.position = new Vector2(rb.position.x, worldYPosition);

            Debug.Log("Flappy Y position changed to: " + worldYPosition);
        }
        else
        {
            Debug.LogWarning("Received invalid Y position data.");
        }
    }


    void OnApplicationQuit()
    {
        if (stream != null)
        {
            stream.Close();
        }
        if (tcpClient != null)
        {
            tcpClient.Close();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Gameover.GameOver();
    }
}
