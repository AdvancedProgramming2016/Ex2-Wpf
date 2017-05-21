using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MazeMenu.Model;
using MazeLib;

namespace MazeMenu.ViewModel
{
    class MultiPlayerGameViewModel : INotifyPropertyChanged
    {
        
        private IMultiPlayerGame mpModel;
        private ISettingsModel settingsModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MultiPlayerGameViewModel(IMultiPlayerGame model)
        {
            this.mpModel = model;
            model.PropertyChanged += delegate(Object sender, PropertyChangedEventArgs e)
            {
                OnPropertyChanged("VM_" + e.PropertyName);
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public String VM_Maze
        {
            get
            {
                return this.mpModel.Maze.ToString().Replace("\r\n", "").Replace("*", "0");
            }
        }

        public String VM_OpponentPosition
        {
            get
            {
                return this.mpModel.OpponentPosition.ToString();
            }
        }

        public String VM_PlayerPosition
        {
            get
            {
                return this.mpModel.PlayerPosition.ToString();
            }
        }

        public void MovePlayer(Position position)
        {
            this.mpModel.MovePlayer(position);
        }

        //void JoinGame(Game game)
        void JoinGame()
        {
            //this.mpModel.JoinGame(game);
            this.mpModel.JoinGame();
        }

        void StartNewGame()
        {
            this.mpModel.StartNewGame();
        }
        
        void CloseGame()
        {
            this.mpModel.CloseGame();
        }
    }
}
