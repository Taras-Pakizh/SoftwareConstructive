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

namespace MyGame.Controls
{
    /// <summary>
    /// Логика взаимодействия для GameFieldControl.xaml
    /// </summary>
    public partial class GameFieldControl : UserControl
    {
        public GameFieldControl()
        {
            InitializeComponent();
        }

        public Path Maze
        {
            set
            {
                MyCanvas.Children.Clear();
                MyCanvas.Children.Add(value);
            }
        }
    }
}
