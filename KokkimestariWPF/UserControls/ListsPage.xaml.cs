/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 24/03/2016
* Modified: 06/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KokkimestariWPF.UserControls
{
    /// <summary>
    /// Interaction logic for ListsPage.xaml
    /// </summary>
    public partial class ListsPage : UserControl
    {
        private ContentControl contentControl;
        private FavouriteList newList;

        public ListsPage(ContentControl contentControl)
        {
            InitializeComponent();

            this.contentControl = contentControl;
            try
            {
                lbLists.DataContext = AppLogic.GetFavouriteLists();
                lbLists.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            newList = new FavouriteList(0, "", "");
            txtName.DataContext = newList;
            txtDesc.DataContext = newList;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDesc.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(txtName))
                return;
            else if (Validation.GetHasError(txtDesc))
                return;

            try
            {
                AppLogic.AddFavouriteList(newList);
                lbLists.DataContext = AppLogic.GetFavouriteLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLists.SelectedItem == null) return;
            try
            {
                var recipes = AppLogic.GetRecipesOfList((FavouriteList)lbLists.SelectedItem);
                if (recipes.Count == 0)
                {
                    recipes.Add(new Recipe(0, "Ei reseptejä!", "", "", 1, 0, @"Images/listhelp.png"));
                }
                lbRecipes.DataContext = recipes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contentControl.Content = new RecipeViewPage(contentControl, (Recipe)lbRecipes.SelectedItem);
        }

        private void remove_recipe(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var list = lbLists.SelectedItem as FavouriteList;
            var recipe = button.DataContext as Recipe;
            try
            {
                AppLogic.RemoveRecipeFromList(recipe, list);
                lbRecipes.DataContext = AppLogic.GetRecipesOfList((FavouriteList)lbLists.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void remove_list(object sender, RoutedEventArgs e)
        {
            if (!(MessageBox.Show("Poistetaanko lista?", "Vahvista poisto", MessageBoxButton.YesNo) == MessageBoxResult.Yes)) return;
            var list = (sender as Button).DataContext as FavouriteList;
            try
            {
                AppLogic.DeleteFavouriteList(list);
                lbLists.DataContext = AppLogic.GetFavouriteLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
