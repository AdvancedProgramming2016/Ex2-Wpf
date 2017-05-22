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
    public class SinglePlayerGameModel : ISinglePlayerGame
    {

        private Maze maze;
        private Position playerPosition;
        private ServerListener serverListener;

        public SinglePlayerGameModel()
        {
            TcpClient tcpClient = new TcpClient();
            //this.serverListener = new ServerListener(tcpClient, new StreamReader(tcpClient.GetStream()));
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
                this.NotifyPropertyChanged("Maze");
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
                this.NotifyPropertyChanged("PlayerPosition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
            throw new NotImplementedException();
        }

        public void StartNewGame(String numOfRows, String numOfCols, String nameOfMaze)
        {
            // Get from server the maze.
            //Maze = getFromServer
        } 
    }
}
