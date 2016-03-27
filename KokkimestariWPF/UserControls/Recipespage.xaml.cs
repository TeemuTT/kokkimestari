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

        public Recipespage(ContentControl contentControl)
        {
            InitializeComponent();
            this.contentControl = contentControl;
            listBox.ItemsSource = AppLogic.GetAllRecipes();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contentControl.Content = new RecipeViewPage(contentControl, (Recipe)listBox.SelectedItem);
        }
    }
}
