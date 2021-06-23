using System;
using Android.Content;

namespace WilkoMoto_Android.Helpers
{
    public static class ViewHelper
    {
        public static void ShowDialog(Context context, Action positive, Action negative,
            string question, string positiveAns, string negativeAns)
        {
            var dialog = new AndroidX.AppCompat.App.AlertDialog.Builder(context, Resource.Style.AppCompatAlertDialogStyle);
            dialog.SetMessage(question);

            dialog.SetNegativeButton(negativeAns, (thisalert, args) =>
            {
                negative();
            });

            dialog.SetPositiveButton(positiveAns, (thisalert, args) =>
            {
                positive();
            });

            dialog.Show();
        }
    }
}
