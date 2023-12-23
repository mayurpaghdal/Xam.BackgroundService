using System;
using UIKit;

namespace Xam.BackgroundService.iOS
{
    public class XamBackgroundService
    {
        private static nint _taskId;
        private static XamBackgroundService _instance;
        private static bool _isRunning;

        static XamBackgroundService()
        {
        }

        private XamBackgroundService()
        {
        }

        /// <summary>
        /// Single Instance of XamBackgroundService
        /// </summary>
        public static XamBackgroundService Instance { get; } =
            _instance ?? (_instance = new XamBackgroundService());

        /// <summary>
        /// Start the execution of background service
        /// </summary>
        public void Start()
        {
            if(_isRunning) return;

            //We only have 3 minutes in the background service as per iOS 9
            _taskId = UIApplication.SharedApplication.BeginBackgroundTask(nameof(StartLongRunningTask), Stop);
            BackgroundAggregatorService.Instance.Start();

            _isRunning = true;
        }

        /// <summary>
        /// Stop the execution of background service
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            BackgroundAggregatorService.Instance.Stop();
            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }
    }
}