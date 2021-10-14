using SQLite;

namespace XamarinDemoApp.Models
{
    public class DbCoffee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Roaster { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}