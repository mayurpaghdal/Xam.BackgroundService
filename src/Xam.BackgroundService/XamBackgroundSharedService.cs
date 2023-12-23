using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.BackgroundService
{
    public class XamBackgroundSharedService
    {
        private static XamBackgroundSharedService _instance;
        private static bool _isRunning;

        static XamBackgroundSharedService()
        {
        }

        private XamBackgroundSharedService()
        {
        }

        /// <summary>
        /// Single Instance of XamBackgroundService
        /// </summary>
        public static XamBackgroundSharedService Instance { get; } =
            _instance ?? (_instance = new XamBackgroundSharedService());


        /// <summary>
        /// Start the execution of background service
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;
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
        }
    }
}
