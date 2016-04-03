/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 24/03/2016
* Modified: 03/04/2016
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
    /// Interaction logic for ListsPage.xaml
    /// </summary>
    public partial class ListsPage : UserControl
    {
        private ContentControl contentControl;

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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var list = new FavouriteList(0, txtName.Text, txtDesc.Text);
            try
            {
                AppLogic.AddFavouriteList(list);
                MessageBox.Show("Lisätty");
                lbLists.DataContext = AppLogic.GetFavouriteLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLists.SelectedItem == null) return; // This happens when we delete a list.
            try
            {
                lbRecipes.DataContext = AppLogic.GetRecipesOfList((FavouriteList)lbLists.SelectedItem);
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
                MessageBox.Show("Lista poistettu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
