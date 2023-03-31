using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace JuFengLongTools.Properties
{
	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Resources
	{
		// Token: 0x060000EB RID: 235 RVA: 0x000020A7 File Offset: 0x000002A7
		internal Resources()
		{
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000EC RID: 236 RVA: 0x000078C4 File Offset: 0x00005AC4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceManager_0 == null)
				{
					ResourceManager resourceManager = new ResourceManager("JuFengLongTools.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceManager_0 = resourceManager;
				}
				return Resources.resourceManager_0;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00007908 File Offset: 0x00005B08
		// (set) Token: 0x060000EE RID: 238 RVA: 0x000024E9 File Offset: 0x000006E9
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.cultureInfo_0;
			}
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}

		// Token: 0x040000B2 RID: 178
		private static ResourceManager resourceManager_0;

		// Token: 0x040000B3 RID: 179
		private static CultureInfo cultureInfo_0;

		// Token: 0x040000B4 RID: 180
		[NonSerialized]
		private string string_0 = "";
	}
}
