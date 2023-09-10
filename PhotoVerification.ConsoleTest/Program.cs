using MetadataExtractor;
using MetadataExtractor.Formats.Xmp;

var imagePath = @"E:\_2023-08-18_13-43-32.jpg";

var directories = ImageMetadataReader.ReadMetadata(imagePath);
foreach (var directory in directories)
    foreach (var tag in directory.Tags)
        Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");


var dir = directories.OfType<XmpDirectory>().FirstOrDefault();
if (dir is not null)
{
    var descriptor = dir.GetXmpProperties();
    foreach (var item in descriptor)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}
