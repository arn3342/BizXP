using System;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using BizXP_App.Models;

namespace BizXP_App.CustomViews
{
    public class HomeButton : ConstraintLayout
    {
        #region Constructors & properties
        public HomeButton(Context context) : base(context)
        {
            Initialize(context);
        }

        public HomeButton(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public HomeButton(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected HomeButton(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_homeButton, this, false);
            AddView(MainView);
        }
        public void SetContents(HomeButtonModel buttonModel)
        {
            this.FindViewById<ImageView>(Resource.Id.buttonIcon).SetImageResource(buttonModel.drawable);
            this.FindViewById<TextView>(Resource.Id.buttonTitle).Text = buttonModel.title;
            this.FindViewById<TextView>(Resource.Id.buttonDescription).Text = buttonModel.desc;
        }
    }
}