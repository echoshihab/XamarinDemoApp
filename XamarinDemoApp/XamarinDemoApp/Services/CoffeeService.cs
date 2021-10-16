using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;
using XamarinDemoApp.Models;

namespace XamarinDemoApp.Services
{
    public static class CoffeeService
    {
        private static SQLiteAsyncConnection _db;

        static async Task Init()
        {
            if (_db != null)
                return;

            //get the path to database
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            _db = new SQLiteAsyncConnection(databasePath);

            await _db.CreateTableAsync<DbCoffee>();
        }

        public static async Task AddCoffee(string name, string roaster)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var coffee = new DbCoffee()
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            var id = await _db.InsertAsync(coffee);
        }

        public static async Task RemoveCoffee(int id)
        {
            await Init();
            await _db.DeleteAsync<DbCoffee>(id);
        }

        public static async Task<IEnumerable<DbCoffee>> GetCoffee()
        {
            await Init();
            var coffee = await _db.Table<DbCoffee>().ToListAsync();
            return coffee;
        }
    }
}
