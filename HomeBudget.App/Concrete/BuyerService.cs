using HomeBudget.App.Abstract;
using HomeBudget.App.Common;
using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.App.helpers;
using Newtonsoft.Json;

namespace HomeBudget.App.Concrete
{
    public class BuyerService: BaseService<Buyer>
    {
        private List<Buyer> buyers;

        public BuyerService()
        {
            buyers = new List<Buyer>();
        }
        public List<Buyer> getBuyersList()
        {
            return buyers;
        }
        public void AddBuyer(string name)
        {
            string buyerName = name.ToUpper();

            Buyer newBuyer = new Buyer()
            {
                Id = HelpersMethods.GenerateNextId(buyers),
                Name = buyerName,
            };
            buyers.Add(newBuyer);

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
                    Console.WriteLine($"Shopping Id {idToRemove} was removed.");
                }
                else
                {
                    Console.WriteLine($"Cannot find Id {idToRemove} on list.");
                }
            }
        }

        public void RemoveBuyer(int idToRemove)
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
    }
}
