/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokkimestariWPF.Logic
{
    static class AppLogic
    {
        /// <summary>
        /// Returns a List<Recipe> of all recipes.
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetAllRecipes()
        {
            return AppEngine.GetAllRecipes();
        }
    }

    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string Difficulty { get; set; }
        public int Time { get; set; }
        public string PicturePath { get; set; }

        public Recipe()
        {

        }
    }
}
