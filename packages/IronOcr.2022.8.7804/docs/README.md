![Passing]( https://img.shields.io/badge/build-passing%20%E2%9C%93%20996%20tests%20(0%20failed)-brightgreen "passing") ![Nuget](https://img.shields.io/nuget/v/IronOcr)  ![Downloads]( https://img.shields.io/nuget/dt/IronOcr "Downloads")  ![Support]( https://img.shields.io/badge/support-active-blue "Support")

## IronOCR is an advanced OCR (Optical Character Recognition) library for C# and .NET

- Support for *.NET 6, 5, Core, Standard, and Framework* 
- Barcode, QR Code, and text detection
- Performance tuned above and beyond any other known build of Tesseract OCR

### Fully Supports:
Windows, macOS, Linux, Azure, Docker and AWS 

### Licensing & Support available
- For code examples, tutorials and documentation visit https://ironsoftware.com/csharp/ocr/
- Email: developers@ironsoftware.com 

## Get Started Code Example

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


## Documentation Links

- Code Samples : https://ironsoftware.com/csharp/ocr/
- Licensing : https://ironsoftware.com/csharp/ocr/licensing/
- Support : developers@ironsoftware.com

## Compatibility

Welcome to the cutting edge of .NET OCR technology with IronOCR 2022 with full support for:

- C#, F#, and VB.NET
- .Net 6, 5, Core 2x & 3x, Standard 2, and Framework 4x
- Console, Web, & Desktop Apps
- Windows, Linux (Debian, CentOS, Ubuntu), MacOs, Docker, and Azure
- Microsoft Visual Studio or Jetbrains ReSharper & Rider

You can email us at developers@ironsoftware.com for support directly from our code team. We offer licensing and extensive support for commercial deployment projects.