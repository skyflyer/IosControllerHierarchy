using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ControllerHierarchy
{
	public partial class ParentController : UIViewController
	{
		public ParentController () //: base ("ParentController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.FromRGB (0xFA, 0xFA, 0x0C);

			Console.WriteLine ("Parent view bounds: {0}", View.Bounds);
			Console.WriteLine ("Parent view frame: {0}", View.Frame);

			var childRect = new RectangleF (10, 100, 300, 200);
//			var childContainer = new UIView (childRect);
//			childContainer.BackgroundColor = UIColor.FromRGBA (0xf0, 0xf0, 0xff, 0xfa);

			// add a child controller
			var child = new ChildController ();
			AddChildViewController (child);
			Console.WriteLine ("Child view frame before setting: {0}", child.View.Frame);
			child.View.Frame = childRect;
			Add (child.View);
			child.DidMoveToParentViewController (this);
		}


		/*
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.FromRGB (0xFA, 0xFA, 0x0C);

			Console.WriteLine ("Parent view bounds: {0}", View.Bounds);
			Console.WriteLine ("Parent view frame: {0}", View.Frame);


			var subView = new UIView (new RectangleF (10, 30, 300, 200));
			subView.BackgroundColor = UIColor.FromRGB (0xff, 0x0f, 0x0f);

			var label = new UILabel (new RectangleF (10, 40, 300, 20));
			label.BackgroundColor = UIColor.FromRGB (0xff, 0xf0, 0xf0);
			label.Text = "Hello Dolly!";

			var childRect = new RectangleF (10, 100, 300, 200);
			var childContainer = new UIView (childRect);
			childContainer.BackgroundColor = UIColor.FromRGBA (0xf0, 0xf0, 0xff, 0xfa);

			Console.WriteLine ("**Subview frame: {0}", subView.Frame);
			Add (subView);
			Console.WriteLine ("**Subview frame: {0}", subView.Frame);

			Add (label);
			Add (childContainer);

			// add a child controller
			var child = new ChildController ();
			AddChildViewController (child);
			Console.WriteLine ("Child view frame before setting: {0}", child.View.Frame);
			child.View.Frame = childContainer.Frame;
			Add (child.View);
			child.DidMoveToParentViewController (this);


			var linearChild = new LinearChildController ();
			AddChildViewController (linearChild);
			Console.WriteLine ("Linear child frame: {0}", linearChild.View.Frame);
			linearChild.View.Frame = new RectangleF (10, 300, 300, linearChild.View.Frame.Height);
			Console.WriteLine ("Parent controller set the frame");
			Add (linearChild.View);
			linearChild.DidMoveToParentViewController (this);


		}
*/
	}

}

