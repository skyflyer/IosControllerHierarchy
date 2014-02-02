using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ControllerHierarchy
{
	public partial class ParentController : UIViewController
	{
		UIView containerOne;
		UIView containerTwo;

		public ParentController () //: base ("ParentController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void LoadView ()
		{
			View = new UIView ();
			View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			View.BackgroundColor = UIColor.FromRGBA (0x88, 0x88, 0x88, 0xf0);

			containerOne = new UIView (new RectangleF (10, 100, 200, 200));
			containerOne.TranslatesAutoresizingMaskIntoConstraints = false;
			containerOne.AutosizesSubviews = true;
			containerOne.BackgroundColor = UIColor.Red;
			View.AddSubview (containerOne);

			containerTwo = new UIView (new RectangleF (10, 320, 200, 200));
			containerTwo.TranslatesAutoresizingMaskIntoConstraints = false;
			containerTwo.AutosizesSubviews = true;
			containerTwo.BackgroundColor = UIColor.Blue;
			View.AddSubview (containerTwo);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var firstChild = new LinearChildController ();
			AddChildViewController (firstChild);
			containerOne.AddSubview (firstChild.View);
			containerOne.Frame = new RectangleF (containerOne.Frame.X, containerOne.Frame.Y, containerOne.Frame.Width, firstChild.View.Frame.Height);
			firstChild.View.Frame = containerOne.Bounds;
			firstChild.DidMoveToParentViewController (this);

			var secondChild = new LinearChildController ();
			AddChildViewController (secondChild);
			containerTwo.AddSubview (secondChild.View);
			containerTwo.Frame = new RectangleF (containerTwo.Frame.X, containerOne.Frame.Y + containerOne.Frame.Height + 20, containerTwo.Frame.Width, secondChild.View.Frame.Height);
			secondChild.View.Frame = containerTwo.Bounds;
			secondChild.DidMoveToParentViewController (this);
		}
	}

}

