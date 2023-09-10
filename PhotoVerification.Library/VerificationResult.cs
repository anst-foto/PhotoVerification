namespace PhotoVerification.Library;

public class VerificationResult
{
    public bool? ExifNull { get; set; }

    public bool? CameraID { get; set; }
    public bool? CameraMake { get; set; }
    public bool? CameraModel { get; set; }

    public bool? Software { get; set; }

    public bool? Data { get; set; }
}
