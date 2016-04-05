/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 22/03/2016
* Modified: 05/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using KokkimestariWPF.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KokkimestariWPF
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : UserControl
    {
        private ContentControl cc;

        public Homepage(ContentControl cc)
        {
            InitializeComponent();

            this.cc = cc;

            try
            {
                innergrid.DataContext = AppLogic.GetRecipeOfTheDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new RecipeViewPage(cc, (Recipe)innergrid.DataContext);
        }
    }
}
