using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.BackgroundService.iOS
{
    public class BackgroundAggregator
    {
        public static void Init(FormsApplicationDelegate appDelegate)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(appDelegate, nameof(StartLongRunningTask),
                message => { XamBackgroundService.Instance.Start(); });

            MessagingCenter.Subscribe<StopLongRunningTask>(appDelegate, nameof(StopLongRunningTask),
                message => { XamBackgroundService.Instance.Stop(); });
        }
    }
}