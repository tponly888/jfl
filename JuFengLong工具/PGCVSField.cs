using System;

namespace JuFengLongTools
{
	// Token: 0x02000029 RID: 41
	[Serializable]
	public class PGCVSField
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00002440 File Offset: 0x00000640
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00002448 File Offset: 0x00000648
		public string Name { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002451 File Offset: 0x00000651
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00002459 File Offset: 0x00000659
		public string Type { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00002462 File Offset: 0x00000662
		// (set) Token: 0x060000DF RID: 223 RVA: 0x0000246A File Offset: 0x0000066A
		public string ClientType { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002473 File Offset: 0x00000673
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000247B File Offset: 0x0000067B
		public string ColNameInExcel { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00002484 File Offset: 0x00000684
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000248C File Offset: 0x0000068C
		public int MakeIndex { get; set; }

		// Token: 0x060000E4 RID: 228 RVA: 0x000076E4 File Offset: 0x000058E4
		public string method_0()
		{
			string text;
			if (this.MakeIndex == 0)
			{
				text = "NoIndex";
			}
			else if (this.MakeIndex == 1)
			{
				text = "Bin";
			}
			else if (this.MakeIndex == 2)
			{
				text = "Search";
			}
			else if (this.MakeIndex == 3)
			{
				text = "StringDic";
			}
			else if (this.MakeIndex == 4)
			{
				text = "Sort";
			}
			else if (this.MakeIndex == 5)
			{
				text = "String2Hash";
			}
			else if (this.MakeIndex == 6)
			{
				text = "SkillTabelHash";
			}
			else if (this.MakeIndex == 7)
			{
				text = "SkillTabelIndex2";
			}
			else
			{
				text = "NoIndex";
			}
			return text;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000779C File Offset: 0x0000599C
		public void method_1(string string_1)
		{
			if (string_1 == "NoIndex")
			{
				this.MakeIndex = 0;
			}
			else if (string_1 == "Bin")
			{
				this.MakeIndex = 1;
			}
			else if (string_1 == "Search")
			{
				this.MakeIndex = 2;
			}
			else if (string_1 == "StringDic")
			{
				this.MakeIndex = 3;
			}
			else if (string_1 == "Sort")
			{
				this.MakeIndex = 4;
			}
			else if (string_1 == "String2Hash")
			{
				this.MakeIndex = 5;
			}
			else if (string_1 == "SkillTabelHash")
			{
				this.MakeIndex = 6;
			}
			else if (string_1 == "SkillTabelIndex2")
			{
				this.MakeIndex = 7;
			}
			else
			{
				this.MakeIndex = 0;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000786C File Offset: 0x00005A6C
		public string method_2()
		{
			return this.ClientIndex ? "true" : "false";
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00002495 File Offset: 0x00000695
		public void method_3(string string_1)
		{
			if (string_1 == "true")
			{
				this.ClientIndex = true;
			}
			else
			{
				this.ClientIndex = false;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00007898 File Offset: 0x00005A98
		public string method_4()
		{
			return this.ServerOnly ? "true" : "false";
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000024B4 File Offset: 0x000006B4
		public void method_5(string string_1)
		{
			if (string_1 == "true")
			{
				this.ServerOnly = true;
			}
			else
			{
				this.ServerOnly = false;
			}
		}

		// Token: 0x040000AF RID: 175
		public bool ClientIndex = true;

		// Token: 0x040000B0 RID: 176
		public bool ServerOnly = false;

		// Token: 0x040000B1 RID: 177
		[NonSerialized]
		string string_0 = "";
	}
}
