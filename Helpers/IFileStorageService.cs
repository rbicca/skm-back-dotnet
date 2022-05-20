namespace skm_back_dotnet.Helpers
{
    public interface IFileStorageService
    {
         Task<string> SaveFile(string containerName, IFormFile file);
         Task<string> EditFile(string containerName, IFormFile file, string fileRoute);
         Task DeleteFile(string fileRoute, string containerName);
    }
}