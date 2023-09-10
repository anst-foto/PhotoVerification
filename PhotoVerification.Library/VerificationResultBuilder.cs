namespace PhotoVerification.Library;

using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Xmp;

public class VerificationResultBuilder
{
    private readonly IEnumerable<Directory> directories;

    private readonly VerificationResult result;

    public VerificationResultBuilder(string path)
    {
        this.directories = ImageMetadataReader.ReadMetadata(path);
        this.result = new VerificationResult();
    }

    private VerificationItem VerificationExifItem(int tagType)
    {
        var ifd0 = this.directories.OfType<ExifIfd0Directory>().FirstOrDefault();
        var tag = ifd0?.GetDescription(tagType);

        if (tag is null)
        {
            return new VerificationItem { Exist = false };
        }

        return new VerificationItem { Exist = true, Value = tag };
    }

    public VerificationResultBuilder VerificationCameraMake()
    {
        this.result.CameraMake = this.VerificationExifItem(ExifDirectoryBase.TagMake);

        return this;
    }

    public VerificationResultBuilder VerificationExifSoftware()
    {
        this.result.ExifSoftware = this.VerificationExifItem(ExifDirectoryBase.TagSoftware);

        return this;
    }

    public VerificationResultBuilder VerificationXmpHistorySoftwareAgent()
    {
        var xmp = this.directories.OfType<XmpDirectory>().FirstOrDefault();
        var dictionary = xmp?.GetXmpProperties();

        this.result.XmpHistorySoftwareAgent = new List<string>();

        if (dictionary is null)
        {
            return this;
        }

        foreach (var key in dictionary.Keys)
        {
            if (key.Contains("softwareAgent"))
            {
                this.result.XmpHistorySoftwareAgent.Add(dictionary[key]);
            }
        }

        return this;
    }

    public VerificationResult GetResult() => this.result;
}
