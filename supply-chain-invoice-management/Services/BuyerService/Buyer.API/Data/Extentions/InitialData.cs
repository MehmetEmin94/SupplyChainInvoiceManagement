using Buyer.API.Models;

namespace Buyer.API.Data.Extentions
{
    internal class InitialData
    {
        public static IEnumerable<BuyerModel> Buyers =>
            new List<BuyerModel>() 
            { 
                new BuyerModel{ TaxId = "12345", Email="abc@def.com", Name="abc"},
                new BuyerModel{ TaxId = "98765", Email="xyz@def.com", Name="xyz"}
            };
    }
}
