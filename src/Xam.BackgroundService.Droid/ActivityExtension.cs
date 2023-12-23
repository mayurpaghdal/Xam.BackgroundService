using Android.Content;
using Xamarin.Forms;

namespace Xam.BackgroundService.Droid
{
    public class BackgroundAggregator
    {
        public static void Init(ContextWrapper context)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(context, nameof(StartLongRunningTask), message =>
            {
                var intent = new Intent(context, typeof(XamBackgroundService));
                context.StartService(intent);
            });

            MessagingCenter.Subscribe<StopLongRunningTask>(context, nameof(StopLongRunningTask), message =>
            {
                var intent = new Intent(context, typeof(XamBackgroundService));
                context.StopService(intent);
            });
        }
    }
}