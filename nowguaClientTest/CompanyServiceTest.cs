using nowguaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
	public class CompanyServiceTest : BaseTest
	{
		//Test de recherche de la societe semaintex avec le user connecter dans CompanyPublics sur elk
		[Fact]
		public async void SearchOnPublicTest()
		{
			var ng = new NowguaClient(ConnectionSettings);

			var Companies = await ng.Companies.SearchOnPublic("SEMAINTEX");
			Assert.NotNull(Companies);
			Assert.NotEmpty(Companies);
			Assert.True(Companies.Exists(s => s.Id == "59382cafb492ea18acbd9a79"));
		}

		//Test de recherche de la societe semaintex avec le user connecter sans droit sur cette societe sur ELK
		[Fact]
		public async void SearchTest()
		{
			var ng = new NowguaClient(ConnectionSettings);

			var Companies = await ng.Companies.SearchName("SEMAINTEX");
			Assert.NotNull(Companies);
			Assert.Empty(Companies);
		}
	}
}
