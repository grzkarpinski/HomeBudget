using HomeBudget.App.Common;
using HomeBudget.App.helpers;
using HomeBudget.App.managers;
using HomeBudget.Domain.Entity;
using Newtonsoft.Json.Bson;

namespace HomeBudget.App.Concrete
{
    public class BuyerService: BaseService<Buyer>
    {
        private List<Buyer> buyers;

        public BuyerService(string buyersFilePath)
        {
            buyers = new List<Buyer>();
            string path = buyersFilePath;
            buyers = FileManager<Buyer>.LoadListFronFile(path);
        }
        override public List<Buyer> GetAllItems()
        {
            return buyers;
        }
        
        public void AddBuyer()
        {
            Console.WriteLine("Enter name of buyer:");
            string buyerName = Console.ReadLine();
            Buyer newBuyer = new Buyer()
            {
                Id = IdService.GenerateNextId(buyers),
                Name = buyerName,
            };

            AddItem(newBuyer);
            FileManager<Buyer>.SaveListToFile(buyers, "buyers.json");

        }
        override public void AddItem(Buyer buyer)
        {
            buyers.Add(buyer);
        }
        public void RemoveBuyer()
        {
            if (buyers.Count == 0)
            {
                Console.WriteLine("List is already empty.");
                return;
            }

            Console.WriteLine("Enter Id of buyer you want to remove:");
            if (int.TryParse(Console.ReadLine(), out int idToRemove))
            {
                Buyer itemToRemove = buyers.FirstOrDefault(x => x.Id == idToRemove);

                if (itemToRemove != null)
                {
                    buyers.Remove(itemToRemove);
                    FileManager<Buyer>.SaveListToFile(buyers, "buyers.json");
                    Console.WriteLine($"Buyer Id {idToRemove} was removed.");

                }
                else
                {
                    Console.WriteLine($"Cannot find Id {idToRemove} on list.");
                }
            }
        }

        override public void RemoveItem(int idToRemove)
        {
            if (buyers.Count == 0)
            {
                Console.WriteLine("List is already empty.");
                return;
            }

            Buyer itemToRemove = buyers.FirstOrDefault(x => x.Id == idToRemove);

            if (itemToRemove != null)
            {
                buyers.Remove(itemToRemove);
                Console.WriteLine($"Shopping Id {idToRemove} was removed.");
            }
            else
            {
                Console.WriteLine($"Cannot find Id {idToRemove} on list.");
            }
        }
        public void PrintAllBuyers()
        {
            if (buyers.Count == 0)
            {
                Console.WriteLine("Thera are no buyers added.");
                return;
            }

            Console.WriteLine("Buyers in your household:");
            buyers.ForEach(PrintBuyerDetails);
        }

        private static void PrintBuyerDetails(Buyer item)
        {
            Console.WriteLine($"Id: {item.Id}; " +
                           $"Name: {item.Name}; ");
        }
    }
}
