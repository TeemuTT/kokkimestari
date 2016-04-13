/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 07/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.DataAccess;
using KokkimestariWPF.UserControls;
using MahApps.Metro.Controls;
using System.Windows;

namespace KokkimestariWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            AppEngine.InitializeDatabase();
            InitializeComponent();
            contentControl.Content = new Homepage(contentControl);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Recipespage(contentControl);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new NewRecipepage();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Aboutpage();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Homepage(contentControl);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ListsPage(contentControl);
        }
    }
}
