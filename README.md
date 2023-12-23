# Xam Background Service Plugin for Xamarin.Forms
A plugin library to simplify Backgrounding in Xamarin.Forms. 

This is a fork from ([MatchaBackgroundService](https://github.com/winstongubantes/MatchaBackgroundService)). Xamarin Forms version is updated to latest and also Android SDK is upgraded to support AndroidX.
 

## Get Started
 
Ever wonder how facebook and twitter process there background to fetch a new content? And it looks so slick that when you refresh it was snappy and smooth, Making the user believed that the content is refreshed and updated in a snap when in fact it was done in the background. 

The secret behind it was the background service. And so we have created Matcha.BackgroundService to make our backgrounding task be simple and maintenable.

## Setup

* NuGet: [Xam.BackgroundService](http://www.nuget.org/packages/Xam.BackgroundService) [![NuGet](https://img.shields.io/nuget/v/Xam.BackgroundService.svg?label=NuGet)](https://www.nuget.org/packages/Xam.BackgroundService/)
* `PM> Install-Package Xam.BackgroundService`
* Install into ALL of your projects, include client projects.
 
 ## For Android
You call the "Init" method before all libraries initialization in MainActivity class.

```csharp
public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
{
    protected override void OnCreate(Bundle bundle)
    {
        BackgroundAggregator.Init(this);
        
        base.OnCreate(bundle);
        ....// Code for init was here
    }
}
```
 
## For iOS
 
You call the "Init" method before all libraries initialization in FinishedLaunching method in FormsApplicationDelegate class.
 
```csharp
public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
{
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
         BackgroundAggregator.Init(this);
         
        ....// Code for init was here
         return base.FinishedLaunching(app, options);
    }
}
```

## Platform Supported

|Platform|Version|
| ------------------- | :-----------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Android|API 15+|
|Windows 10 UWP|10+|
|.NET Standard|2.0+|
