﻿using System;
using Windows.ApplicationModel.Background;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using static Windows.ApplicationModel.Background.BackgroundAccessStatus;

namespace Xam.BackgroundService.UWP
{
    public class BackgroundAggregator
    {
        private static string BackServiceName = "BackgroundService";

        public static void Init(WindowsPage page)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(page, nameof(StartLongRunningTask),
                async (message) =>
                {
                    var access = await BackgroundExecutionManager.RequestAccessAsync();

                    switch (access)
                    {
                        case Unspecified:
                            return;
                        case AllowedMayUseActiveRealTimeConnectivity:
                            return;
                        case AllowedWithAlwaysOnRealTimeConnectivity:
                            return;
                        case Denied:
                            return;
                    }

                    var task = new BackgroundTaskBuilder
                    {
                        Name = BackServiceName,
                        //TaskEntryPoint = "Xam.BackgroundService.UWP.XamBackgrounService"
                    };

                    var trigger = new ApplicationTrigger();
                    task.SetTrigger(trigger);

                    //var condition = new SystemCondition(SystemConditionType.InternetAvailable);
                    task.Register();

                    await trigger.RequestAsync();
                });

            MessagingCenter.Subscribe<StopLongRunningTask>(page, nameof(StopLongRunningTask),
                message =>
                {
                    var tasks = BackgroundTaskRegistration.AllTasks;
                    foreach (var task in tasks)
                    {
                        // You can check here for the name
                        string name = task.Value.Name;
                        if (name == BackServiceName)
                        {
                            task.Value.Unregister(true);
                        }
                    }
                    //BackgroundAggregatorService.Instance.Stop();
                });
        }
    }
}
