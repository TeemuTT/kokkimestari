/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestari project.
*
* Created: 22/03/2016
* Modified: 06/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KokkimestariWPF.UserControls
{
    /// <summary>
    /// Interaction logic for RecipeViewPage.xaml
    /// </summary>
    public partial class RecipeViewPage : UserControl
    {
        private ContentControl cc;

        public RecipeViewPage(ContentControl cc, Recipe recipe)
        {
            InitializeComponent();
            this.cc = cc;
            grid.DataContext = recipe;
            cbLists.ItemsSource = AppLogic.GetFavouriteLists();
            cbLists.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbLists.SelectedIndex == -1) return;
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new NewRecipepage((Recipe)grid.DataContext);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!(MessageBox.Show("Poistetaanko resepti?", "Vahvista poisto", MessageBoxButton.YesNo) == MessageBoxResult.Yes)) return;
            try
            {
                AppLogic.DeleteRecipe((Recipe)grid.DataContext);
                cc.Content = new Recipespage(cc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var r = (Recipe)grid.DataContext;
            PrintDialog pd = new PrintDialog();
            var doc = new FlowDocument();
            var p = new Paragraph(new Run("Kokkimestari"));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run(r.Name));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Aika: " + r.Timestr + "\tVaikeusaste: " + r.Difficultystr));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Ainekset"));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run(r.Ingredients));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Ohjeet"));
            doc.Blocks.Add(p);
            p = new Paragraph(new Run(r.Instructions));
            doc.Blocks.Add(p);
            doc.Name = "Kokkimestari";
            IDocumentPaginatorSource idp = doc;
            if (pd.ShowDialog() == true)
            {
                pd.PrintDocument(idp.DocumentPaginator, "KokkimestariTulostaa");
            }
        }
    }
}
