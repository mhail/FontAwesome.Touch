using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.Linq;

namespace FontAwesome.Sample.iOS
{
	[Register ("IconsViewController")]
	public class IconsViewController : UITableViewController
	{

		public IconsViewController () : base(UITableViewStyle.Plain)
		{
		}

		UIBarButtonItem rightNavButton;
		UIBarButtonItem leftNavButton;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) { 
				this.EdgesForExtendedLayout = UIRectEdge.None;
			}

			leftNavButton = new UIBarButtonItem (FontAwesome.WebFont.ImageOf (FontAwesome.Icons.Flag, 30), UIBarButtonItemStyle.Bordered, (s,e) =>{ 
				var av = new UIAlertView ("Font Awesome", "Flag Icon", null, "OK", null);

				av.Show ();
			});

			rightNavButton = new UIBarButtonItem (FontAwesome.WebFont.ImageOf (FontAwesome.Icons.CloudDownload, 30), UIBarButtonItemStyle.Bordered, (s,e) =>{ 

			});

			this.NavigationItem.SetLeftBarButtonItem(leftNavButton, true);
			this.NavigationItem.Title = "FontAwesome";
			this.NavigationItem.SetRightBarButtonItem(rightNavButton, true);

			this.TableView.Source = new IconsViewSource ();
		}

		public class IconsViewSource : UITableViewSource
		{
			private IDictionary<string, string> items = new Dictionary<string, string> ();
			private string cellIdentifier = "FontAwesomeIconCell";

			public IconsViewSource() : base()
			{
				foreach (var field in typeof(FontAwesome.Icons).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
				{
					items.Add( field.Name, field.GetValue(null) as string);
				}
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return items.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier) ?? new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

				var key = items.Keys.ElementAt (indexPath.Row);
				cell.TextLabel.Text = key;
				cell.ImageView.Image = FontAwesome.WebFont.ImageOf (items[key], 30.0f, UIColor.Black);

				return cell;
			}
		}
	}
}

