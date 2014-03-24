FontAwesomeComponent
====================

Font Awesome by Dave Gandy - http://fontawesome.io

Use fontawesome in your xamarin iOS apps. Icons are rendered at the correct dpi using packaged font file.

Example
=======

```csharp
leftNavButton = new UIBarButtonItem (
  FontAwesome.WebFont.ImageOf (FontAwesome.Icons.Flag),
  UIBarButtonItemStyle.Bordered, (s,e) =>{ });
```

Setup
=====

Nuget package comming soon!

* Build FontAwesome.iOS project, add you your app.

* Add font definition to the info.plist file. Note: the font is included within the
FontAwesome.iOS dll. (Working on a solution to skip this step, suggestions welcome)
```xml
<key>UIAppFonts</key>
<array>
	<string>fontawesome-webfont.ttf</string>
</array>
```

Sample App
==========

![iphone-app](Art/sample-app.png)
