/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 24/03/2016
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
        public NewRecipepage()
        {
            InitializeComponent();

            try
            {
                cbDiff.ItemsSource = AppLogic.GetDifficulties();
            }
            catch (Exception)
            {
                MessageBox.Show("Vaikeusasteiden haku epäonnistuI!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var recipe = new Recipe(
                0,
                txtName.Text,
                txtInstr.Text,
                txtIngredients.Text,
                cbDiff.SelectedIndex + 1,
                int.Parse(txtTime.Text),
                txtPicPath.Text);
            try
            {
                AppLogic.InsertRecipe(recipe);
                MessageBox.Show("Resepti lisätty");
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
            }
        }
    }
}
