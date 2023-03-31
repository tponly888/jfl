using System;
using System.Collections.Generic;
using System.Text;

namespace JuFengLongTools
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	public class PGCVSStruct : GInterface0
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00002326 File Offset: 0x00000526
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000232E File Offset: 0x0000052E
		public string Name { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00002337 File Offset: 0x00000537
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000233F File Offset: 0x0000053F
		public string TableName { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00002348 File Offset: 0x00000548
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00002350 File Offset: 0x00000550
		public bool ServerOnly { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00002359 File Offset: 0x00000559
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00002361 File Offset: 0x00000561
		public List<PGCVSField> Fields { get; set; }

		// Token: 0x060000B6 RID: 182 RVA: 0x0000236A File Offset: 0x0000056A
		public PGCVSStruct()
		{
			this.Fields = new List<PGCVSField>();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000053B8 File Offset: 0x000035B8
		public string imethod_0()
		{
			return this.Name;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000053D0 File Offset: 0x000035D0
		public string method_0()
		{
			return this.TableName;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000053E8 File Offset: 0x000035E8
		public string imethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("1.用cvs工具生成表的数据结构（需要lua读取的也要再导出lua文件）\r\n2.填入表名（一个数据结构对应多张表的用竖线分割，服务器专用表勾上ServerOnly）\r\n3.点击Table2Byte生成bytes（对应的res下的txt表格记得加上新列）\r\n4.上传res/XProject/Shell下的Table2Bytes.exe，DataGen.dll，cvs.xml三个文件\r\n5.策划等在客户端中编辑的表格只需要reimport表格txt文件就可以了\r\n6.上传txt、bytes文件");
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("struct: {0} table:{1} serverOnly:{2}\n", this.Name, this.TableName, this.ServerOnly);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("{0}{1}{2}\n", "类型".PadRight(16), "变量名".PadRight(8), "excel中的列");
			foreach (PGCVSField pgcvsfield in this.Fields)
			{
				stringBuilder.AppendFormat("{0} {1} {2}\n", pgcvsfield.Type.PadRight(18), pgcvsfield.Name.PadRight(10), pgcvsfield.ColNameInExcel);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000081 RID: 129
		[NonSerialized]
		string string_0 = "";
	}
}
