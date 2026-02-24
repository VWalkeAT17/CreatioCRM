namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICopilotMessageConfirmationHandlerSchema

	/// <exclude/>
	public class ICopilotMessageConfirmationHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICopilotMessageConfirmationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICopilotMessageConfirmationHandlerSchema(ICopilotMessageConfirmationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce96475f-0db0-4c03-90fa-f69492da43e3");
			Name = "ICopilotMessageConfirmationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,81,205,106,195,48,12,62,167,208,119,48,236,210,65,240,3,108,165,151,80,218,192,122,106,95,192,75,149,212,96,203,65,82,96,101,244,221,103,199,89,214,194,6,59,89,242,247,163,79,8,141,7,238,77,3,170,34,48,98,131,174,66,111,93,144,229,226,115,185,40,6,182,216,169,227,149,5,124,68,156,131,38,114,144,245,14,16,200,54,175,51,231,4,68,134,67,43,122,139,17,184,120,64,209,53,10,80,27,221,89,87,23,35,85,240,189,131,100,16,117,81,249,68,208,197,70,205,180,23,85,79,227,15,192,108,58,168,2,182,150,124,10,134,123,131,103,7,52,42,109,82,160,113,202,126,75,255,165,44,210,78,197,155,101,89,63,178,55,42,115,238,85,171,71,138,26,24,104,170,75,53,97,199,216,167,13,56,191,101,178,47,38,236,20,130,139,126,2,31,162,228,167,126,206,187,255,158,98,7,114,31,97,250,231,85,189,197,193,3,153,119,7,235,209,215,56,183,201,174,177,226,57,207,31,51,75,197,66,233,74,205,120,133,57,71,113,203,119,0,60,231,83,164,246,246,5,212,17,117,108,20,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce96475f-0db0-4c03-90fa-f69492da43e3"));
		}

		#endregion

	}

	#endregion

}

