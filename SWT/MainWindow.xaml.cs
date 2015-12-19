using SWT.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Host Game
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameDirector gd = new GameDirector(true, null, "8000");
        }


        // Join Game
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameDirector gd = new GameDirector(true, "127.0.0.1", "8000");
        }
    }
}
