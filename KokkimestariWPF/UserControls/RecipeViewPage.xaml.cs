/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 24/03/2016
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
    /// Interaction logic for RecipeViewPage.xaml
    /// </summary>
    public partial class RecipeViewPage : UserControl
    {
        public RecipeViewPage(Recipe recipe)
        {
            InitializeComponent();
            grid.DataContext = recipe;
            cbLists.ItemsSource = AppLogic.GetFavouriteLists();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var recipe = (Recipe)grid.DataContext;
            var list = (FavouriteList)cbLists.SelectedItem;
            try
            {
                AppLogic.AddRecipeToList(recipe, list);
                MessageBox.Show("Lisätty");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
