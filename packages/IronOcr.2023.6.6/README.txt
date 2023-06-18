IronOCR - The OCR & Tesseract Library for .NET 

# HOW TO USE
========================
Visit our website for a quick-start guide at https://ironsoftware.com/csharp/ocr/docs/

# C# Code Example
=============================================================
```
using IronOcr;

var ocr = new IronTesseract();

using (var ocrInput = new OcrInput())
{
    ocrInput.AddImage("image.png");
    ocrInput.AddPdf("document.pdf");
    
    // Optionally Apply Filters if needed:
    // ocrInput.Deskew();  // use only if image not straight
    // ocrInput.DeNoise(); // use only if image contains digital noise
    
    var ocrResult = ocr.Read(ocrInput);
    Console.WriteLine(ocrResult.Text);
}
```

# Documentation Links
=============================================================

- Code Examples : https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/
- Tutorials     : https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/
- How-To        : https://ironsoftware.com/csharp/ocr/how-to/csharp-tesseract-config-configuration-variables/
- API Reference : https://ironsoftware.com/csharp/ocr/object-reference/
- Support       : developers@ironsoftware.com

# Compatibility
=============================================================
Supports applications and websites developed in:
- .NET 5, 6, & 7
- .NET Core 2, 3 (and above) for Windows, Linux, macOS and Azure
- .NET Framework 4.6.2 (and above) for Windows and Azure