using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace ControllerHierarchy
{

	public class LinearChildController : UIViewController
	{
		UIButton _btn;

		public override void LoadView ()
		{
			base.LoadView ();

			View.BackgroundColor = UIColor.DarkGray;

			Console.WriteLine (" LinearChildController Load view frame: {0}", View.Frame);
			LinearLayout ll = new LinearLayout (View);

			var rect = new RectangleF (0, 0, 200, 20);
			_btn = new UIButton (UIButtonType.System);
			_btn.Frame = new RectangleF (0, 0, 200, 20);
			_btn.SetTitle ("Button goes to Holywood", UIControlState.Normal);
			_btn.BackgroundColor = UIColor.FromRGB (0xff, 0x00, 0x00);
			ll.Add (new LinearLayout.LinearLayoutItem (new UILabel(rect) { Text = "First label", BackgroundColor = UIColor.FromRGB(0xff,0x00,0x00)} ));
			ll.Add (new LinearLayout.LinearLayoutItem (new UILabel(rect) { Text = "Second label", BackgroundColor = UIColor.FromRGB(0x00,0xff,0x00) } ));
			ll.Add (new LinearLayout.LinearLayoutItem (new UILabel(rect) { Text = "Third label" } ));
			ll.Add (new LinearLayout.LinearLayoutItem (_btn));

			ll.Build ();

			View = ll.ContainerView;
			Console.WriteLine ("after layout view frame: {0}", View.Frame);
		}

		public override void ViewDidLoad ()
		{
			_btn.TouchUpInside += (object sender, EventArgs e) => {
				var alert = new UIAlertView("Clicked", "me", null, "OK");
				alert.Show();
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Console.WriteLine ("LinearChildController view bounds: {0}", View.Bounds);
			Console.WriteLine ("LinearChildController view frame: {0}", View.Frame);
		}
	}
	
}
