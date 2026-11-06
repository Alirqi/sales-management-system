using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using SalesSystem.FormFunction;

namespace SalesSystem.CLASSES.Initialization
{
  
    public class InvosPurchaseProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Warehouse { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        //public RepositoryItemLookUpEdit CreateLookUpEdit()
        //{
        //    RepositoryItemLookUpEdit lookUpEdit = new RepositoryItemLookUpEdit();
        //    lookUpEdit.DisplayMember = "pro_name";
        //    lookUpEdit.ValueMember = "pro_id";
        //    process pross = new process();            
        //    lookUpEdit.DataSource = pross.GET_ALL_PROUDUCTS(); // Replace this with your actual data source
        //    return lookUpEdit;
        //}

      


        //private List<Product> GetProductData()
        //{
        //    // Replace this with your actual data retrieval logic
        //    List<Product> products = new List<Product>
        //{
        //    new Product { ProductId = 1, ProductName = "Product 1" },
        //    new Product { ProductId = 2, ProductName = "Product 2" },
        //    new Product { ProductId = 3, ProductName = "Product 3" }
        //};
        //    return products;
        //}

        //private List<Product> GetProductData()
        //{
        //    List<Product> products=new List<Product>();                             
        //    return products;
        //}

    }

}
