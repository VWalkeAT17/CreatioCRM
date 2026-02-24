namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LlmModelReferenceSchema

	/// <exclude/>
	public class LlmModelReferenceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LlmModelReferenceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LlmModelReferenceSchema(LlmModelReferenceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df49f534-b8ea-4202-ac3e-781f0650f206");
			Name = "LlmModelReference";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,65,107,195,48,12,133,239,129,252,135,7,187,55,247,181,236,146,195,24,164,151,238,23,168,182,154,9,108,57,216,10,35,148,254,247,197,116,221,58,86,31,132,121,124,210,123,146,82,228,50,145,99,244,153,201,36,109,250,52,73,72,214,54,231,182,193,250,230,34,58,226,125,41,198,113,219,54,87,241,41,243,40,73,209,7,42,229,25,67,136,251,228,57,28,248,196,153,213,241,141,235,186,14,187,50,199,72,121,121,249,149,6,25,63,236,147,107,69,190,245,192,18,72,49,12,123,196,58,12,46,169,145,104,181,79,26,22,112,41,172,38,20,32,190,126,78,226,106,98,133,39,163,205,157,97,247,215,113,154,143,65,28,92,205,250,40,106,101,190,151,189,195,95,103,241,120,243,56,99,100,219,162,212,114,249,71,21,203,53,95,191,142,124,68,94,126,14,198,234,175,55,107,155,85,252,2,105,9,147,211,119,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df49f534-b8ea-4202-ac3e-781f0650f206"));
		}

		#endregion

	}

	#endregion

}

