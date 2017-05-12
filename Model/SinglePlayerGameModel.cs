using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeMenu.Model;
using GameClient;
using System.Net.Sockets;
using System.IO;

namespace MazeMenu.Model
{
    class SinglePlayerGameModel : ISinglePlayerGame
    {

        private Maze maze;
        private Position playerPosition;
        private ServerListener serverListener;

        public SinglePlayerGameModel()
        {
            TcpClient tcpClient = new TcpClient();
            this.serverListener = new ServerListener(tcpClient, new StreamReader(tcpClient.GetStream()));
        }

        public Maze Maze
        {
            get
            {
                return this.maze;
            }

            set
            {
                this.maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public Position PlayerPosition
        {
            get
            {
                return this.playerPosition;
            }

            set
            {
                this.playerPosition = value;
                NotifyPropertyChanged("PlayerPosition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void MovePlayer()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void SolveMaze()
        {
            "solve";
        }

        public void StartNewGame()
        {

            //End point initialization.
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            string ip = ConfigurationManager.AppSettings["ip"];
            IPEndPoint endPoint =
                new IPEndPoint(IPAddress.Parse(ip), port);

            //Vatiables declaration.
            TcpClient tcpClient = null;
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            IListener serverListener = null;
            bool isMultiplayer = false;
            bool isConnected = false;

            //Loop while client is on.
            while (true)
            {
                string command = string.Empty;

                Console.WriteLine("Enter a command");

                command = Console.ReadLine();

                //If not connected, Initialize connection.
                if (!isConnected || serverListener.IsMultiplayer == false)
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(endPoint);
                    stream = tcpClient.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                    isConnected = true;
                    serverListener = new ServerListener(tcpClient, reader);

                    //start listener
                    serverListener.StartListening();
                }

                //Communicate with server.
                try
                {
                    string[] splitCommand = command.Split(' ');

                    //Check if the connection needs to remain open.
                    if (splitCommand[0] == "start" ||
                        splitCommand[0] == "join")
                    {
                        isMultiplayer = true;
                        serverListener.IsMultiplayer = true;
                    }

                    //Send message to server.
                    writer.Write(command + '\n');
                    writer.Flush();


                    //Check if connection can be closed.
                    if (!isMultiplayer ||
                        (splitCommand[0] == "close" && splitCommand.Length == 2))
                    {
                        isMultiplayer = false;
                        serverListener.IsMultiplayer = false;

                        //Wait for listener to end.
                        serverListener.WaitForTask();
                        stream.Close();
                        tcpClient.Close();
                        isConnected = false;
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }

        }
    }
}
