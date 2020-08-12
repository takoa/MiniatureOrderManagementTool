using LiteDB;
using MiniatureOrderManagementTool.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

using v2 = MiniatureOrderManagementTool.DatabaseConverter.Dtos.v2;
using v3 = MiniatureOrderManagementTool.DatabaseConverter.Dtos.v3;

namespace MiniatureOrderManagementTool.DatabaseConverter
{
    public class DatabaseConverter
    {
        private string configPath;
        private string databasePath;

        public Config Config { get; }

        static void Main(string[] args)
        {
            DatabaseConverter dc = new DatabaseConverter("./config.json", "./database.db");

            dc.Convert();
        }

        public DatabaseConverter(string configPath, string databasePath)
        {
            using StreamReader reader = new StreamReader(configPath, Encoding.UTF8);
            string json = reader.ReadToEnd();

            this.Config = new Config(System.Text.Json.JsonSerializer.Deserialize<Models.Dtos.Config>(json));
            this.configPath = configPath;
            this.databasePath = databasePath;
        }

        private void Convert()
        {
            using var db = new LiteDatabase(this.databasePath);

            this.ConvertStockedParts(db);
            this.ConvertOrders(db);

            this.Config.DatabaseVersion = 3;

            string json = System.Text.Json.JsonSerializer.Serialize(this.Config);
            using StreamWriter writer = new StreamWriter(this.configPath, false, Encoding.UTF8);

            writer.Write(json);
        }

        private void ConvertStockedParts(LiteDatabase db)
        {
            switch (this.Config.DatabaseVersion)
            {
                default:
                    var newStockedPartList = new List<v3.StockedPart>();

                    foreach (var item in db.GetCollection<v2.StockedPart>("parts").FindAll())
                    {
                        newStockedPartList.Add(new v3.StockedPart(item));
                    }

                    db.GetCollection<v3.StockedPart>("parts").Update(newStockedPartList);

                    break;
            }
        }

        private void ConvertOrders(LiteDatabase db)
        {
            switch (this.Config.DatabaseVersion)
            {
                default:
                    var newOrderList = new List<v3.Order>();

                    foreach (var item in db.GetCollection<v2.Order>("orders").FindAll())
                    {
                        newOrderList.Add(new v3.Order(item));
                    }

                    db.GetCollection<v3.Order>("orders").Update(newOrderList);

                    break;
            }
        }
    }
}
