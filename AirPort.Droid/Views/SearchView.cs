using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace AirPort.Droid.Views
{
    [Activity(Label = "Basic Search")]
    public class SearchView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SearchView);
        }
    }
}