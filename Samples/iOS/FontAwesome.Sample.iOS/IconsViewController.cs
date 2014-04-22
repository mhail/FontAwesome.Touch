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

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			/*
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) { 
				this.EdgesForExtendedLayout = UIRectEdge.None;
			}
			*/

			rightNavButton = new UIBarButtonItem (FontAwesome.Icon.CloudDownload.ToUIImage(30), UIBarButtonItemStyle.Bordered, (s,e) =>{ 
				UIApplication.SharedApplication.OpenUrl(new NSUrl("https://github.com/mhail/FontAwesomeComponent"));
			});
			this.Title = "FontAwesome";
			this.NavigationItem.SetRightBarButtonItem(rightNavButton, true);

			this.TableView.Source = new IconsViewSource ();
		}

		public class IconsViewSource : UITableViewSource
		{
			static Icon[] _icons = (Icon[])Enum.GetValues(typeof(Icon));
			static string[] _groups = _icons.SelectMany (i => i.Categories ()).Distinct ().OrderBy(g=>g) .ToArray ();
			static IDictionary<string, Icon[]> _lookup = _groups.ToDictionary (g => g, g => _icons.Where (i => i.Categories ().Contains (g)).ToArray ());

			private string cellIdentifier = "FontAwesomeIconCell";

			public IconsViewSource() : base()
			{
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return _groups.Length;
			}

			public override string TitleForHeader (UITableView tableView, int section)
			{
				return _groups [section];
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return _lookup[_groups[section]].Length;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier) ?? new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);

				var value =  _lookup[_groups[indexPath.Section]] [indexPath.Row];
				cell.TextLabel.Text = Enum.GetName(typeof(Icon), value);
				cell.DetailTextLabel.Text = string.Join(", ", value.Categories());
				cell.ImageView.Image = value.ToUIImage(30.0f, UIColor.Black);

				return cell;
			}
		}
	}
}

