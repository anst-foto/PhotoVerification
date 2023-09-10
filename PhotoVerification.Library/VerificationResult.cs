namespace PhotoVerification.Library;

public class VerificationResult
{
    public bool? ExifNull { get; set; }

    public VerificationItem? CameraID { get; set; }
    public VerificationItem? CameraMake { get; set; }
    public VerificationItem? CameraModel { get; set; }

    public VerificationItem? ExifSoftware { get; set; }
    public VerificationItem? XmpPhotoshop { get; set; }
}
