using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models.Compagnies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
	public interface ICompanyService : IBaseService
	{
		Task<List<CompanyModel>> SearchName(string Name);
		Task<List<CompanyModel>> Search(Func<SearchDescriptor<CompanyModel>, ISearchRequest> selector);
	}

	/// <summary>
	/// Gestion des sites 
	/// </summary>
	public class CompanyService : BaseService<CompanyModel>, ICompanyService
	{
		public CompanyService(IApiService ApiService, ISearchService SearchService)
			: base(ApiService, SearchService, "/api/1.0/companies")
		{

		}

		/// <summary>
		/// Recherche d'une societe
		/// </summary>
		/// <param name="selector">Query ElasticSearch</param>
		/// <returns>Liste des societes correspondant à la recherche</returns>

		public Task<List<CompanyModel>> SearchName(string Name)
		{
			List<CompanyModel> companies = new List<CompanyModel>();

			var must = new List<Func<QueryContainerDescriptor<CompanyModel>, QueryContainer>>();

			must.Add(m => m.Term(new Field("name"), Name));
			must.Add(m => m.Term(t => t.Field(f => f.Deleted).Value(false)));

			companies = _searchService.Search<CompanyModel>(s => s.Type(SearchTypeName)
																		.Query(q => q
																			.Bool(b => b
																				.Must(must)))
																		.Size(100)
																	);

			return Task.FromResult(companies);
		}

		public Task<List<CompanyModel>> Search(Func<SearchDescriptor<CompanyModel>, ISearchRequest> selector)
		{
			List<CompanyModel> companies = new List<CompanyModel>();

			companies = _searchService.Search<CompanyModel>(selector);

			return Task.FromResult(companies);
		}
	}
}
