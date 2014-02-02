using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.MapKit;

namespace ControllerHierarchy
{
	public class ChildController : UIViewController
	{
		public override void LoadView ()
		{
			var view = new UIView (Rectangle.Empty);
			view.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			View = view;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.FromRGB (0x00, 0xff, 0x00);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Console.WriteLine ("Child view bounds: {0}", View.Bounds);
			Console.WriteLine ("Child view frame: {0}", View.Frame);
		}

		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();
		}
	}
}
