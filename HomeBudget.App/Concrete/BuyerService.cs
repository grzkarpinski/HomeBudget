using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Concrete
{
    public class BuyerService
    {
        private List<Buyer> buyers;
        private int BuyerId;

        public BuyerService()
        {
            buyers = new List<Buyer>();
            BuyerId = 1;
        }

        public void AddBuyer(string name)
        {
            string buyerName = name.ToUpper();

            Buyer newBuyer = new Buyer()
            {
                Id = BuyerId,
                Name = buyerName,
            };
            buyers.Add(newBuyer);

            BuyerId++;
        }
        public List<Buyer> getBuyersList()
        {
            return buyers;
        }
    }
}
