using BizXP_App.Models;
using Android.Content;
using Android.Support.Constraints;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System.Collections.Generic;

namespace BizXP_App.Adapters
{
    public class InventoryAdapter : RecyclerView.Adapter
    {
        public List<object> contentCollection;
        Context mContext;
        const int product = 0;
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public override int GetItemViewType(int position)
        {
            if (contentCollection[position] is Product)
            {
                return product;
            }
            return contentCollection.Count;
        }

        public InventoryAdapter(Context context, List<object> itemList)
        {
            mContext = context;
            contentCollection = itemList;
            //mFragmentManager = fragmentManager;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case product:
                    ProductViewHolder vh = holder as ProductViewHolder;
                    Product _product = contentCollection[position] as Product;
                    vh.productName.Text = _product.ProductName;
                    vh.productQuantity.Text += _product.Quantity;
                    vh.buyingPrice.Text += _product.BuyingPrice + "৳";
                    vh.sellingPrice.Text += _product.SellingPrice + "৳";
                    vh.stockAddDate.Text = _product.StockAdded.ToString("dd-MM-yyyy").Split(' ')[0];
                    break;
            }

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder vh = null;
            switch (viewType)
            {
                case product:
                    vh = new ProductViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_product, parent, false));
                    break;
            }
            return vh;
        }

        internal class ProductViewHolder : RecyclerView.ViewHolder
        {
            public TextView productName { get; set; }
            public TextView productQuantity { get; set; }
            public TextView buyingPrice { get; set; }
            public TextView sellingPrice { get; set; }
            public TextView stockAddDate { get; set; }

            public ProductViewHolder(View itemView) : base(itemView)
            {
                productName = itemView.FindViewById<TextView>(Resource.Id.productName);
                productQuantity = itemView.FindViewById<TextView>(Resource.Id.productQty);
                buyingPrice = itemView.FindViewById<TextView>(Resource.Id.buyingPrice);
                sellingPrice = itemView.FindViewById<TextView>(Resource.Id.sellingPrice);
                stockAddDate = itemView.FindViewById<TextView>(Resource.Id.stockAddedDate);

                //postBody = itemView.FindViewById<TextView>(Resource.Id.postself);
                //inspireCount = itemView.FindViewById<TextView>(Resource.Id.inspireCount);
                //InspireButton = itemView.FindViewById<ImageView>(Resource.Id.inspireButton);
                //FeedbackButton = itemView.FindViewById<Button>(Resource.Id.feedbackbtn);
                //SubjectClick clickAndFocus = new SubjectClick();
                //subjectContainer.SetOnClickListener(clickAndFocus);
                //subjectContainer.OnFocusChangeListener = clickAndFocus;

            }

        }
    }
}