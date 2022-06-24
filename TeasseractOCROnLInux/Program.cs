// See https://aka.ms/new-console-template for more information

using TesseractOCR;
using TesseractOCR.Enums;

var testImagePath = "./in/scan1.png";
using var engine = new Engine(@"./tessdata", Language.English, EngineMode.Default);
using var img = TesseractOCR.Pix.Image.LoadFromFile(testImagePath);
using var page = engine.Process(img);
Console.WriteLine("Mean confidence: {0}", page.MeanConfidence);
Console.WriteLine("Text: \r\n{0}", page.Text);
