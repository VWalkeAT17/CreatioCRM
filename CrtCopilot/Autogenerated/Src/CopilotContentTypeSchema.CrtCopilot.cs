namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CopilotContentTypeSchema

	/// <exclude/>
	public class CopilotContentTypeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CopilotContentTypeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CopilotContentTypeSchema(CopilotContentTypeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9bb83cd8-c94e-4aab-ad1a-77a733ec50ec");
			Name = "CopilotContentType";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,77,10,2,49,12,70,215,22,230,14,97,246,122,1,113,85,188,193,224,190,134,40,129,54,45,109,212,17,241,238,166,254,128,155,129,64,248,200,123,225,147,144,168,149,128,4,190,82,80,206,27,159,11,199,172,131,123,12,110,85,46,199,200,8,77,237,132,128,49,180,6,95,192,103,81,18,157,238,133,12,236,240,143,198,44,77,205,169,44,103,152,104,86,216,193,168,182,199,237,18,117,96,186,237,35,37,123,216,225,171,197,53,125,242,178,100,13,78,92,83,111,45,221,194,191,252,182,158,131,179,121,1,158,16,170,80,227,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9bb83cd8-c94e-4aab-ad1a-77a733ec50ec"));
		}

		#endregion

	}

	#endregion

}

