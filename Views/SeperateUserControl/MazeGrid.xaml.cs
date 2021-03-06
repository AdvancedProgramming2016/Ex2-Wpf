﻿using System;
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

        private double rectHeight;
        private double rectWidth;
        private int numOfRows;
        private int numOfCols;
        private int playerPosI;
        private int playerPosJ;
        private Rectangle playerRect;
        private string mazeString;
        private Dictionary<string, Rectangle> dicRect;
        private SolidColorBrush wallColor;
        private SolidColorBrush freeSpaceColor;

        public String Maze
        {
            get
            {
                return (string)GetValue(MazeProperty);
            }
            set
            {
                SetValue(MazeProperty, value);
            }
        }

        public String InitialPostion
        {
            get
            {
                return (string)GetValue(InitialPositionProperty);
            }
            set
            {
                SetValue(InitialPositionProperty, value);
            }
        }

        public String DestPosition
        {
            get
            {
                return (string)GetValue(DestPositionProperty);
            }
            set
            {
                SetValue(DestPositionProperty, value);
            }
        }

        public String PlayerPosition
        {
            get
            {
                return (string)GetValue(PlayerPositionProperty);
            }
            set
            {
                SetValue(PlayerPositionProperty, value);
            }
        }

        public int Rows
        {
            get
            {
                return (int)GetValue(RowsProperty);
            }
            set
            {
                SetValue(RowsProperty, value);
            }
        }

        public int Cols
        {
            get
            {
                return (int)GetValue(ColsProperty);
            }
            set
            {
                SetValue(ColsProperty, value);
            }
        }

        public String MazeName
        {
            get
            {
                return (string)GetValue(MazeNameProperty);
            }
            set
            {
                SetValue(MazeNameProperty, value);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            InitializeComponent();
            this.wallColor = new SolidColorBrush(Colors.White);
            this.freeSpaceColor = new SolidColorBrush(Colors.Black);
        }

        public void Draw(string drawingString)
        {

            // Calculate number of rows and coloms in maze.
            string[] splitRows = drawingString.Split(',');
            this.numOfRows = splitRows.Length;
            this.numOfCols = splitRows[0].Length;

            // Calculate height and width of each rectangle.
            this.rectHeight = this.MazeCanvas.Height / this.numOfRows;
            this.rectWidth = this.MazeCanvas.Width / this.numOfCols;

            // Create the maze and add to the dictionary.
            for (int i = 0; i < splitRows.Count(); i++)
            {
                for (int j = 0; j < splitRows[0].Length; j++)
                {
                    Rectangle currRect = new Rectangle();
                    
                    if ('1' == splitRows[i].ElementAt(j)) // Wall.
                    {
                        currRect.Fill = this.wallColor;
                    }
                    else if('0' == splitRows[i].ElementAt(j)) // Free space.
                    {
                        currRect.Fill = this.freeSpaceColor;
                    }
                    else if('*' == splitRows[i].ElementAt(j)) // Source point.
                    {
                        currRect.Fill = new SolidColorBrush(Colors.Aqua);
                    }
                    else if('#' == splitRows[i].ElementAt(j)) // Dest point.
                    {
                        currRect.Fill = new SolidColorBrush(Colors.Azure);
                    }

                    // Color the rectangle and add to the canvas.
                    this.MazeCanvas.Children.Add(currRect);
                    Canvas.SetTop(currRect, i *this.rectHeight);
                    Canvas.SetLeft(currRect, j * this.rectWidth);

                    // Add to dictionary rectangle.
                    this.dicRect.Add(i.ToString() + "," + j.ToString(), currRect);
                }
            }
        }

        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(String), typeof(MazeGrid), null);

        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(String), typeof(MazeGrid), new UIPropertyMetadata(MazeStringInit));

        public static readonly DependencyProperty PlayerPositionProperty =
            DependencyProperty.Register("PlayerPosition", typeof(String), typeof(MazeGrid), new UIPropertyMetadata(PlayerPosInit));

        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("Cols", typeof(String), typeof(MazeGrid), null);

        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(String), typeof(MazeGrid), null);

        public static readonly DependencyProperty DestPositionProperty =
            DependencyProperty.Register("DestPosition", typeof(String), typeof(MazeGrid), null);

        public static readonly DependencyProperty InitialPositionProperty =
            DependencyProperty.Register("InitialPosition", typeof(String), typeof(MazeGrid), null);

        public static void MazeStringInit(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeGrid board = d as MazeGrid;
            board.Draw(e.NewValue.ToString());
        }

        public static void PlayerPosInit(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeGrid board = d as MazeGrid;
            board.HandlePlayerPosChanged(e.NewValue);
        }

        /// <summary>
        ///  Update the location of the player.
        /// </summary>
        /// <param name="newPosition"></param>
        public void HandlePlayerPosChanged(object newPosition)
        {
            string position = newPosition as string;

            // Update the location of the player.
            Canvas.SetTop(this.playerRect, Convert.ToDouble(position.Split(',')[0]) * this.rectHeight);
            Canvas.SetLeft(this.playerRect, Convert.ToDouble(position.Split(',')[1]) * this.rectWidth);
        }

        /// <summary>
        /// Calculate the location of the player on the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.ToString().Equals("Up"))
            {
                if (this.playerPosI - 1 >= this.numOfRows && 
                    !this.dicRect[this.playerPosI.ToString() + ',' + this.playerPosJ.ToString()]
                    .Fill.Equals(this.wallColor))
                {
                    this.playerPosI -= 1;
                }
            }
            else if(e.ToString().Equals("Down") && !this.dicRect[this.playerPosI.ToString() + ',' + this.playerPosJ.ToString()]
                    .Fill.Equals(this.wallColor))
            {
                if (this.playerPosI + 1 <= this.numOfRows)
                {
                    this.playerPosI += 1;
                }
            }
            else if(e.ToString().Equals("Right") && !this.dicRect[this.playerPosI.ToString() + ',' + this.playerPosJ.ToString()]
                    .Fill.Equals(this.wallColor))
            {
                if(this.playerPosJ + 1 <= this.numOfCols)
                {
                    this.playerPosJ += 1;
                }
            }
            else if(e.ToString().Equals("Left") && !this.dicRect[this.playerPosI.ToString() + ',' + this.playerPosJ.ToString()]
                    .Fill.Equals(this.wallColor))
            {
                if(this.playerPosJ - 1 >= this.numOfCols)
                {
                    this.playerPosJ -= 1;
                }
            }

            // Update the location of the player.
            this.HandlePlayerPosChanged(this.playerPosI.ToString() + ',' + this.playerPosJ.ToString());
        }
    }
}
