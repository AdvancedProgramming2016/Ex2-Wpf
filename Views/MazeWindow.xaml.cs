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

namespace MazeMenu
{
    /// <summary>
    /// Interaction logic for Maze.xaml
    /// </summary>
    public partial class MazeWindow : Window
    {
        public MazeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the Main menu when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
