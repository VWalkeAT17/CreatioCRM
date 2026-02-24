namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LlmModelRepositorySchema

	/// <exclude/>
	public class LlmModelRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LlmModelRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LlmModelRepositorySchema(LlmModelRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50c6d782-e37c-4a65-8807-5528565905ff");
			Name = "LlmModelRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,219,110,219,48,12,125,118,128,252,131,144,190,200,64,225,15,104,150,61,196,77,10,3,221,5,203,134,62,12,195,160,218,116,43,64,150,60,74,234,102,12,249,247,81,190,108,177,227,102,132,1,91,228,33,121,14,105,105,81,129,173,69,14,44,69,16,78,154,36,53,181,84,198,45,23,191,151,11,70,230,173,212,79,236,208,88,7,213,250,212,245,25,16,133,53,165,163,20,132,11,161,228,118,75,209,104,54,180,23,185,51,40,193,6,68,87,226,10,225,73,26,205,50,237,0,75,162,118,195,178,123,85,189,51,5,168,79,80,27,43,41,163,89,46,58,116,237,31,149,204,153,28,192,243,216,128,236,245,4,251,7,41,1,65,83,214,94,234,98,219,164,228,228,214,97,32,154,211,119,220,171,58,14,221,174,64,23,29,189,191,158,158,109,170,132,181,55,108,158,104,244,245,22,74,225,149,219,82,27,42,206,93,83,131,41,249,12,215,56,254,54,18,150,135,186,51,101,217,43,83,153,40,173,81,190,8,7,140,150,91,24,173,26,246,197,2,166,70,107,200,93,160,253,221,143,206,235,65,214,9,131,243,46,124,82,100,92,35,62,237,31,108,210,131,109,216,89,211,1,122,188,216,255,63,203,10,125,163,40,146,37,235,221,73,102,223,123,165,62,224,174,170,93,195,91,208,128,138,16,156,71,205,52,1,214,173,231,56,102,253,34,144,89,80,68,145,8,107,248,201,14,237,129,79,212,196,227,172,96,244,103,43,95,105,190,202,138,213,165,112,16,48,11,216,163,169,248,106,208,61,11,121,120,166,89,12,37,72,231,238,135,23,138,119,149,147,143,2,233,90,211,133,24,36,11,219,179,95,143,75,221,121,89,48,122,54,189,210,100,247,11,114,239,224,144,11,37,240,77,8,191,229,241,36,41,204,55,228,108,218,244,164,157,237,217,206,131,141,39,124,26,153,140,122,0,210,144,207,151,221,175,43,11,44,101,113,221,157,130,110,58,7,121,221,238,198,255,80,255,154,187,179,228,254,3,161,182,231,247,244,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50c6d782-e37c-4a65-8807-5528565905ff"));
		}

		#endregion

	}

	#endregion

}

