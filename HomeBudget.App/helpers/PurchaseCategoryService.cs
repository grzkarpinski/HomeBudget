using HomeBudget.Domain.Enums;

namespace HomeBudget.Domain.Helpers
{
    public class PurchaseCategoryService
    {
        public static void PrintAvalibleCategories()
        {
            foreach (PurchaseCategory category in Enum.GetValues(typeof(PurchaseCategory)))
            {
                Console.WriteLine($"id: {(int)category} Category: {category}");
            }
        }

        public static PurchaseCategory GetCategory()
        {
            PurchaseCategory category = 0;
            do
            {
                Console.WriteLine("Enter category number:");
                PrintAvalibleCategories();

                string categoryInput = Console.ReadLine();
                Enum.TryParse(categoryInput, out category);

                if (Enum.IsDefined(typeof(PurchaseCategory), category))
                {
                    Console.WriteLine("ok");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong category...");
                }
            } while (true);

            return category;
        }
    }
}
