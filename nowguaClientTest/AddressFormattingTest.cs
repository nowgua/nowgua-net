using nowgaApi.Core.Helpers;
using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
	public class ConvertStringToAddressTest : BaseTest
	{

		[Theory]
		[InlineData("10 rue des chaligny nancy", AddressMode.AutoCompletionMode)]
		[InlineData("Plaine commune habitat", AddressMode.FreeMode)]
		[InlineData("10 re des chaligny", AddressMode.AutoCompletionMode)]
		[InlineData("BNP RUE PROLO", AddressMode.FreeMode)]
		[InlineData("CHEZ TOI A AULNAY", AddressMode.FreeMode)]
		[InlineData("5bisRueDanielle Casanova", AddressMode.AutoCompletionMode)]
		[InlineData("LOGEMENT INDIVIDUEL", AddressMode.FreeMode)]
		[InlineData("FERRACIN FRERES", AddressMode.FreeMode)]
		[InlineData("Efficience Fayat 95 Louvres", AddressMode.FreeMode)]
		[InlineData("Plaine commune habitat", AddressMode.FreeMode)]

		public void GetAddress(string AddressString, AddressMode AddressModeReponse)
		{
			var formatter = new Formatter();
			Address test = formatter.ConvertStringToAddress(AddressString);

			Assert.Equal(test.AddressMode, AddressModeReponse);
		}
	}
}
