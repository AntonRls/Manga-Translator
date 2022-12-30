IronOCR - The OCR & Tesseract Library for .NET 

# HOW TO USE
========================

ATTENTION .NET Standard, .NET Core, .NET 5.0, and .NET 6.0 Users:
You MUST add a NuGet package reference to System.Drawing.Common to your project: https://www.nuget.org/packages/System.Drawing.Common/5.0.0
Visit our website for a quick-start guide at https://ironsoftware.com/csharp/ocr/docs/

# C# Code Example
=============================================================
```
using IronOcr;
var Ocr = new IronTesseract();
using (var Input = new OcrInput("image.png"))
{
    // Input.Deskew();  // use if image not straight
    // Input.DeNoise(); // use if image contains digital noise
    var Result = Ocr.Read(Input);
    Console.WriteLine(Result.Text);
}
```

# Documentation Links
=============================================================

- Code Examples : https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/
- API Reference : https://ironsoftware.com/csharp/ocr/object-reference/
- Tutorials : https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/
- Support : developers@ironsoftware.com

# Compatibility
=============================================================
Supports applications and websites developed in:
- .NET 5 & 6
- .NET Core 2, 3 (and above) for Windows, Linux, macOS and Azure
- .NET Framework 4 (and above) for Windows and Azure