namespace PhotoVerification.Library;

public class VerificationResult
{
    public VerificationItem? CameraMake { get; set; }

    public VerificationItem? ExifSoftware { get; set; }
    public List<string>? XmpHistorySoftwareAgent { get; set; }
}
