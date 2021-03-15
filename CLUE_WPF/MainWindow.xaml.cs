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

namespace Clue_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image context;
        private Image character;
        private Canvas main;

        private bool canMove = true;

        private int angle = 0;

        public MainWindow(){
            InitializeComponent();
            context = new Image() {
                Source = (ImageSource)TryFindResource("FrontYard"),
                Stretch = Stretch.Fill,
                StretchDirection = StretchDirection.Both,
                Height = 557,
            };



            character = new Image() {
                Source = (ImageSource)TryFindResource("01_FR"),
                Stretch = Stretch.Fill,
                Height = 120,
            };

            main = new Canvas();

            main.Children.Add(character);

            mainPanel.Children.Add(context);
            mainPanel.Children.Add(main);
        }

        private void Minime(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Close(object sender, RoutedEventArgs e) { this.Close(); }
        private void Drag(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) DragMove(); }

        private void Click(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            if (p.Y == 0 && p.X == 0) return;
            Canvas.SetLeft(character, p.X - 10);
            Canvas.SetTop(character, - (618 - p.Y) );
            character.Source = (angle % 2 == 1) ? (ImageSource)TryFindResource("01_FL") : (ImageSource)TryFindResource("01_FR");
            angle += 1;
            //character.RenderTransform = new RotateTransform(angle += 15);
        }
    }
}