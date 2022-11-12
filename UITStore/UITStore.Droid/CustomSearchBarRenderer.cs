using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITStore.Components;
using UITStore.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]

namespace UITStore.Droid
{
    class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(1) as LinearLayout;

                linearLayout.Background = null;
            }
        }
    }
}