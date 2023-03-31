using System;
using System.Runtime.CompilerServices;

// Token: 0x02000028 RID: 40
[CompilerGenerated]
internal sealed class Class2
{
	// Token: 0x060000D9 RID: 217 RVA: 0x000076AC File Offset: 0x000058AC
	internal static uint smethod_0(string string_1)
	{
		uint num;
		if (string_1 != null)
		{
			num = 2166136261U;
			for (int i = 0; i < string_1.Length; i++)
			{
				num = ((uint)string_1[i] ^ num) * 16777619U;
			}
		}
		return num;
	}

	// Token: 0x040000A9 RID: 169
	[NonSerialized]
	private string string_0 = "";
}
