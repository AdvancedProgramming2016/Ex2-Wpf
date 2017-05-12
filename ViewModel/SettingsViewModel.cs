using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeMenu.Model;

namespace MazeMenu
{
    public class SettingsViewModel
    {

        private SettingsModel settingModel;

        public SettingsViewModel()
        {
            this.settingModel = new SettingsModel();
        }

        public int VM_SelectedAlgo
        {
            get
            {
                return this.settingModel.DefaultAlgo;
            }
            set
            {
                this.settingModel.DefaultAlgo = value;
            }
        }

        public int VM_Port
        {
            get
            {
                return this.settingModel.Port;
            }
            set
            {
                this.settingModel.Port = value;
            }
        }

        public int VM_DefaultCol
        {
            get
            {
                return this.settingModel.DefaultCols;
            }
            set
            {
                this.settingModel.DefaultCols = value;
            }
        }

        public int VM_DefaultRow
        {
            get
            {
                return this.settingModel.DefaultRows;
            }
            set
            {
                this.settingModel.DefaultRows = value;
            }
        }
    }
}
