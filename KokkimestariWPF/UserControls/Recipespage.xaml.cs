/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 27/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
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

namespace KokkimestariWPF.UserControls
{
    /// <summary>
    /// Interaction logic for Recipespage.xaml
    /// </summary>
    public partial class Recipespage : UserControl
    {
        private ContentControl contentControl;
        private List<Recipe> recipes;

        public Recipespage(ContentControl contentControl)
        {
            InitializeComponent();
            this.contentControl = contentControl;
            recipes = AppLogic.GetAllRecipes();
            listBox.ItemsSource = recipes;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contentControl.Content = new RecipeViewPage(contentControl, (Recipe)listBox.SelectedItem);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listBox.ItemsSource = null;
            string query = (sender as TextBox).Text.ToLower();
            List<Recipe> filtered = new List<Recipe>();
            foreach (var r in recipes)
            {
                if (r.Name.ToLower().Contains(query)) filtered.Add(r);
            }
            listBox.ItemsSource = filtered;
        }
    }
}
