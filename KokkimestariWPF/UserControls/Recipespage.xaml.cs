/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 07/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            contextMenu.ItemsSource = AppLogic.GetFavouriteLists();
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
        
        private void listBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listBox.SelectedIndex == -1) return;
            contentControl.Content = new RecipeViewPage(contentControl, (Recipe)(sender as ListBox).SelectedItem);
        }

        private void contextMenuItem_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listBox.SelectedIndex == -1) return;
            var list = ((sender as TextBlock).DataContext as FavouriteList);
            var recipe = listBox.SelectedItem as Recipe;
            try
            {
                AppLogic.AddRecipeToList(recipe, list);
                MessageBox.Show("Lisätty listalle " + list.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
