using OpenCvSharp;
using StreamClient;

var result = await TestClass.SendImagesAsync(new Mat(@"D:\test\test1.png"), new Mat(@"D:\test\test2.png"));
result.Item1.ImWrite(@"D:\test\result1.png");
result.Item2.ImWrite(@"D:\test\result2.png");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();