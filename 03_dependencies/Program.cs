using S3;

namespace _03_Dependencies
{
    public class Program
    {
        private const string BucketName = "carrier-hub-develop-assets";

        public static async Task Main()
        {
            // Create an instance of the S3Client class
            var s3 = new S3Client(BucketName);

            // List objects
            // await s3.ListingObjectsAsync();

            // Upload an object
            var uploadResult = await s3.UploadObjectAsync("foo/bar/zoo/example.pdf", "./example.pdf");
            if (uploadResult.Success)
            {
                Console.WriteLine("Upload successful");
            }
            else
            {
                Console.WriteLine($"Upload failed: {uploadResult.Message}");
            }
        }
    }
}
