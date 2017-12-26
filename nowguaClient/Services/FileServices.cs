using nowguaClient.Helpers;
using nowguaClient.Models.Files;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IFileService : IBaseService
    {
        Task<byte[]> Download(string Id);
    }

    /// <summary>
    /// Gestion des fichiers (images, vidéos, pdf etc ...)
    /// </summary>
    public class FileService : BaseService<FileModel>, IFileService
    {
        public FileService(IApiService ApiService, ISearchService SearchService) 
            : base(ApiService, SearchService, "/api/1.0/files")
        {

        }

        /// <summary>
        /// Téléchargement d'un fichier
        /// </summary>
        /// <param name="Id">Identifiant du fichier à télécharger</param>
        /// <returns></returns>
        public Task<byte[]> Download(string Id)
        {
            return _apiService.Download(Id);
        }        
    }
}