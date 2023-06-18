![Nuget](https://img.shields.io/nuget/v/IronOcr?color=informational&label=latest)  ![Installs](https://img.shields.io/nuget/dt/IronOcr?color=informational&label=installs&logo=nuget)  ![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20392%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)  [![windows](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) ![macOS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple) [![linux](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/tesseract-ocr-setup-linux-ubuntu-debian/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![docker](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/csharp-tesseract-ocr-docker-linux-setup-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) ![aws](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws) [![microsoftazure](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/ocr/docs/questions/iron-ocr-azure-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![livechat](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)


# IronOCR - The advanced Optical Character Recognition library for .NET

[![IronOCR NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Get Started](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Code Examples](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Licensing](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Free Trial](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronOCR is a library developed and maintained by Iron Software that helps C# Software Engineers to perform Optical Character Recognition, Barcode Scanning, and Text Extraction in projects in .NET.

### IronOCR excels at: 
- Reading text from many formats such as images (jpg, png, gif, tiff, bmp), gif, tif/tiff, streams, and PDFs
- Correcting low quality scans and photos with a [plethora or filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/) such as Deskew, Denoise, Binarize, Enhance Resolution, Dilate, and many more
- Reading barcodes from over 20 Barcode formats and QR Code Support
- Utilizing the latest build of Tesseract OCR performance tuned above and beyond any other
- Exporting Searchable PDFs, hOCR / HTML Exporting, and image content text

### IronOCR has cross platform support compatibility with:
- **.NET 7**, .NET 6 .NET 5, .NET Core, Standard, and Framework
- Windows, macOS, Linux, Docker, Azure, and AWS

[![IronOCR Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Additionally, our [API reference](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [full licensing information](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) can easily be found on our website.

## Using IronOCR

Installing the IronOCR NuGet package is quick and easy, please install the package like this:
```
PM> Install-Package IronOCR
```
Once installed, you can get started by adding `using IronOcr` to the top of your C# code. Here is is sample image text scan reading example to get started:
```csharp
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
## Features Table
[![IronOCR Features](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/features-table.png)](https://ironsoftware.com/csharp/ocr/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

Welcome to the cutting edge of .NET OCR technology with IronOCR 2023 with full support for:
- C#, F#, and VB.NET
- .NET 7, 6, 5, Core 2x & 3x, Standard 2, and Framework 4.6.2+
- Console, Web, and Desktop Apps
- Windows, Linux (Debian, CentOS, Ubuntu), MacOs, Docker, AWS, and Azure
- Microsoft Visual Studio or JetBrains ReSharper & Rider
- Barcode, QR Code, and Text detection

### Licensing & Support available
For code examples, tutorials and documentation visit [https://ironsoftware.com/csharp/ocr/](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)

For more support and inquiries, please email us at:  developers@ironsoftware.com 

## Documentation Links
-   Code Examples : [https://ironsoftware.com/csharp/ocr/examples/](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   API Reference : [https://ironpdf.com/object-reference/api/](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   Tutorials : [https://ironsoftware.com/csharp/ocr/tutorials/](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   Licensing : [https://ironsoftware.com/csharp/ocr/licensing/](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Live Chat Support : [https://ironsoftware.com/csharp/ocr/#helpscout-support](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)
