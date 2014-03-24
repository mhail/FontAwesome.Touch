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

Sample App
==========

![iphone-app](Art/sample-app.png)
