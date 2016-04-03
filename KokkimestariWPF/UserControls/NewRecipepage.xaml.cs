/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 03/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using Microsoft.Win32;
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
    /// Interaction logic for NewRecipepage.xaml
    /// </summary>
    public partial class NewRecipepage : UserControl
    {
        private Recipe recipe;

        public NewRecipepage()
        {
            InitializeComponent();

            recipe = new Recipe(0);
            grid.DataContext = recipe;
            image.Source = new BitmapImage(new Uri("C:\\Users\\Teemu\\Desktop\\mk6_jouluinen_vihersalaatti.jpg"));

            try
            {
                cbDiff.ItemsSource = AppLogic.GetDifficulties();
                cbDiff.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Vaikeusasteiden haku epäonnistui!");
            }
        }

        public NewRecipepage(Recipe recipe)
        {
            InitializeComponent();

            txtTitle.Text = "Muokkaa reseptiä";
            this.recipe = recipe;
            grid.DataContext = recipe;

            try
            {
                cbDiff.ItemsSource = AppLogic.GetDifficulties();
                cbDiff.Text = recipe.Difficultystr;
            }
            catch (Exception)
            {
                MessageBox.Show("Vaikeusasteiden haku epäonnistuI!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            recipe.Name = txtName.Text;
            recipe.Instructions = txtInstr.Text;
            recipe.Ingredients = txtIngredients.Text;
            recipe.Difficulty = cbDiff.SelectedIndex + 1;
            recipe.Time = int.Parse(txtTime.Text);
            recipe.PicturePath = txtPicPath.Text;

            try
            {
                if (recipe.ID == 0)
                {
                    AppLogic.InsertRecipe(recipe);
                    MessageBox.Show("Resepti lisätty");
                } else
                {
                    AppLogic.UpdateRecipe(recipe);
                    MessageBox.Show("Resepti päivitetty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lisäys epäonnistui!" + ex.Message);
            }
        }

        private void btnChoosePic_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                txtPicPath.Text = dialog.FileName;
                image.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
    }
}
