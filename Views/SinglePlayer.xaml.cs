using MazeMenu.ViewModel;
using MazeMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MazeMenu.Views;

namespace MazeMenu
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerGameViewModel singlePlayerGameViewModel;

        public SinglePlayer()
        {
            InitializeComponent();
            this.singlePlayerGameViewModel = new SinglePlayerGameViewModel
                (new SinglePlayerGameModel(), new SettingsModel());
            this.DataContext = this.singlePlayerGameViewModel;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Open maze window.
            new SinglePlayerGameMaze(NumOfRows.Text, numOfCols.Text, MazeNameBox.Text).Show();
            this.Close();
        }
    }
}
