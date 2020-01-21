using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BizXP_App.Adapters;
using BizXP_App.Models;

namespace BizXP_App.Activities
{
    [Activity(Label = "InventoryActivity")]
    public class InventoryActivity : Activity
    {
        RecyclerView productContainer;
        InventoryAdapter adapter;
        List<object> contents = new List<object>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_inventory);
            productContainer = FindViewById<RecyclerView>(Resource.Id.productContainer);
            productContainer.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new InventoryAdapter(this, contents);

            productContainer.SetAdapter(adapter);

            PopulateProducts();
        }

        private void PopulateProducts()
        {
            if (contents.Count == 0)
            {

                contents.Add(new Product() { ProductName = "Maxima Battery", BuyingPrice = "4000", SellingPrice = "4500", Quantity = "350", StockAdded = DateTime.Today });
                contents.Add(new Product() { ProductName = "Passenger Battery", BuyingPrice = "3000", SellingPrice = "3200", Quantity = "50", StockAdded = DateTime.Today });
                contents.Add(new Product() { ProductName = "Ultra Battery", BuyingPrice = "5000", SellingPrice = "5500", Quantity = "100", StockAdded = DateTime.Today });
                adapter.NotifyItemInserted(contents.Count - 1);
            }
        }
    }
}