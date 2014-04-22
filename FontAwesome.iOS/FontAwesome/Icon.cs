using System;
using System.Linq;

namespace FontAwesome
{
	[AttributeUsage(AttributeTargets.Enum)]
	public sealed class FontAttribute : Attribute
	{
		public string Name { get; private set; }
		public FontAttribute(string name) { this.Name = name; }

	}

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public sealed class CategoryAttribute : Attribute
	{
		public string Name { get; private set; }

		public CategoryAttribute(string name) { this.Name = name; }
	}

	public static class IconExtensions
	{
		private static readonly Type _iconType = typeof(Icon);
		public static string AsString(this Icon icon)
		{
			return new string ((char)icon, 1);
		}

		public static string[] Categories(this Icon icon) 
		{
			return _iconType.GetField (Enum.GetName (_iconType, icon))
				.GetCustomAttributes (typeof(CategoryAttribute), false).OfType<CategoryAttribute> ()
				.Select (a => a.Name).ToArray ();
		}
	}

	[Font("FontAwesome")]
	public enum Icon : ushort
	{
		[Category("Web Application Icons")]
		Glass = 0xf000,
		[Category("Web Application Icons")]
		Music = 0xf001,
		[Category("Web Application Icons")]
		Search = 0xf002,
		[Category("Web Application Icons")]
		EnvelopeOutline = 0xf003,
		[Category("Web Application Icons")]
		Heart = 0xf004,
		[Category("Web Application Icons")]
		Star = 0xf005,
		[Category("Web Application Icons")]
		StarOutline = 0xf006,
		[Category("Web Application Icons")]
		User = 0xf007,
		[Category("Web Application Icons")]
		Film = 0xf008,
		[Category("Text Editor Icons")]
		ThLarge = 0xf009,
		[Category("Text Editor Icons")]
		Th = 0xf00a,
		[Category("Text Editor Icons")]
		ThList = 0xf00b,
		[Category("Web Application Icons")]
		Check = 0xf00c,
		[Category("Web Application Icons")]
		Times = 0xf00d,
		[Category("Web Application Icons")]
		SearchPlus = 0xf00e,
		[Category("Web Application Icons")]
		SearchMinus = 0xf010,
		[Category("Web Application Icons")]
		PowerOff = 0xf011,
		[Category("Web Application Icons")]
		Signal = 0xf012,
		[Category("Web Application Icons")]
		Cog = 0xf013,
		[Category("Web Application Icons")]
		TrashOutline = 0xf014,
		[Category("Web Application Icons")]
		Home = 0xf015,
		[Category("Text Editor Icons")]
		FileOutline = 0xf016,
		[Category("Web Application Icons")]
		ClockOutline = 0xf017,
		[Category("Web Application Icons")]
		Road = 0xf018,
		[Category("Web Application Icons")]
		Download = 0xf019,
		[Category("Directional Icons")]
		ArrowCircleOutlineDown = 0xf01a,
		[Category("Directional Icons")]
		ArrowCircleOutlineUp = 0xf01b,
		[Category("Web Application Icons")]
		Inbox = 0xf01c,
		[Category("Video Player Icons")]
		PlayCircleOutline = 0xf01d,
		[Category("Text Editor Icons")]
		Repeat = 0xf01e,
		[Category("Web Application Icons")]
		Refresh = 0xf021,
		[Category("Text Editor Icons")]
		ListAlt = 0xf022,
		[Category("Web Application Icons")]
		Lock = 0xf023,
		[Category("Web Application Icons")]
		Flag = 0xf024,
		[Category("Web Application Icons")]
		Headphones = 0xf025,
		[Category("Web Application Icons")]
		VolumeOff = 0xf026,
		[Category("Web Application Icons")]
		VolumeDown = 0xf027,
		[Category("Web Application Icons")]
		VolumeUp = 0xf028,
		[Category("Web Application Icons")]
		Qrcode = 0xf029,
		[Category("Web Application Icons")]
		Barcode = 0xf02a,
		[Category("Web Application Icons")]
		Tag = 0xf02b,
		[Category("Web Application Icons")]
		Tags = 0xf02c,
		[Category("Web Application Icons")]
		Book = 0xf02d,
		[Category("Web Application Icons")]
		Bookmark = 0xf02e,
		[Category("Web Application Icons")]
		Print = 0xf02f,
		[Category("Web Application Icons")]
		Camera = 0xf030,
		[Category("Text Editor Icons")]
		Font = 0xf031,
		[Category("Text Editor Icons")]
		Bold = 0xf032,
		[Category("Text Editor Icons")]
		Italic = 0xf033,
		[Category("Text Editor Icons")]
		TextHeight = 0xf034,
		[Category("Text Editor Icons")]
		TextWidth = 0xf035,
		[Category("Text Editor Icons")]
		AlignLeft = 0xf036,
		[Category("Text Editor Icons")]
		AlignCenter = 0xf037,
		[Category("Text Editor Icons")]
		AlignRight = 0xf038,
		[Category("Text Editor Icons")]
		AlignJustify = 0xf039,
		[Category("Text Editor Icons")]
		List = 0xf03a,
		[Category("Text Editor Icons")]
		Outdent = 0xf03b,
		[Category("Text Editor Icons")]
		Indent = 0xf03c,
		[Category("Web Application Icons")]
		VideoCamera = 0xf03d,
		[Category("Web Application Icons")]
		PictureOutline = 0xf03e,
		[Category("Web Application Icons")]
		Pencil = 0xf040,
		[Category("Web Application Icons")]
		MapMarker = 0xf041,
		[Category("Web Application Icons")]
		Adjust = 0xf042,
		[Category("Web Application Icons")]
		Tint = 0xf043,
		[Category("Web Application Icons")]
		PencilSquareOutline = 0xf044,
		[Category("Web Application Icons")]
		ShareSquareOutline = 0xf045,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		CheckSquareOutline = 0xf046,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		Arrows = 0xf047,
		[Category("Video Player Icons")]
		StepBackward = 0xf048,
		[Category("Video Player Icons")]
		FastBackward = 0xf049,
		[Category("Video Player Icons")]
		Backward = 0xf04a,
		[Category("Video Player Icons")]
		Play = 0xf04b,
		[Category("Video Player Icons")]
		Pause = 0xf04c,
		[Category("Video Player Icons")]
		Stop = 0xf04d,
		[Category("Video Player Icons")]
		Forward = 0xf04e,
		[Category("Video Player Icons")]
		FastForward = 0xf050,
		[Category("Video Player Icons")]
		StepForward = 0xf051,
		[Category("Video Player Icons")]
		Eject = 0xf052,
		[Category("Directional Icons")]
		ChevronLeft = 0xf053,
		[Category("Directional Icons")]
		ChevronRight = 0xf054,
		[Category("Web Application Icons")]
		PlusCircle = 0xf055,
		[Category("Web Application Icons")]
		MinusCircle = 0xf056,
		[Category("Web Application Icons")]
		TimesCircle = 0xf057,
		[Category("Web Application Icons")]
		CheckCircle = 0xf058,
		[Category("Web Application Icons")]
		QuestionCircle = 0xf059,
		[Category("Web Application Icons")]
		InfoCircle = 0xf05a,
		[Category("Web Application Icons")]
		Crosshairs = 0xf05b,
		[Category("Web Application Icons")]
		TimesCircleOutline = 0xf05c,
		[Category("Web Application Icons")]
		CheckCircleOutline = 0xf05d,
		[Category("Web Application Icons")]
		Ban = 0xf05e,
		[Category("Directional Icons")]
		ArrowLeft = 0xf060,
		[Category("Directional Icons")]
		ArrowRight = 0xf061,
		[Category("Directional Icons")]
		ArrowUp = 0xf062,
		[Category("Directional Icons")]
		ArrowDown = 0xf063,
		[Category("Web Application Icons")]
		Share = 0xf064,
		[Category("Video Player Icons")]
		Expand = 0xf065,
		[Category("Video Player Icons")]
		Compress = 0xf066,
		[Category("Web Application Icons")]
		Plus = 0xf067,
		[Category("Web Application Icons")]
		Minus = 0xf068,
		[Category("Web Application Icons")]
		Asterisk = 0xf069,
		[Category("Web Application Icons")]
		ExclamationCircle = 0xf06a,
		[Category("Web Application Icons")]
		Gift = 0xf06b,
		[Category("Web Application Icons")]
		Leaf = 0xf06c,
		[Category("Web Application Icons")]
		Fire = 0xf06d,
		[Category("Web Application Icons")]
		Eye = 0xf06e,
		[Category("Web Application Icons")]
		EyeSlash = 0xf070,
		[Category("Web Application Icons")]
		ExclamationTriangle = 0xf071,
		[Category("Web Application Icons")]
		Plane = 0xf072,
		[Category("Web Application Icons")]
		Calendar = 0xf073,
		[Category("Web Application Icons")]
		Random = 0xf074,
		[Category("Web Application Icons")]
		Comment = 0xf075,
		[Category("Web Application Icons")]
		Magnet = 0xf076,
		[Category("Directional Icons")]
		ChevronUp = 0xf077,
		[Category("Directional Icons")]
		ChevronDown = 0xf078,
		[Category("Web Application Icons")]
		Retweet = 0xf079,
		[Category("Web Application Icons")]
		ShoppingCart = 0xf07a,
		[Category("Web Application Icons")]
		Folder = 0xf07b,
		[Category("Web Application Icons")]
		FolderOpen = 0xf07c,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		ArrowsV = 0xf07d,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		ArrowsH = 0xf07e,
		[Category("Web Application Icons")]
		BarChartOutline = 0xf080,
		[Category("Brand Icons")]
		TwitterSquare = 0xf081,
		[Category("Brand Icons")]
		FacebookSquare = 0xf082,
		[Category("Web Application Icons")]
		CameraRetro = 0xf083,
		[Category("Web Application Icons")]
		Key = 0xf084,
		[Category("Web Application Icons")]
		Cogs = 0xf085,
		[Category("Web Application Icons")]
		Comments = 0xf086,
		[Category("Web Application Icons")]
		ThumbsOutlineUp = 0xf087,
		[Category("Web Application Icons")]
		ThumbsOutlineDown = 0xf088,
		[Category("Web Application Icons")]
		StarHalf = 0xf089,
		[Category("Web Application Icons")]
		HeartOutline = 0xf08a,
		[Category("Web Application Icons")]
		SignOut = 0xf08b,
		[Category("Brand Icons")]
		LinkedinSquare = 0xf08c,
		[Category("Web Application Icons")]
		ThumbTack = 0xf08d,
		[Category("Web Application Icons")]
		ExternalLink = 0xf08e,
		[Category("Web Application Icons")]
		SignIn = 0xf090,
		[Category("Web Application Icons")]
		Trophy = 0xf091,
		[Category("Brand Icons")]
		GithubSquare = 0xf092,
		[Category("Web Application Icons")]
		Upload = 0xf093,
		[Category("Web Application Icons")]
		LemonOutline = 0xf094,
		[Category("Web Application Icons")]
		Phone = 0xf095,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		SquareOutline = 0xf096,
		[Category("Web Application Icons")]
		BookmarkOutline = 0xf097,
		[Category("Web Application Icons")]
		PhoneSquare = 0xf098,
		[Category("Brand Icons")]
		Twitter = 0xf099,
		[Category("Brand Icons")]
		Facebook = 0xf09a,
		[Category("Brand Icons")]
		Github = 0xf09b,
		[Category("Web Application Icons")]
		Unlock = 0xf09c,
		[Category("Web Application Icons")]
		CreditCard = 0xf09d,
		[Category("Web Application Icons")]
		Rss = 0xf09e,
		[Category("Web Application Icons")]
		HddOutline = 0xf0a0,
		[Category("Web Application Icons")]
		Bullhorn = 0xf0a1,
		[Category("Web Application Icons")]
		Bell = 0xf0f3,
		[Category("Web Application Icons")]
		Certificate = 0xf0a3,
		[Category("Directional Icons")]
		HandOutlineRight = 0xf0a4,
		[Category("Directional Icons")]
		HandOutlineLeft = 0xf0a5,
		[Category("Directional Icons")]
		HandOutlineUp = 0xf0a6,
		[Category("Directional Icons")]
		HandOutlineDown = 0xf0a7,
		[Category("Directional Icons")]
		ArrowCircleLeft = 0xf0a8,
		[Category("Directional Icons")]
		ArrowCircleRight = 0xf0a9,
		[Category("Directional Icons")]
		ArrowCircleUp = 0xf0aa,
		[Category("Directional Icons")]
		ArrowCircleDown = 0xf0ab,
		[Category("Web Application Icons")]
		Globe = 0xf0ac,
		[Category("Web Application Icons")]
		Wrench = 0xf0ad,
		[Category("Web Application Icons")]
		Tasks = 0xf0ae,
		[Category("Web Application Icons")]
		Filter = 0xf0b0,
		[Category("Web Application Icons")]
		Briefcase = 0xf0b1,
		[Category("Video Player Icons")]
		[Category("Directional Icons")]
		ArrowsAlt = 0xf0b2,
		[Category("Web Application Icons")]
		Users = 0xf0c0,
		[Category("Text Editor Icons")]
		Link = 0xf0c1,
		[Category("Web Application Icons")]
		Cloud = 0xf0c2,
		[Category("Web Application Icons")]
		Flask = 0xf0c3,
		[Category("Text Editor Icons")]
		Scissors = 0xf0c4,
		[Category("Text Editor Icons")]
		FilesOutline = 0xf0c5,
		[Category("Text Editor Icons")]
		Paperclip = 0xf0c6,
		[Category("Text Editor Icons")]
		FloppyOutline = 0xf0c7,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		Square = 0xf0c8,
		[Category("Web Application Icons")]
		Bars = 0xf0c9,
		[Category("Text Editor Icons")]
		ListUl = 0xf0ca,
		[Category("Text Editor Icons")]
		ListOl = 0xf0cb,
		[Category("Text Editor Icons")]
		Strikethrough = 0xf0cc,
		[Category("Text Editor Icons")]
		Underline = 0xf0cd,
		[Category("Text Editor Icons")]
		Table = 0xf0ce,
		[Category("Web Application Icons")]
		Magic = 0xf0d0,
		[Category("Web Application Icons")]
		Truck = 0xf0d1,
		[Category("Brand Icons")]
		Pinterest = 0xf0d2,
		[Category("Brand Icons")]
		PinterestSquare = 0xf0d3,
		[Category("Brand Icons")]
		GooglePlusSquare = 0xf0d4,
		[Category("Brand Icons")]
		GooglePlus = 0xf0d5,
		[Category("Web Application Icons")]
		[Category("Currency Icons")]
		Money = 0xf0d6,
		[Category("Directional Icons")]
		CaretDown = 0xf0d7,
		[Category("Directional Icons")]
		CaretUp = 0xf0d8,
		[Category("Directional Icons")]
		CaretLeft = 0xf0d9,
		[Category("Directional Icons")]
		CaretRight = 0xf0da,
		[Category("Text Editor Icons")]
		Columns = 0xf0db,
		[Category("Web Application Icons")]
		Sort = 0xf0dc,
		[Category("Web Application Icons")]
		SortAsc = 0xf0dd,
		[Category("Web Application Icons")]
		SortDesc = 0xf0de,
		[Category("Web Application Icons")]
		Envelope = 0xf0e0,
		[Category("Brand Icons")]
		Linkedin = 0xf0e1,
		[Category("Text Editor Icons")]
		Undo = 0xf0e2,
		[Category("Web Application Icons")]
		Gavel = 0xf0e3,
		[Category("Web Application Icons")]
		Tachometer = 0xf0e4,
		[Category("Web Application Icons")]
		CommentOutline = 0xf0e5,
		[Category("Web Application Icons")]
		CommentsOutline = 0xf0e6,
		[Category("Web Application Icons")]
		Bolt = 0xf0e7,
		[Category("Web Application Icons")]
		Sitemap = 0xf0e8,
		[Category("Web Application Icons")]
		Umbrella = 0xf0e9,
		[Category("Text Editor Icons")]
		Clipboard = 0xf0ea,
		[Category("Web Application Icons")]
		LightbulbOutline = 0xf0eb,
		[Category("Web Application Icons")]
		Exchange = 0xf0ec,
		[Category("Web Application Icons")]
		CloudDownload = 0xf0ed,
		[Category("Web Application Icons")]
		CloudUpload = 0xf0ee,
		[Category("Medical Icons")]
		UserMd = 0xf0f0,
		[Category("Medical Icons")]
		Stethoscope = 0xf0f1,
		[Category("Web Application Icons")]
		Suitcase = 0xf0f2,
		[Category("Web Application Icons")]
		BellOutline = 0xf0a2,
		[Category("Web Application Icons")]
		Coffee = 0xf0f4,
		[Category("Web Application Icons")]
		Cutlery = 0xf0f5,
		[Category("Text Editor Icons")]
		FileTextOutline = 0xf0f6,
		[Category("Web Application Icons")]
		BuildingOutline = 0xf0f7,
		[Category("Medical Icons")]
		HospitalOutline = 0xf0f8,
		[Category("Medical Icons")]
		Ambulance = 0xf0f9,
		[Category("Medical Icons")]
		Medkit = 0xf0fa,
		[Category("Web Application Icons")]
		FighterJet = 0xf0fb,
		[Category("Web Application Icons")]
		Beer = 0xf0fc,
		[Category("Medical Icons")]
		HSquare = 0xf0fd,
		[Category("Medical Icons")]
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		PlusSquare = 0xf0fe,
		[Category("Directional Icons")]
		AngleDoubleLeft = 0xf100,
		[Category("Directional Icons")]
		AngleDoubleRight = 0xf101,
		[Category("Directional Icons")]
		AngleDoubleUp = 0xf102,
		[Category("Directional Icons")]
		AngleDoubleDown = 0xf103,
		[Category("Directional Icons")]
		AngleLeft = 0xf104,
		[Category("Directional Icons")]
		AngleRight = 0xf105,
		[Category("Directional Icons")]
		AngleUp = 0xf106,
		[Category("Directional Icons")]
		AngleDown = 0xf107,
		[Category("Web Application Icons")]
		Desktop = 0xf108,
		[Category("Web Application Icons")]
		Laptop = 0xf109,
		[Category("Web Application Icons")]
		Tablet = 0xf10a,
		[Category("Web Application Icons")]
		Mobile = 0xf10b,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		CircleOutline = 0xf10c,
		[Category("Web Application Icons")]
		QuoteLeft = 0xf10d,
		[Category("Web Application Icons")]
		QuoteRight = 0xf10e,
		[Category("Web Application Icons")]
		Spinner = 0xf110,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		Circle = 0xf111,
		[Category("Web Application Icons")]
		Reply = 0xf112,
		[Category("Brand Icons")]
		GithubAlt = 0xf113,
		[Category("Web Application Icons")]
		FolderOutline = 0xf114,
		[Category("Web Application Icons")]
		FolderOpenOutline = 0xf115,
		[Category("Web Application Icons")]
		SmileOutline = 0xf118,
		[Category("Web Application Icons")]
		FrownOutline = 0xf119,
		[Category("Web Application Icons")]
		MehOutline = 0xf11a,
		[Category("Web Application Icons")]
		Gamepad = 0xf11b,
		[Category("Web Application Icons")]
		KeyboardOutline = 0xf11c,
		[Category("Web Application Icons")]
		FlagOutline = 0xf11d,
		[Category("Web Application Icons")]
		FlagCheckered = 0xf11e,
		[Category("Web Application Icons")]
		Terminal = 0xf120,
		[Category("Web Application Icons")]
		Code = 0xf121,
		[Category("Web Application Icons")]
		ReplyAll = 0xf122,
		[Category("Web Application Icons")]
		MailReplyAll = 0xf122,
		[Category("Web Application Icons")]
		StarHalfOutline = 0xf123,
		[Category("Web Application Icons")]
		LocationArrow = 0xf124,
		[Category("Web Application Icons")]
		Crop = 0xf125,
		[Category("Web Application Icons")]
		CodeFork = 0xf126,
		[Category("Text Editor Icons")]
		ChainBroken = 0xf127,
		[Category("Web Application Icons")]
		Question = 0xf128,
		[Category("Web Application Icons")]
		Info = 0xf129,
		[Category("Web Application Icons")]
		Exclamation = 0xf12a,
		[Category("Web Application Icons")]
		Superscript = 0xf12b,
		[Category("Web Application Icons")]
		Subscript = 0xf12c,
		[Category("Text Editor Icons")]
		[Category("Web Application Icons")]
		Eraser = 0xf12d,
		[Category("Web Application Icons")]
		PuzzlePiece = 0xf12e,
		[Category("Web Application Icons")]
		Microphone = 0xf130,
		[Category("Web Application Icons")]
		MicrophoneSlash = 0xf131,
		[Category("Web Application Icons")]
		Shield = 0xf132,
		[Category("Web Application Icons")]
		CalendarOutline = 0xf133,
		[Category("Web Application Icons")]
		FireExtinguisher = 0xf134,
		[Category("Web Application Icons")]
		Rocket = 0xf135,
		[Category("Brand Icons")]
		Maxcdn = 0xf136,
		[Category("Directional Icons")]
		ChevronCircleLeft = 0xf137,
		[Category("Directional Icons")]
		ChevronCircleRight = 0xf138,
		[Category("Directional Icons")]
		ChevronCircleUp = 0xf139,
		[Category("Directional Icons")]
		ChevronCircleDown = 0xf13a,
		[Category("Brand Icons")]
		Html5 = 0xf13b,
		[Category("Brand Icons")]
		Css3 = 0xf13c,
		[Category("Web Application Icons")]
		Anchor = 0xf13d,
		[Category("Web Application Icons")]
		UnlockAlt = 0xf13e,
		[Category("Web Application Icons")]
		Bullseye = 0xf140,
		[Category("Web Application Icons")]
		EllipsisH = 0xf141,
		[Category("Web Application Icons")]
		EllipsisV = 0xf142,
		[Category("Web Application Icons")]
		RssSquare = 0xf143,
		[Category("Video Player Icons")]
		PlayCircle = 0xf144,
		[Category("Web Application Icons")]
		Ticket = 0xf145,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		MinusSquare = 0xf146,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		MinusSquareOutline = 0xf147,
		[Category("Web Application Icons")]
		LevelUp = 0xf148,
		[Category("Web Application Icons")]
		LevelDown = 0xf149,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		CheckSquare = 0xf14a,
		[Category("Web Application Icons")]
		PencilSquare = 0xf14b,
		[Category("Web Application Icons")]
		ExternalLinkSquare = 0xf14c,
		[Category("Web Application Icons")]
		ShareSquare = 0xf14d,
		[Category("Web Application Icons")]
		Compass = 0xf14e,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		CaretSquareOutlineDown = 0xf150,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		CaretSquareOutlineUp = 0xf151,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		CaretSquareOutlineRight = 0xf152,
		[Category("Currency Icons")]
		Eur = 0xf153,
		[Category("Currency Icons")]
		Gbp = 0xf154,
		[Category("Currency Icons")]
		Usd = 0xf155,
		[Category("Currency Icons")]
		Inr = 0xf156,
		[Category("Currency Icons")]
		Jpy = 0xf157,
		[Category("Currency Icons")]
		Rub = 0xf158,
		[Category("Currency Icons")]
		Krw = 0xf159,
		[Category("Currency Icons")]
		[Category("Brand Icons")]
		Btc = 0xf15a,
		[Category("Text Editor Icons")]
		File = 0xf15b,
		[Category("Text Editor Icons")]
		FileText = 0xf15c,
		[Category("Web Application Icons")]
		SortAlphaAsc = 0xf15d,
		[Category("Web Application Icons")]
		SortAlphaDesc = 0xf15e,
		[Category("Web Application Icons")]
		SortAmountAsc = 0xf160,
		[Category("Web Application Icons")]
		SortAmountDesc = 0xf161,
		[Category("Web Application Icons")]
		SortNumericAsc = 0xf162,
		[Category("Web Application Icons")]
		SortNumericDesc = 0xf163,
		[Category("Web Application Icons")]
		ThumbsUp = 0xf164,
		[Category("Web Application Icons")]
		ThumbsDown = 0xf165,
		[Category("Brand Icons")]
		YoutubeSquare = 0xf166,
		[Category("Brand Icons")]
		Youtube = 0xf167,
		[Category("Brand Icons")]
		Xing = 0xf168,
		[Category("Brand Icons")]
		XingSquare = 0xf169,
		[Category("Brand Icons")]
		[Category("Video Player Icons")]
		YoutubePlay = 0xf16a,
		[Category("Brand Icons")]
		Dropbox = 0xf16b,
		[Category("Brand Icons")]
		StackOverflow = 0xf16c,
		[Category("Brand Icons")]
		Instagram = 0xf16d,
		[Category("Brand Icons")]
		Flickr = 0xf16e,
		[Category("Brand Icons")]
		Adn = 0xf170,
		[Category("Brand Icons")]
		Bitbucket = 0xf171,
		[Category("Brand Icons")]
		BitbucketSquare = 0xf172,
		[Category("Brand Icons")]
		Tumblr = 0xf173,
		[Category("Brand Icons")]
		TumblrSquare = 0xf174,
		[Category("Directional Icons")]
		LongArrowDown = 0xf175,
		[Category("Directional Icons")]
		LongArrowUp = 0xf176,
		[Category("Directional Icons")]
		LongArrowLeft = 0xf177,
		[Category("Directional Icons")]
		LongArrowRight = 0xf178,
		[Category("Brand Icons")]
		Apple = 0xf179,
		[Category("Brand Icons")]
		Windows = 0xf17a,
		[Category("Brand Icons")]
		Android = 0xf17b,
		[Category("Brand Icons")]
		Linux = 0xf17c,
		[Category("Brand Icons")]
		Dribbble = 0xf17d,
		[Category("Brand Icons")]
		Skype = 0xf17e,
		[Category("Brand Icons")]
		Foursquare = 0xf180,
		[Category("Brand Icons")]
		Trello = 0xf181,
		[Category("Web Application Icons")]
		Female = 0xf182,
		[Category("Web Application Icons")]
		Male = 0xf183,
		[Category("Brand Icons")]
		Gittip = 0xf184,
		[Category("Web Application Icons")]
		SunOutline = 0xf185,
		[Category("Web Application Icons")]
		MoonOutline = 0xf186,
		[Category("Web Application Icons")]
		Archive = 0xf187,
		[Category("Web Application Icons")]
		Bug = 0xf188,
		[Category("Brand Icons")]
		Vk = 0xf189,
		[Category("Brand Icons")]
		Weibo = 0xf18a,
		[Category("Brand Icons")]
		Renren = 0xf18b,
		[Category("Brand Icons")]
		Pagelines = 0xf18c,
		[Category("Brand Icons")]
		StackExchange = 0xf18d,
		[Category("Directional Icons")]
		ArrowCircleOutlineRight = 0xf18e,
		[Category("Directional Icons")]
		ArrowCircleOutlineLeft = 0xf190,
		[Category("Web Application Icons")]
		[Category("Directional Icons")]
		CaretSquareOutlineLeft = 0xf191,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		DotCircleOutline = 0xf192,
		[Category("Web Application Icons")]
		[Category("Medical Icons")]
		Wheelchair = 0xf193,
		[Category("Brand Icons")]
		VimeoSquare = 0xf194,
		[Category("Currency Icons")]
		Try = 0xf195,
		[Category("Web Application Icons")]
		[Category("Form Control Icons")]
		PlusSquareOutline = 0xf196,
	}
}

