﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MazeLib;

namespace MazeMenu.Model
{
    public interface ISinglePlayerGame : INotifyPropertyChanged
    {
        Maze Maze { get; set; }
        Position PlayerPosition { get; set; }
        
        void StartNewGame();
        void MovePlayer();
        void SolveMaze();
        void Restart();

    }
}
