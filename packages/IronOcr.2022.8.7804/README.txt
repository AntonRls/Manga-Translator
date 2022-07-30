IronOCR  - The OCR & Tesseract Library for .NET 
=============================================================
Quickstart:  https://ironsoftware.com/csharp/ocr/
	

Compatibility
=============================================================
Supports applications and websites developed in:
- .NET 5 & 6
- .NET Core 2, 3 (and above) for Windows, Linux, macOS and Azure
- .NET FrameWork 4 (and above) for Windows and Azure


C# Code Example
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


Documentation
=============================================================

- Code Examples : https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/
- API Reference : https://ironsoftware.com/csharp/ocr/object-reference/
- Tutorials : https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/
- Support : developers@ironsoftware.com
