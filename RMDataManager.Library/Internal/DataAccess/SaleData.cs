using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Internal.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            // TODO: Break this into multiple parts
            // start filling in the sale detail models we iwll save to the db
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                // Get the information about this product
                var productInfo = products.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product id of { detail.ProductId } could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            // create the sale model

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            // save the sale model
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spSale_Insert", sale, "RMData"); //can infer type from "sale"

            // get the id from the sale model
            sale.Id = sql.LoadData<int, dynamic>("dbo.spSale_Lookup", new { sale.CashierId, sale.SaleDate }, "RMData").FirstOrDefault();

            // finish filling in the sale detail models and save them
            // TODO: check the amount of items, if over a certain amount, create a table value parameter to reduce sql calls
            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                sql.SaveData("dbo.spSaleDetail_Insert", item, "RMData");
            }

            
        }

        //public List<ProductModel> GetProducts()
        //{
        //    SqlDataAccess sql = new SqlDataAccess();

        //    var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "RMData");

        //    return output;
        //}
    }
}
