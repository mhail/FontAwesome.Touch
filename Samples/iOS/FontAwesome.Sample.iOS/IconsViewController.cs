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

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

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

