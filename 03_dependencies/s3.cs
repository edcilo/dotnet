namespace S3
{
    using System;
    using System.Threading.Tasks;
    using Amazon.S3;
    using Amazon.S3.Model;

    public class UploadResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
    }

    public class S3Client
    {
        private string BucketName;
        private IAmazonS3 Client = new AmazonS3Client();

        public S3Client(string bucketName)
        {
            BucketName = bucketName;
        }

        public async Task ListingObjectsAsync()
        {
            var request = new ListObjectsV2Request
            {
                BucketName = BucketName,
            };

            var listObjectsV2Paginator = Client.Paginators.ListObjectsV2(request);

            await foreach (var response in listObjectsV2Paginator.Responses)
            {
                Console.WriteLine($"HttpStatusCode: {response.HttpStatusCode}");
                Console.WriteLine($"Number of Keys: {response.KeyCount}");
                foreach (var entry in response.S3Objects)
                {
                    Console.WriteLine($"Key = {entry.Key}; Size = {entry.Size}");
                }
            }
        }

        public async Task<UploadResult> UploadObjectAsync(string key, string filePath)
        {
            var request = new PutObjectRequest
            {
                BucketName = BucketName,
                Key = key,
                FilePath = filePath,
            };

            try
            {
                var response = await Client.PutObjectAsync(request);
                return new UploadResult
                {
                    Success = true,
                    Message = "Upload successful",
                    StatusCode = response.HttpStatusCode
                };
            }
            catch (AmazonS3Exception e)
            {
                return new UploadResult
                {
                    Success = false,
                    Message = $"AWS error: {e.Message}",
                    StatusCode = e.StatusCode
                };
            }
            catch (Exception e)
            {
                return new UploadResult
                {
                    Success = false,
                    Message = $"Error: {e.Message}",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}