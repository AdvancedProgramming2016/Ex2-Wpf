using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeMenu.Model;
using MazeLib;

namespace MazeMenu.ViewModel
{
    public class SinglePlayerGameViewModel : INotifyPropertyChanged
    {

        private ISinglePlayerGame spModel;
        private ISettingsModel settingsModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public String VM_Maze
        {
            get
            {
                return this.spModel.Maze.ToString().Replace("\r\n", "").Replace("*", "0");
            }
        }

        public int VM_DefaultAlgorithm
        {
            get
            {
                return this.settingsModel.DefaultAlgo;
            }
        }

        public String VM_InitialPostion
        {
            get
            {
                return this.spModel.Maze.InitialPos.ToString();
            }
        }

        public String VM_DestPosition
        {
            get
            {
                return this.spModel.Maze.GoalPos.ToString();
            }
        }

        public String VM_PlayerPosition
        {
            get
            {
                return this.spModel.PlayerPosition.ToString();
            }
        }

        public int VM_Rows
        {
            get
            {
                return this.spModel.Maze.Rows;
            }
        }

        public int VM_Cols
        {
            get
            {
                return this.spModel.Maze.Cols;
            }
        }

        public String VM_MazeName
        {
            get
            {
                return this.spModel.Maze.Name;
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public SinglePlayerGameViewModel(ISinglePlayerGame spModel, ISettingsModel settingsModel)
        {
            this.spModel = spModel;
            this.settingsModel = settingsModel;

            this.spModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) 
            { NotifyPropertyChanged("VM_" + e.PropertyName); };
        }

        public void MovePlayer()
        {
            this.spModel.MovePlayer();
        }

        public void Restart()
        {
            this.spModel.Restart();
        }

        public void SolveMaze()
        {
            this.spModel.SolveMaze();
        }

        public void StartNewGame(String numOfCols, String numOfRows, String nameOfMaze)
        {
            this.spModel.StartNewGame(numOfCols, numOfRows, nameOfMaze);
        }
    }
}