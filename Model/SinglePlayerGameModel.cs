﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeMenu.Model;
using System.Net.Sockets;
using System.IO;
using MazeMenu.Model.Listeners;
using MazeMenu.Model.Parsers;

namespace MazeMenu.Model
{
    public class SinglePlayerGameModel : ISinglePlayerGame
    {
        private Maze maze;
        // private Position playerPosition;

        private CommunicationClient communicationClient;
        //private ServerListener serverListener;

        public SinglePlayerGameModel()
        {
            string resultCommand;
            communicationClient = new CommunicationClient();
            //TODO get ip and port from Settings
            communicationClient.Connect(8000, "127.0.0.1");

            communicationClient.PropertyChanged +=
                delegate(Object sender, PropertyChangedEventArgs e)
                {
                    ServerResponse = communicationClient.CommandFromUser;
                };
            //  TcpClient tcpClient = new TcpClient();
            //  this.serverListener = new ServerListener(tcpClient, new StreamReader(tcpClient.GetStream()));
        }

        public string ServerResponse { get; set; }

        public string CommandPropertyChanged { get; set; }

        public Maze Maze
        {
            get { return this.maze; }

            set
            {
                this.maze = value;
                this.NotifyPropertyChanged("Maze");
            }
        }

        public String NameOfMaze { get; set; }

        /* public Position PlayerPosition
         {
             get { return this.playerPosition; }
 
             set
             {
                 this.playerPosition = value;
                 this.NotifyPropertyChanged("PlayerPosition");
             }
         }*/

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propName));
        }

        /* public void MovePlayer()
         {
             throw new NotImplementedException();
         }*/

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void SolveMaze()
        {
            throw new NotImplementedException();
        }

        public void GenerateGame(String numOfRows, String numOfCols,
            String nameOfMaze)
        {
            string command;

            //Parse into the right format.
            command = CommandParser.ParseToGenerateCommand(nameOfMaze,
                numOfRows,
                numOfCols);

            CommandPropertyChanged = "generate";

            //Send command to the server.
            communicationClient.SendToServer(command);

            HandleServerResult(ServerResponse);
            //string generateResult;

            /* communicationClient.ServerListener.PropertyChanged +=
                 delegate(Object sender, PropertyChangedEventArgs e)
                 {
                     //TODO the xaml gives only rows and name, columns missing
                     generateResult = communicationClient.ServerListener.Command;
 
                     maze = Maze.FromJSON(generateResult);
                 };*/
        }

        private void HandleServerResult(string command)
        {
            if (command.StartsWith("Error"))
            {
                //Handle error
            }

            switch (CommandPropertyChanged)
            {
                case "generate":
                    HandleGenerateCommand(command);
                    break;

                case "solve":
                    //HandleSolveCommand(command);
                    break;
            }
        }

        private void HandleGenerateCommand(string command)
        {
            Maze maze = Maze.FromJSON(command);
            Maze = maze;
        }
    }
}