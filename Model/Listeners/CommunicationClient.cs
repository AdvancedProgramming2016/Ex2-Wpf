using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeMenu.Model.Listeners
{
    /// <summary>
    /// Handles communication with the server.
    /// </summary>
    public class CommunicationClient : IClientConnection
    {
        private int port;
        private string ip;
        private IPEndPoint endPoint;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
      private bool isMultiplayer;
        private bool isConnected;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CommunicationClient()
        {
            //Initialize variables.
            tcpClient = null;
            stream = null;
            reader = null;
            writer = null;
            ServerListener = null;
            isMultiplayer = false;
            isConnected = false;
        }

        public IListener ServerListener { get; set; }

        public void Connect(int port, string ip)
        {
            this.port = port;
            this.ip = ip;
            endPoint = new IPEndPoint(IPAddress.Parse(this.ip), this.port);
        }

        public void SendToServer(string command)
        {
            //If not connected, Initialize connection.
            if (!isConnected || ServerListener.IsMultiplayer == false)
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(endPoint);
                stream = tcpClient.GetStream();
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);
                isConnected = true;
                ServerListener = new ServerListener(tcpClient, reader);

                //start listener
                ServerListener.StartListening();
            }

            //CommunicateWithServer with server.
            try
            {
                string[] splitCommand = command.Split(' ');

                //Check if the connection needs to remain open.
                if (splitCommand[0] == "start" ||
                    splitCommand[0] == "join")
                {
                    isMultiplayer = true;
                    ServerListener.IsMultiplayer = true;
                }

                //Send message to server.
                writer.Write(command + '\n');
                writer.Flush();

                //Check if connection can be closed.
                if (!isMultiplayer ||
                    (splitCommand[0] == "close" && splitCommand.Length == 2))
                {
                    isMultiplayer = false;
                    ServerListener.IsMultiplayer = false;

                    //Wait for listener to end.
                    ServerListener.WaitForTask();
                    stream.Close();
                    tcpClient.Close();
                    isConnected = false;
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}