using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace ControllerHierarchy
{
	public class ChildController : UIViewController
	{
//		public override void LoadView ()
//		{
//			base.LoadView ();
//			Console.WriteLine ("Load view frame: {0}", View.Frame);
//		}

		public override void ViewDidLoad ()
		{
//			Console.WriteLine ("Child controller - viewDidLoad");
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.FromRGB (0x00, 0xff, 0x00);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Console.WriteLine ("Child view bounds: {0}", View.Bounds);
			Console.WriteLine ("Child view frame: {0}", View.Frame);
		}
	}
}


//			var label = new UILabel (new RectangleF(10, 10, 200, 20));
//			label.BackgroundColor = UIColor.FromRGB (0x00, 0xff, 0x00);
//			label.Text = "Child controller";
//
//			Add (label);