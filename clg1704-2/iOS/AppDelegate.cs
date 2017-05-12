using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Touch;
using FFImageLoading.Transformations;
using Foundation;
using UIKit;



namespace clg17042.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif

			//FFImageLoading 초기화
			CachedImageRenderer.Init();

            // Xamarin.Forms linker issue
            //var ignore = new CachedImage();
            var ignore = new CircleTransformation();

			LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
