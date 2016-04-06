/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 06/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            recipe = new Recipe(0, "", "", "", 0, 15, @"Images/kokkimestari.png");
            grid.DataContext = recipe;

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
                MessageBox.Show("Vaikeusasteiden haku epäonnistui!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtTime.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtInstr.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtIngredients.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(txtName))
                return;
            else if (Validation.GetHasError(txtTime))
                return;
            else if (Validation.GetHasError(txtInstr))
                return;
            else if (Validation.GetHasError(txtIngredients))
                return;

            try
            {
                if (recipe.ID == 0)
                {
                    AppLogic.InsertRecipe(recipe);
                    MessageBox.Show("Resepti lisätty");
                    recipe = new Recipe(0, "", "", "", 0, 15, @"Images/placeholderimg.jpg");
                    grid.DataContext = recipe;
                }
                else
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
            dialog.Filter = "Kuvatiedostot (jpg, png)|*.jpg;*.jpeg;*.png";
            var result = dialog.ShowDialog();
            if (result == true)
            {
                if (!File.Exists("Images"))
                {
                    Directory.CreateDirectory("Images");
                }
                var filename = Path.GetFileName(dialog.FileName);
                var copypath = Path.Combine("Images", filename);

                if (!File.Exists(copypath))
                {
                    File.Copy(dialog.FileName, copypath, true);
                }

                txtPicPath.Text = copypath;
                recipe.PicturePath = copypath;

                image.Source = new BitmapImage(new Uri(recipe.PicturePath));
            }
        }
    }
}
