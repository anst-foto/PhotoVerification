using PhotoVerification.Library;

var imagePath = @"E:\_2023-08-18_13-43-32.jpg";

var builder = new VerificationResultBuilder(imagePath);
var result = builder
    .VerificationCameraMake()
    .VerificationExifSoftware()
    .VerificationXmpHistorySoftwareAgent()
    .GetResult();

if (result.CameraMake is null)
{
    Console.WriteLine("[EXIF] Отсутствует информация о камере");
}
else
{
    Console.WriteLine(result.CameraMake.Exist == false
        ? "[EXIF] Отсутствует информация о камере"
        : $"[EXIF] Камера - {result.CameraMake.Value}");
}

if (result.ExifSoftware is null)
{
    Console.WriteLine("[EXIF] Отсутствует информация о приложении");
}
else
{
    Console.WriteLine(result.CameraMake.Exist == false
        ? "[EXIF] Отсутствует информация о приложении"
        : $"[EXIF] Приложение - {result.ExifSoftware.Value}");
}

if (result.XmpHistorySoftwareAgent is null)
{
    Console.WriteLine("[XMP] Отсутствует информация об истории приложений");
}
else
{
    if (result.XmpHistorySoftwareAgent.Count == 0)
    {
        Console.WriteLine("[XMP] Отсутствует информация об истории приложений");
    }
    else
    {
        foreach (var soft in result.XmpHistorySoftwareAgent)
        {
            Console.WriteLine($"[XMP] Приложение - {soft}");
        }
    }
}
