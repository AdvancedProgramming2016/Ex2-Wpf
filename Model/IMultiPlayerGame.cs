using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MazeLib;

namespace MazeMenu.Model
{
    interface IMultiPlayerGame : INotifyPropertyChanged
    {
        Maze Maze { get; set; }
        Position OpponentPosition { get; set; }
        Position PlayerPosition { get; set; }

        //void JoinGame(Game game);
        void JoinGame();
        void StartNewGame();
        void MovePlayer(Position position);
        void CloseGame();
    }
}
