using EsgApp.Models;
using MongoDB.Driver;

namespace EsgApp.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _itens;

        public ItemService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDb:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDb:Database"]);
            _itens = database.GetCollection<Item>("Itens");
        }

        public List<Item> Get() => _itens.Find(i => true).ToList();
        public Item Create(Item item)
        {
            _itens.InsertOne(item);
            return item;
        }
    }
}