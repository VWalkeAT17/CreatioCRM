namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICopilotToolProcessorSchema

	/// <exclude/>
	public class ICopilotToolProcessorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICopilotToolProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICopilotToolProcessorSchema(ICopilotToolProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45ff5045-0bfb-49fc-bfdd-55d44048d58c");
			Name = "ICopilotToolProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,81,219,106,2,49,16,125,86,240,31,6,124,177,176,228,3,108,43,148,69,236,66,5,169,254,192,184,59,186,129,108,34,153,44,180,72,255,189,147,172,235,165,181,47,125,74,102,114,206,153,57,39,22,27,226,3,150,4,185,39,12,218,169,220,29,180,113,97,52,60,142,134,131,150,181,221,195,250,147,3,53,242,98,12,149,130,177,172,22,100,201,235,242,241,140,249,65,87,75,10,88,97,192,11,98,67,222,35,187,93,80,115,43,212,186,33,27,84,97,3,249,157,204,103,149,215,24,114,215,28,12,197,17,255,229,169,119,241,35,27,18,139,130,104,140,61,237,165,13,103,194,20,138,211,142,27,231,204,202,59,209,96,231,19,88,71,144,69,3,186,71,255,5,30,28,19,225,44,47,118,107,87,241,20,86,237,214,232,178,123,188,162,230,78,20,63,2,44,232,186,156,20,115,219,54,228,113,107,232,233,132,126,73,9,199,248,10,9,125,6,152,234,120,231,12,238,224,163,49,27,214,101,77,13,206,210,226,54,48,60,131,109,141,121,232,50,24,188,105,14,61,126,41,14,112,79,51,120,69,91,25,74,219,160,49,60,185,205,177,143,17,202,95,173,12,78,82,107,145,138,230,185,59,179,56,234,158,233,112,185,247,27,141,201,86,93,116,169,254,234,254,234,166,41,189,111,219,97,142,21,158,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45ff5045-0bfb-49fc-bfdd-55d44048d58c"));
		}

		#endregion

	}

	#endregion

}

