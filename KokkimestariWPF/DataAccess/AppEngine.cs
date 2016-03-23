/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokkimestariWPF.DataAccess
{
    static class AppEngine
    {
        /// <summary>
        /// Returns an SQLiteConnection to the database.
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection MakeConnection()
        {
            var db = new SQLiteConnection("database.sqlite");
            return db;
        }

        /// <summary>
        /// Initializes the database. If it doesn't exist, creates necessary tables.
        /// </summary>
        public static void InitializeDatabase()
        {
            if (!File.Exists("database.sqlite"))
            {
                var db = MakeConnection();
                db.CreateTable<Recipe>();
                db.Close();
            }
        }

        /// <summary>
        /// Fetches all recipes from the database.
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetAllRecipes()
        {
            var db = MakeConnection();
            var recipes = db.Table<Recipe>().ToList<Recipe>();
            return recipes;
        }
    }
}
