using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.Linq;
using FontAwesome.Touch;

namespace FontAwesome.Viewer
{
	[Register ("IconsViewController")]
	public class IconsViewController : UITableViewController
	{

		public IconsViewController () : base(UITableViewStyle.Plain)
		{
		}

		UIBarButtonItem rightNavButton;
		UISearchBar searchBar;
		IconsViewSource dataSource;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			rightNavButton = new UIBarButtonItem (FontAwesome.Touch.Icon.CloudDownload.ToUIImage(30), UIBarButtonItemStyle.Bordered, (s,e) =>{
				UIApplication.SharedApplication.OpenUrl(new NSUrl("https://github.com/mhail/FontAwesome.Touch"));
			});
			this.Title = "FontAwesome";
			this.NavigationItem.SetRightBarButtonItem(rightNavButton, true);

			this.TableView.Source = (dataSource = new IconsViewSource ());

			searchBar = new UISearchBar (){
				//ShowsCancelButton = true,
				Placeholder = "Search",
				AutocorrectionType = UITextAutocorrectionType.No,
				AutocapitalizationType = UITextAutocapitalizationType.None,
			};
			searchBar.SizeToFit ();
			searchBar.SearchButtonClicked += (sender, e) => {
				Search ();
			};
			/*
			searchBar.CancelButtonClicked += (sender, e) => {
				searchBar.Text = null;
				Search ();
			};
			*/
			dataSource.IconSelected += (sender, e) => {
				searchBar.ResignFirstResponder ();
			};

			TableView.TableHeaderView = searchBar;
		}

		void Search ()
		{
			searchBar.ResignFirstResponder ();
			dataSource.SearchText = searchBar.Text;
			TableView.ReloadData ();
		}

		public class IconsViewSource : UITableViewSource
		{
			private string cellIdentifier = "FontAwesomeIconCell";

			static Icon[] _icons = (Icon[])Enum.GetValues(typeof(Icon));

			public string SearchText { get; set; }

			public IEnumerable<Icon> Icons
			{
				get {
					if (string.IsNullOrWhiteSpace (SearchText)) {
						return _icons;
					}
					return _icons.Where (i =>{
						var name = i.ToString ();
						return name.StartsWith(SearchText, StringComparison.CurrentCultureIgnoreCase) ||
							name.EndsWith(SearchText, StringComparison.CurrentCultureIgnoreCase) ||
							name.Contains (SearchText);
					});
				}
			}

			public IEnumerable<string> Groups
			{
				get {
					return Icons.SelectMany (i => i.Categories ()).Distinct().OrderBy(g=>g);
				}
			}

			public IEnumerable<Icon> IconsInCategory(string category)
			{
				return Icons.Where (i => i.Categories ().Contains (category));
			}

			public IconsViewSource() : base()
			{
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return Groups.Count();
			}

			public override string TitleForHeader (UITableView tableView, int section)
			{
				return Groups.ElementAt (section);
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return IconsInCategory (Groups.ElementAt (section)).Count ();
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier) ?? new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);

				var value =  IconsInCategory (Groups.ElementAt (indexPath.Section)).ElementAt(indexPath.Row);
				cell.TextLabel.Text = Enum.GetName(typeof(Icon), value);
				cell.DetailTextLabel.Text = string.Join(", ", value.Categories());
				cell.ImageView.Image = value.ToUIImage(30.0f, UIColor.Black);

				return cell;
			}
			public event EventHandler IconSelected;

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				if (null != IconSelected)
					IconSelected (this, null);
			}
		}
	}
}
