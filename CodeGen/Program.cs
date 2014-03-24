using System;
using YamlDotNet.RepresentationModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeGen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("using System;");
			Console.WriteLine ("namespace FontAwesome");
			Console.WriteLine ("{");
			Console.WriteLine ("public static class Icons");
			Console.WriteLine ("{");
			using (var reader = new System.IO.StreamReader ("icons.yml")) {
				var yaml = new YamlStream();
				yaml.Load(reader);
				var root = yaml.Documents.First ().RootNode as YamlMappingNode;
				var icons = root.Children [new YamlScalarNode("icons")] as YamlSequenceNode;

				foreach (var icon in icons.Children.OfType<YamlMappingNode>()) {
					var id = icon.Children [new YamlScalarNode ("id")] as YamlScalarNode;
					var name = icon.Children [new YamlScalarNode ("name")]as YamlScalarNode;
					var unicode = icon.Children [new YamlScalarNode ("unicode")]as YamlScalarNode;

					var fieldName = id.Value;

					fieldName = Regex.Replace (fieldName, "(^.|-.)", match => {
						return match.Groups[0].Value.ToUpper();
					});

					fieldName = Regex.Replace(fieldName, "O(\\W|-|$)", "Outline");

					fieldName = Regex.Replace(fieldName, "-", string.Empty);

					Console.WriteLine ("public static readonly string {0} = \"\\u{1}\";",fieldName, unicode);
				}

			}
			Console.WriteLine ("}");
			Console.WriteLine ("}");
		}
	}
}
