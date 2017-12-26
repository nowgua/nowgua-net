using nowguaClient.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class FileServiceTest : BaseTest
    {
        [Fact]
        public async void DownloadTest()
        {
            var fileService = new FileService(ApiService, SearchService);
            var filebyte = await fileService.Download("5a412f990fcd2f0f2c973825");

            Assert.NotNull(filebyte);
            File.WriteAllBytes("test.png", filebyte);
        }
    }
}
