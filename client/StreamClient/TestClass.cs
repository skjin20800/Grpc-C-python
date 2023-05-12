using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.Drawing.Imaging;
using ImageProcessing;

namespace StreamClient
{
	public class TestClass
	{
		// Mat 이미지를 Proto 메시지로 변환하는 함수
		public static ImageRequest ToImageRequest(Mat image1, Mat image2)
		{
			var request = new ImageRequest();

			// Mat 이미지를 바이트 배열로 변환하여 Proto 메시지에 할당
			request.Image1 = ByteString.CopyFrom(image1.ToBytes());
			request.Image2 = ByteString.CopyFrom(image2.ToBytes());

			return request;
		}
		public static async Task<(Mat, Mat, int)> SendImagesAsync(Mat image1, Mat image2)
		{
		
			using var channel = GrpcChannel.ForAddress("http://localhost:50052");
			var client = new ImageProcessingService.ImageProcessingServiceClient(channel);
			while (true)
			{
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(100);
				await requestMethod(client, image1, image2);
				await Task.Delay(5000);
			}
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			await requestMethod(client, image1, image2);
			var result = await requestMethod(client, image1, image2);
		
			return result;
		}
		public static int i = 0;
		private static async Task<(Mat, Mat, int)> requestMethod(ImageProcessingService.ImageProcessingServiceClient client , Mat image1, Mat image2) {
			Stopwatch sw = new Stopwatch();
			sw.Start();
			// Mat 이미지를 Proto 메시지로 변환하여 gRPC 서버에 전송

			var request = ToImageRequest(image1, image2);

			//Console.WriteLine("ToImageRequest Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
			sw.Restart();
			using var call = client.ProcessImages(request);

			//Console.WriteLine("요청 및 응답 시간 Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
			if(sw.ElapsedMilliseconds > 20) { Console.WriteLine($"요청 및 응답 시간 : {sw.ElapsedMilliseconds} ms count {i}");  i++; }
			sw.Restart();
			Mat resultImage1 = null;
			Mat resultImage2 = null;
			int value = 0;

			// 서버로부터 스트리밍되는 Proto 메시지를 받아서 처리
			await foreach (var response in call.ResponseStream.ReadAllAsync())
			{
				//Console.WriteLine("포문 시작 전 경과시간 {0} ms", sw.ElapsedMilliseconds);
				if (sw.ElapsedMilliseconds > 20) { Console.WriteLine($"포문 시작 전 경과시간 : {sw.ElapsedMilliseconds} ms count {i}"); i++; }
				sw.Restart();
				if (response.ResultImage1 != null && response.ResultImage1.Length > 0)
				{
					resultImage1 = GetImageMat(response.ResultImage1.ToByteArray());
				}
				//Console.WriteLine("Result 1번 경과시간 {0} ms", sw.ElapsedMilliseconds);
				if (sw.ElapsedMilliseconds > 20) { Console.WriteLine($"Result 1번 경과시간 : {sw.ElapsedMilliseconds} ms count {i}"); i++; }
				sw.Restart();
				if (response.ResultImage2 != null && response.ResultImage2.Length > 0)
				{
					resultImage2 = GetImageMat(response.ResultImage2.ToByteArray());
				}
				//Console.WriteLine("Result 2번 경과시간 {0} ms", sw.ElapsedMilliseconds);
				if (sw.ElapsedMilliseconds > 20) { Console.WriteLine($"Result 2번 경과시간 : {sw.ElapsedMilliseconds} ms count {i}"); i++; }
				sw.Restart();

				value = response.Value;
				//Console.WriteLine("Result 3번 경과시간 {0} ms", sw.ElapsedMilliseconds);
				sw.Restart();
			}
			//Console.WriteLine("마무리 Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
			sw.Stop();

			return (resultImage1, resultImage2, value);
		}
		public static Mat GetImageMat(byte[] imageData)
		{

			// Stopwatch 객체 생성
			Stopwatch sw = new Stopwatch();

			// 시간 측정 시작
			sw.Start();
			if (imageData == null || imageData.Length == 0)
			{
				return null;
			}
			Mat imageMat = null;
			using (var ms = new MemoryStream(imageData))
			using (var bitmap = new Bitmap(ms))
			{
				// Bitmap 이미지를 Mat으로 변환
				var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				IntPtr dataPtr = Marshal.AllocHGlobal(bitmapData.Stride * bitmapData.Height);
				byte[] data = new byte[bitmapData.Stride * bitmapData.Height];
				Marshal.Copy(bitmapData.Scan0, data, 0, data.Length);
				Marshal.Copy(data, 0, dataPtr, data.Length);
				imageMat = new Mat(bitmap.Height, bitmap.Width, MatType.CV_8UC4, dataPtr);
				bitmap.UnlockBits(bitmapData);
			}
			sw.Stop();

			// 경과 시간 출력
			// Console.WriteLine("GetImageMat Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
			return imageMat;
		}

	}
}