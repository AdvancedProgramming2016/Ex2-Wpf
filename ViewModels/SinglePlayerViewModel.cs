using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeMenu.Models;

namespace MazeMenu.ViewModels
{
    public class SinglePlayerViewModel
    {
        private ISinglePlayerModel singlePlayerModel;
        private string commandPropertyChanged;

        public string VM_Command
        {
            get
            {
                return commandPropertyChanged;
            }
            set
            {
                commandPropertyChanged = value;
                SetCorrectCommand(commandPropertyChanged);
            }
        }

        private void SetCorrectCommand(string command)
        {
            switch (command)
            {
                case "generate":

                
            }
        }
    }
}
