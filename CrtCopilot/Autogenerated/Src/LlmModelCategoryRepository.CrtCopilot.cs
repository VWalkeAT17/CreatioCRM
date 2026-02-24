namespace Creatio.Copilot
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ILlmModelCategoryRepository

	public interface ILlmModelCategoryRepository
	{
		LlmModelReference FindLlmModelByCategoryCode(string code);
	}

	#endregion

	#region Class: LlmModelCategoryRepository

	[DefaultBinding(typeof(ILlmModelCategoryRepository))]
	public class LlmModelCategoryRepository : ILlmModelCategoryRepository
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public LlmModelCategoryRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		public LlmModelReference FindLlmModelByCategoryCode(string code) {
			if (string.IsNullOrEmpty(code)) {
				return null;
			}
			var cacheKey = $"LlmModelCategory:{code}";
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "LlmModelCategory") {
				CacheItemName = cacheKey
			};
			esq.AddColumn("Id");
			esq.AddColumn("DefaultLlmModel.Code");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Code", code));
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			Entity entity = entities.FirstOrDefault();
			if (entity != null) {
				var result = new LlmModelReference {
					Id = entity.GetTypedColumnValue<Guid>("Id"),
					Code = entity.GetTypedColumnValue<string>("DefaultLlmModel.Code")
				};
				return result;
			}
			return new LlmModelReference();
		}

		#endregion

	}

	#endregion

}

