using Azure.Storage.Blobs;

namespace skm_back_dotnet.Helpers
{
    public class AzureStorageService : IFileStorageService
    {
        private string CS;
        public AzureStorageService(IConfiguration configuration)
        {
            CS = configuration.GetConnectionString("AzureStorageConnect");
        }

        public async Task DeleteFile(string fileRoute, string containerName)
        {
            if(string.IsNullOrEmpty(fileRoute)) { return; }

            var client = new BlobContainerClient(CS, containerName);
            await client.CreateIfNotExistsAsync();
            var fileName = Path.GetFileName(fileRoute);
            var blob = client.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();

        }

        public async Task<string> EditFile(string containerName, IFormFile file, string fileRoute)
        {
            await DeleteFile(fileRoute, containerName);

            return await SaveFile(containerName, file);
        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            var client = new BlobContainerClient(CS, containerName);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);
            await blob.UploadAsync(file.OpenReadStream());

            return blob.Uri.ToString();
            
        }
    }
}