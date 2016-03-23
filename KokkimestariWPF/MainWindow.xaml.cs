/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 23/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.DataAccess;
using KokkimestariWPF.Logic;
using KokkimestariWPF.UserControls;
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

namespace KokkimestariWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppEngine.InitializeDatabase();
            InitializeComponent();
            contentControl.Content = new Homepage();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Recipespage(contentControl);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new NewRecipepage();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Searchpage();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Aboutpage();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Homepage();
        }
    }
}
