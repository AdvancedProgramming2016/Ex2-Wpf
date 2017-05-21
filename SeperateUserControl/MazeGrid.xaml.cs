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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MazeLib;
using MazeMenu.ViewModel;
using MazeMenu.Model;

namespace SeperateUserControl
{
    /// <summary>
    /// Interaction logic for MazeGrid.xaml
    /// </summary>
    public partial class MazeGrid : UserControl
    {

        private int numOfRows;
        private int numOfCols;
        private string playerPos;
        private string mazeString;
        private Dictionary<string, Rectangle> dicRect;

        protected override void OnInitialized(EventArgs e)
        {
            InitializeComponent();
        }

        public void Draw(string drawingString)
        {

            string[] splitRows = drawingString.Split(',');
            this.numOfRows = splitRows.Length;
            this.numOfCols = splitRows[0].Length;

            for (int i = 0; i < this.numOfRows; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = GridLength.Auto;
                this.MazeGridPart.RowDefinitions.Add(rd);   
            }

            for (int i = 0; i < this.numOfCols; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = GridLength.Auto;
                this.MazeGridPart.ColumnDefinitions.Add(cd);
            }

            // Create the maze and add to the dictionary.
            for (int i = 0; i < splitRows.Count(); i++)
            {
                for (int j = 0; j < splitRows[0].Length; j++)
                {
                    Rectangle currRect = new Rectangle();
                    
                    if ('1' == splitRows[i].ElementAt(j))
                    {
                        currRect.Fill = new SolidColorBrush(Colors.White);
                        Grid.SetRow(currRect, i);
                        Grid.SetColumn(currRect, j);
                        this.dicRect.Add(i.ToString() + "," + j.ToString(), currRect);
                    }
                    else if('0' == splitRows[i].ElementAt(j))
                    {
                        currRect.Fill = new SolidColorBrush(Colors.Black);
                        Grid.SetRow(currRect, i);
                        Grid.SetColumn(currRect, j);
                        this.dicRect.Add(i.ToString() + "," + j.ToString(), currRect);
                    }
                    
                }
            }
            
        }

        public static readonly DependencyProperty MazeDP =
            DependencyProperty.Register("MazeString", typeof(String), typeof(MazeGrid), new UIPropertyMetadata(MazeStringInit));

        public static readonly DependencyProperty PlayerDP =
            DependencyProperty.Register("PlayerPos", typeof(String), typeof(MazeGrid), new UIPropertyMetadata(PlayerPosInit));

        public static void MazeStringInit(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeGrid board = d as MazeGrid;
            board.Draw(e.NewValue.ToString());
        }

        public static void PlayerPosInit(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeGrid board = d as MazeGrid;
            board.HandlePlayerPosChanged(e.OldValue, e.NewValue);
        }

        public void HandlePlayerPosChanged(object oldPosition, object newPosition)
        {
            
        }
    }
}
