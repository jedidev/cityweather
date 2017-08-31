// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace cityweather.iOS
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView IconImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MaxTempLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MinTempLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TemperatureLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (IconImageView != null) {
                IconImageView.Dispose ();
                IconImageView = null;
            }

            if (MaxTempLabel != null) {
                MaxTempLabel.Dispose ();
                MaxTempLabel = null;
            }

            if (MinTempLabel != null) {
                MinTempLabel.Dispose ();
                MinTempLabel = null;
            }

            if (TemperatureLabel != null) {
                TemperatureLabel.Dispose ();
                TemperatureLabel = null;
            }
        }
    }
}