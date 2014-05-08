using System;
using NUnit.Framework;
using System.Linq;

namespace FontAwesome.Touch.Tests
{
	[TestFixture]
	public class IconsExtensionsTests
	{
		[Test]
		public void IconToUIImageIsNotNull ()
		{
			var image = FontAwesome.Touch.Icon.Flag.ToUIImage ();
			Assert.IsNotNull (image, "Image was not generated");
			if (null != image) {
				image.Dispose ();
			}
		}

		[Test]
		public void IconToStringReturnsSingleCharactor()
		{
			var str = FontAwesome.Touch.Icon.Flag.AsString ();

			Assert.IsNotNull (str);

			Assert.AreEqual (1, str.Length);
		}

		[Test]
		public void IconCategoryReturnsNoEmptyArray()
		{
			var categories = FontAwesome.Touch.Icon.Flag.Categories();

			Assert.IsNotNull (categories);

			Assert.IsTrue (categories.Contains("Web Application Icons"));
		}
	}
}
