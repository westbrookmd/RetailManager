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
        public void SaveSale(SaleModel sale)
        {
            // TODO: Break this into multiple parts
            // start filling in the sale detail models we iwll save to the db
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();

            foreach (var item in sale.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                // Get the information about this product

                details.Add(detail);
            }
            // fill in the available information
            // create the sale model
            // save the sale model
            // get the id from the sale model
            // finish filling in the sale detail models
            // save the sale detail models
        }
    }
}
