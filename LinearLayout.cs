using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace ControllerHierarchy
{

	public class LinearLayout
	{
		List<LinearLayoutItem> _items = new List<LinearLayoutItem> ();
		UIView _container; // container for them views

		public LinearLayout(UIView container) {
			_container = container;
		}

		public UIView ContainerView { get { return _container; } }

		public void Add(LinearLayoutItem item) {
			_items.Add (item);
		}

		public void Add(UIView view, int margin=0, int padding=0) {
			_items.Add (new LinearLayoutItem (view, margin, padding));
		}

		public class LinearLayoutItem
		{
			public LinearLayoutItem () {}

			public LinearLayoutItem(UIView view, int margin = 5, int padding = 0) {
				View = view;
				Margin = margin;
				Padding = padding;
			}

			public UIView View { get; set; }
			public int Padding { get; set; }
			public int Margin { get; set; }
		}

		/// <summary>
		/// Adds UIViews to the container UIview and lays them out
		/// </summary>
		public void Build()
		{
			int x = 0, y = 0;

			foreach(var item in _items) {
				UIView v = item.View;

				v.Frame = new RectangleF (new PointF(x, y), v.Frame.Size);
				_container.AddSubview (v);

				y += (int) v.Frame.Height;
			}

			_container.Frame = new RectangleF (new PointF (_container.Frame.X, _container.Frame.Y), new SizeF (_container.Frame.Size.Width, y));
			Console.WriteLine ("LL Height: {0}",y);
			Console.WriteLine ("LL container frame: {0}", _container.Frame);
		}
	}
}
