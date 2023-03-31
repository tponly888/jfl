using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using JuFengLongTools;

// Token: 0x02000002 RID: 2
public class GClass0
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002510 File Offset: 0x00000710
	public string method_0()
	{
		return this.string_5;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002528 File Offset: 0x00000728
	public GClass0(GClass22<PGCVSStruct> gclass22_1, string string_11)
	{
		this.int_1 = 1;
		this.string_7 = string_11;
		if (this.string_7 != null)
		{
		}
		if (!this.string_7.EndsWith("\\"))
		{
			this.string_7 += "\\";
		}
		this.string_8 = string_11 + "\\客户端加密\\";
		this.string_9 = string_11 + "\\客户端解密\\";
		this.gclass22_0 = gclass22_1;
		this.dictionary_0["StringTable"] = new GClass0.GClass14();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002050 File Offset: 0x00000250
	private void method_1(string string_11)
	{
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002680 File Offset: 0x00000880
	public static bool smethod_0(string[] string_11)
	{
		bool flag2;
		if (string_11 != null && string_11.Length != 0)
		{
			GClass22<PGCVSStruct>.smethod_0().method_11("cvs.xml");
			GClass22<PGCVSStruct>.smethod_0().bool_0 = true;
			GClass22<PGCVSStruct>.smethod_0().method_21();
			string text = string_11[0];
			int num = 1;
			bool flag = false;
			if (text == "-q")
			{
				flag = true;
				if (string_11.Length <= 1)
				{
					return true;
				}
				num = 2;
				text = string_11[1];
			}
			string text2 = "../";
			if (text == "-root")
			{
				if (string_11.Length <= num + 1)
				{
					return false;
				}
				num += 2;
				text2 = string_11[num - 2];
				text = string_11[num - 1];
			}
			GClass0 gclass = new GClass0(GClass22<PGCVSStruct>.smethod_0(), text2);
			if (text == "-tables")
			{
				if (string_11.Length > num)
				{
					for (int i = num; i < string_11.Length; i++)
					{
						gclass.method_3(string_11[i]);
						if (!flag)
						{
							Console.WriteLine(string.Format("Generate {0} Finish!", string_11[i]));
						}
					}
				}
				else
				{
					gclass.method_2();
					if (!flag)
					{
						Console.WriteLine("Generate All Finish!");
					}
				}
			}
			else if (text == "-refreshCVS")
			{
				gclass.method_8();
				if (!flag)
				{
					Console.WriteLine("Refresh Finish!");
				}
			}
			if (!flag)
			{
				Console.WriteLine("Press Enter to Exit!");
				Console.ReadLine();
			}
			flag2 = true;
		}
		else
		{
			flag2 = false;
		}
		return flag2;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000027FC File Offset: 0x000009FC
	public void method_2()
	{
		List<PGCVSStruct> list = this.gclass22_0.method_15();
		for (int i = 0; i < list.Count; i++)
		{
			PGCVSStruct pgcvsstruct = list[i];
			this.method_6(pgcvsstruct, pgcvsstruct.TableName);
			this.pgcvsstruct_0 = null;
		}
		if (this.string_5 != "")
		{
			Console.WriteLine("error:" + this.string_5);
			File.WriteAllText("cvsError.log", this.string_5);
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002884 File Offset: 0x00000A84
	public void method_3(string string_11)
	{
		List<PGCVSStruct> list = this.gclass22_0.method_15();
		for (int i = 0; i < list.Count; i++)
		{
			PGCVSStruct pgcvsstruct = list[i];
			if (!string.IsNullOrEmpty(pgcvsstruct.TableName))
			{
				string[] array = pgcvsstruct.TableName.Split(GClass0.char_0, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length <= 1 || !pgcvsstruct.TableName.Contains(string_11))
				{
					if (!(pgcvsstruct.TableName == string_11))
					{
						goto IL_67;
					}
					this.method_6(pgcvsstruct, string_11);
				}
				else
				{
					this.method_6(pgcvsstruct, string_11);
				}
				IL_8A:
				this.pgcvsstruct_0 = null;
				if (this.string_6 != "")
				{
					Console.WriteLine("info:" + this.string_6);
				}
				if (this.string_5 != "")
				{
					Console.WriteLine("error:" + this.string_5);
					File.WriteAllText("cvsError.log", this.string_5);
				}
				return;
			}
			IL_67:;
		}
		goto IL_8A;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002980 File Offset: 0x00000B80
	public void method_4(PGCVSStruct pgcvsstruct_1)
	{
		if (string.IsNullOrEmpty(pgcvsstruct_1.TableName))
		{
			this.string_5 += string.Format("NullTableName:{0}\r\n", pgcvsstruct_1.Name);
		}
		else
		{
			string[] array = pgcvsstruct_1.TableName.Split(GClass0.char_0, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				this.method_6(pgcvsstruct_1, array[i]);
			}
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000029F0 File Offset: 0x00000BF0
	public int method_5(PGCVSStruct pgcvsstruct_1, string string_11)
	{
		this.string_3 = string_11;
		this.string_5 = "";
		this.pgcvsstruct_0 = pgcvsstruct_1;
		int num = 0;
		if (this.pgcvsstruct_0 != null && !this.pgcvsstruct_0.ServerOnly)
		{
			string text = this.string_9 + string_11 + ".txt";
			try
			{
				this.gclass13_0 = null;
				this.dictionary_0.TryGetValue(this.pgcvsstruct_0.Name, out this.gclass13_0);
				using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					if (fileStream.Length > 0L)
					{
						byte[] array = new byte[fileStream.Length];
						if (array != null)
						{
							fileStream.Read(array, 0, (int)fileStream.Length);
							Stream stream = new MemoryStream(array);
							this.int_1 = 1;
							StreamReader streamReader = new StreamReader(stream);
							for (;;)
							{
								string text2 = streamReader.ReadLine();
								if (text2 == null)
								{
									break;
								}
								text2 = text2.TrimEnd(GClass0.char_2);
								text2.Split(new char[] { '\t' });
								if (this.int_1 != 1 && this.int_1 != 2)
								{
									num++;
								}
								this.int_1++;
							}
							stream.Close();
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.string_5 = this.string_5 + " \r\n" + ex.Message + string.Format("Table:{0} line:{1}", string_11, this.int_1);
			}
		}
		return num;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002BA4 File Offset: 0x00000DA4
	private void method_6(PGCVSStruct pgcvsstruct_1, string string_11)
	{
		this.string_3 = string_11;
		this.string_5 = "";
		this.pgcvsstruct_0 = pgcvsstruct_1;
		if (this.pgcvsstruct_0 != null && !this.pgcvsstruct_0.ServerOnly)
		{
			string text = this.string_9 + string_11 + ".txt";
			string text2 = this.string_8 + string_11 + ".bytes";
			try
			{
				this.gclass13_0 = null;
				this.dictionary_0.TryGetValue(this.pgcvsstruct_0.Name, out this.gclass13_0);
				using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					if (fileStream.Length > 0L)
					{
						byte[] array = new byte[fileStream.Length];
						if (array != null)
						{
							fileStream.Read(array, 0, (int)fileStream.Length);
							Stream stream = new MemoryStream(array);
							using (FileStream fileStream2 = new FileStream(text2, FileMode.Create))
							{
								this.method_24(stream, fileStream2);
							}
							stream.Close();
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.string_5 = this.string_5 + " \r\n" + ex.Message + string.Format("Table:{0} line:{1} column:{2} content:{3} fieldType:{4}", new object[] { string_11, this.int_2, this.string_0, this.string_1, this.string_2 });
			}
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002D3C File Offset: 0x00000F3C
	private T method_7<T>(string string_11)
	{
		T t;
		try
		{
			using (FileStream fileStream = new FileStream(string_11, FileMode.Open))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				t = (T)((object)xmlSerializer.Deserialize(fileStream));
			}
		}
		catch (Exception)
		{
			t = default(T);
		}
		return t;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002DA8 File Offset: 0x00000FA8
	public void method_8()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		GClass0.GClass18 gclass = this.method_7<GClass0.GClass18>(this.string_7 + "XProject\\Assets\\Editor\\ResImporter\\ImporterData\\Table\\Table.xml");
		if (gclass != null && gclass.list_1 != null)
		{
			for (int i = 0; i < gclass.list_1.Count; i++)
			{
				GClass0.GClass17 gclass2 = gclass.list_1[i];
				string text = "";
				if (dictionary.TryGetValue(gclass2.string_0, out text))
				{
					text = text + "|" + gclass2.string_1;
				}
				else
				{
					text = gclass2.string_1;
				}
				dictionary[gclass2.string_0] = text;
			}
			List<PGCVSStruct> list = this.gclass22_0.method_15();
			for (int j = 0; j < list.Count; j++)
			{
				PGCVSStruct pgcvsstruct = list[j];
				string text2 = "";
				if (dictionary.TryGetValue(pgcvsstruct.Name, out text2))
				{
					pgcvsstruct.TableName = text2;
					pgcvsstruct.ServerOnly = false;
				}
				else
				{
					pgcvsstruct.ServerOnly = true;
				}
			}
			this.gclass22_0.method_22();
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002EC8 File Offset: 0x000010C8
	private int method_9(string[] string_11, string string_12)
	{
		for (int i = 0; i < string_11.Length; i++)
		{
			if (string_12 == string_11[i])
			{
				return i;
			}
		}
		this.string_5 += string.Format("{0}.txt中没有找到列：{1}，请先在txt中添加列，然后再在协议生成工具中添加相应列的数据结构\r\n", this.string_3, string_12);
		return -1;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002F24 File Offset: 0x00001124
	private byte method_10(string[] string_11, ref GClass0.GClass16 gclass16_0, ref GClass0.GClass16 gclass16_1)
	{
		byte b = 0;
		this.list_0.Clear();
		for (int i = 0; i < this.pgcvsstruct_0.Fields.Count; i++)
		{
			PGCVSField pgcvsfield = this.pgcvsstruct_0.Fields[i];
			if (!pgcvsfield.ServerOnly)
			{
				GClass0.GClass16 gclass = new GClass0.GClass16();
				if ((pgcvsfield.MakeIndex == 1 && pgcvsfield.ClientIndex) || pgcvsfield.MakeIndex == 4 || pgcvsfield.MakeIndex == 6)
				{
					gclass16_0 = gclass;
					if (pgcvsfield.MakeIndex == 4)
					{
						gclass16_0.int_2 = 1;
					}
					else if (pgcvsfield.MakeIndex == 6)
					{
						gclass16_0.int_2 = 2;
					}
				}
				else if (pgcvsfield.MakeIndex == 3)
				{
					gclass.bool_0 = true;
				}
				else if (pgcvsfield.MakeIndex == 7)
				{
					gclass16_1 = gclass;
				}
				gclass.int_0 = this.method_9(string_11, pgcvsfield.ColNameInExcel);
				if (gclass.int_0 >= 0)
				{
					gclass.string_0 = string_11[gclass.int_0];
					string text = "";
					string text2 = (string.IsNullOrEmpty(pgcvsfield.ClientType) ? pgcvsfield.Type : pgcvsfield.ClientType);
					if (text2.StartsWith("vector"))
					{
						if (text2.Contains("Sequence"))
						{
							gclass.etableFieldType_0 = GClass0.ETableFieldType.ESeqList;
							int num = text2.LastIndexOf('<');
							int num2 = text2.IndexOf(',');
							text = text2.Substring(num + 1, num2 - num - 1);
							gclass.int_1 = int.Parse(text2.Substring(num2 + 2, 1));
						}
						else
						{
							gclass.etableFieldType_0 = GClass0.ETableFieldType.EArray;
							text = text2.Replace("vector<", "");
							text = text.Replace(">", "");
						}
					}
					else if (text2.StartsWith("map"))
					{
						this.string_5 += string.Format("Client not support map :Table:({0},{1}) Column:{2}\r\n", this.string_3, this.string_4, pgcvsfield.ColNameInExcel);
					}
					else if (text2.StartsWith("Sequence"))
					{
						int num3 = text2.LastIndexOf('<');
						int num4 = text2.IndexOf(',');
						text = text2.Substring(num3 + 1, num4 - num3 - 1);
						gclass.int_1 = int.Parse(text2.Substring(num4 + 2, 1));
						gclass.etableFieldType_0 = GClass0.ETableFieldType.ESeq;
					}
					else if (text2 == "long long")
					{
						text = "long";
					}
					else if (pgcvsfield.MakeIndex == 5 && text2 == "string")
					{
						text = "string2Hash";
					}
					else
					{
						text = text2;
					}
					byte b2;
					if (gclass.method_0(text))
					{
						if (gclass.int_1 >= 2 && gclass.int_1 <= 4)
						{
							b += 1;
							this.list_0.Add(gclass);
							goto IL_2DB;
						}
						this.string_5 += string.Format("Seq Dim error :Table:({0},{1}) Column:{2} dim:{3}\r\n", new object[] { this.string_3, this.string_4, pgcvsfield.ColNameInExcel, gclass.int_1 });
						b2 = 0;
					}
					else
					{
						this.string_5 += string.Format("Type error :Table:({0},{1}) Column:{2} type:{3}\r\n", new object[] { this.string_3, this.string_4, pgcvsfield.ColNameInExcel, text });
						b2 = 0;
					}
					return b2;
				}
				this.list_0.Add(null);
			}
			IL_2DB:;
		}
		return b;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000032D0 File Offset: 0x000014D0
	private void method_11(ref string string_11)
	{
		string text = string_11.Trim();
		if (text.Length != string_11.Length)
		{
			this.string_5 += string.Format("Write Table:({0},{1}) line:{2} Field has space:{3} \r\n", new object[] { this.string_3, this.string_4, this.int_1, string_11 });
			string_11 = text;
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00003348 File Offset: 0x00001548
	private void method_12(string[] string_11)
	{
		for (int i = 0; i < string_11.Length; i++)
		{
			this.method_11(ref string_11[i]);
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002052 File Offset: 0x00000252
	private void method_13(BinaryWriter binaryWriter_0, string string_11, GClass0.GClass1 gclass1_0)
	{
		this.method_11(ref string_11);
		gclass1_0.vmethod_0(binaryWriter_0, string_11, this.gclass20_0);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00003374 File Offset: 0x00001574
	private void method_14(BinaryWriter binaryWriter_0, string string_11, GClass0.GClass1 gclass1_0)
	{
		byte b = 0;
		string[] array = string_11.Split(GClass0.char_0, StringSplitOptions.RemoveEmptyEntries);
		if (array == null || array.Length == 0)
		{
			binaryWriter_0.Write(b);
		}
		else
		{
			b = (byte)array.Length;
			binaryWriter_0.Write(b);
			for (byte b2 = 0; b2 < b; b2 += 1)
			{
				string text = array[(int)b2];
				this.method_11(ref text);
				gclass1_0.vmethod_0(binaryWriter_0, text, this.gclass20_0);
			}
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000033DC File Offset: 0x000015DC
	private void method_15(BinaryWriter binaryWriter_0, string string_11, GClass0.GClass1 gclass1_0, int int_3, string string_12)
	{
		int num = 0;
		if (string_11.Length == 0)
		{
			binaryWriter_0.Write(num);
		}
		else
		{
			string[] array = string_11.Split(GClass0.char_1, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				binaryWriter_0.Write(num);
			}
			else
			{
				this.method_12(array);
				string text = array[0];
				for (int i = 1; i < int_3; i++)
				{
					if (i < array.Length)
					{
						text = text + "=" + array[i];
					}
					else
					{
						text += "=0";
					}
				}
				text += string_12;
				uint num2 = GClass0.GClass9.smethod_0(text);
				gclass1_0.vmethod_1(binaryWriter_0, this.gclass20_0, array, int_3, num2, true);
			}
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00003490 File Offset: 0x00001690
	private uint method_16(string string_11, int int_3, string string_12, out string[] string_13)
	{
		string_13 = string_11.Split(GClass0.char_1, StringSplitOptions.RemoveEmptyEntries);
		this.method_12(string_13);
		uint num = GClass0.GClass9.smethod_1(0U, string_13[0]);
		for (int i = 1; i < int_3; i++)
		{
			if (i < string_13.Length)
			{
				num = GClass0.GClass9.smethod_1(num, "=");
				num = GClass0.GClass9.smethod_1(num, string_13[i]);
			}
			else
			{
				num = GClass0.GClass9.smethod_1(num, "=0");
			}
		}
		return GClass0.GClass9.smethod_1(num, string_12);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00003510 File Offset: 0x00001710
	private bool method_17(string[] string_11, int int_3, string string_12)
	{
		bool flag;
		if (string_11.Length == 1)
		{
			flag = true;
		}
		else
		{
			string[] array;
			uint num = this.method_16(string_11[0], int_3, string_12, out array);
			for (int i = 1; i < string_11.Length; i++)
			{
				if (this.method_16(string_11[i], int_3, string_12, out array) != num)
				{
					return false;
				}
			}
			flag = true;
		}
		return flag;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000356C File Offset: 0x0000176C
	private void method_18(BinaryWriter binaryWriter_0, string string_11, GClass0.GClass1 gclass1_0, int int_3, string string_12, bool bool_0)
	{
		string[] array;
		uint num = this.method_16(string_11, int_3, string_12, out array);
		gclass1_0.vmethod_1(binaryWriter_0, this.gclass20_0, array, int_3, num, bool_0);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x0000359C File Offset: 0x0000179C
	private void method_19(BinaryWriter binaryWriter_0, string string_11, GClass0.GClass1 gclass1_0, int int_3, string string_12)
	{
		byte b = 0;
		if (string_11.Length == 0)
		{
			binaryWriter_0.Write(b);
		}
		else
		{
			string[] array = string_11.Split(GClass0.char_0, StringSplitOptions.RemoveEmptyEntries);
			if (array == null || array.Length == 0)
			{
				binaryWriter_0.Write(b);
			}
			else
			{
				b = (byte)array.Length;
				binaryWriter_0.Write(b);
				bool flag;
				byte b2 = ((flag = this.method_17(array, int_3, string_12)) ? 1 : 0);
				binaryWriter_0.Write(b2);
				if (flag)
				{
					this.method_18(binaryWriter_0, array[0], gclass1_0, int_3, string_12, true);
				}
				else
				{
					int count = GClass0.GClass20.list_0.Count;
					binaryWriter_0.Write(count);
					for (byte b3 = 0; b3 < b; b3 += 1)
					{
						this.method_18(binaryWriter_0, array[(int)b3], gclass1_0, int_3, string_12, false);
					}
				}
			}
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00003658 File Offset: 0x00001858
	private bool method_20(BinaryWriter binaryWriter_0, GClass0.GClass16 gclass16_0, string[] string_11)
	{
		if (gclass16_0 != null)
		{
			this.string_0 = gclass16_0.string_0;
			if (gclass16_0.int_0 < 0 || gclass16_0.int_0 >= string_11.Length)
			{
				return false;
			}
			string text = string_11[gclass16_0.int_0];
			this.string_1 = text;
			this.string_2 = gclass16_0.etableFieldType_0.ToString();
			if (this.gclass13_0 != null)
			{
				text = this.gclass13_0.vmethod_0(gclass16_0.int_0, text);
			}
			switch (gclass16_0.etableFieldType_0)
			{
			case GClass0.ETableFieldType.EValue:
				this.method_13(binaryWriter_0, text, gclass16_0.gclass1_0);
				break;
			case GClass0.ETableFieldType.EArray:
				this.method_14(binaryWriter_0, text, gclass16_0.gclass1_0);
				break;
			case GClass0.ETableFieldType.ESeq:
				this.method_15(binaryWriter_0, text, gclass16_0.gclass1_0, gclass16_0.int_1, gclass16_0.string_1);
				break;
			case GClass0.ETableFieldType.ESeqList:
				this.method_19(binaryWriter_0, text, gclass16_0.gclass1_0, gclass16_0.int_1, gclass16_0.string_1);
				break;
			}
			if (gclass16_0.int_2 == 2)
			{
				uint num = GClass0.GClass9.smethod_0(text);
				binaryWriter_0.Write(num);
			}
		}
		return true;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00003774 File Offset: 0x00001974
	private bool method_21(string[] string_11, BinaryWriter binaryWriter_0, GClass0.GClass16 gclass16_0, int int_3)
	{
		int num = 0;
		int num2 = (int)binaryWriter_0.BaseStream.Position;
		if (GClass0.int_0 > 1)
		{
			binaryWriter_0.Write(num);
		}
		int num3 = (int)binaryWriter_0.BaseStream.Position;
		for (int i = 0; i < this.list_0.Count; i++)
		{
			int num4 = (int)binaryWriter_0.BaseStream.Position;
			GClass0.GClass16 gclass = this.list_0[i];
			this.method_20(binaryWriter_0, gclass, string_11);
			int num5 = (int)binaryWriter_0.BaseStream.Position - num4;
			gclass.int_3 += num5;
		}
		if (GClass0.int_0 > 1)
		{
			int num6 = (int)binaryWriter_0.BaseStream.Position;
			num = num6 - num3;
			binaryWriter_0.BaseStream.Seek((long)num2, SeekOrigin.Begin);
			binaryWriter_0.Write(num);
			binaryWriter_0.BaseStream.Seek((long)num6, SeekOrigin.Begin);
		}
		return true;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00003854 File Offset: 0x00001A54
	private void method_22(int int_3, int int_4, string[] string_11, GClass0.GClass16 gclass16_0, GClass0.GClass16 gclass16_1)
	{
		int num = int_3;
		for (int i = int_3 + 1; i < int_4; i++)
		{
			string[] array = this.list_1[i].string_0;
			int num2 = gclass16_0.method_2(array, string_11, gclass16_1);
			if (num2 != 0)
			{
				break;
			}
			num = i;
		}
		this.list_1.Insert(num + 1, new GClass0.GClass19(string_11, this.int_1));
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000038B4 File Offset: 0x00001AB4
	private void method_23(GClass0.GClass16 gclass16_0, string string_11, string[] string_12, int int_3, int int_4, GClass0.GClass16 gclass16_1)
	{
		if (this.list_1.Count == 0)
		{
			this.list_1.Add(new GClass0.GClass19(string_12, this.int_1));
		}
		else
		{
			string[] array = this.list_1[int_4].string_0;
			int num = gclass16_0.method_2(array, string_12, gclass16_1);
			if (num < 0)
			{
				this.list_1.Insert(int_4 + 1, new GClass0.GClass19(string_12, this.int_1));
			}
			else if (num == 0)
			{
				if (gclass16_0.int_2 != 0)
				{
					this.method_22(int_4, this.list_1.Count, string_12, gclass16_0, gclass16_1);
				}
				else
				{
					this.string_5 += string.Format("Table: {0} duplicate id:{1}  lineno: {2}\r\n", this.pgcvsstruct_0.TableName, string_11, this.int_1);
				}
			}
			else
			{
				string[] array2 = this.list_1[int_3].string_0;
				num = gclass16_0.method_2(array2, string_12, gclass16_1);
				if (num > 0)
				{
					this.list_1.Insert(int_3, new GClass0.GClass19(string_12, this.int_1));
				}
				else if (num == 0)
				{
					if (gclass16_0.int_2 != 0)
					{
						this.method_22(int_3, int_4, string_12, gclass16_0, gclass16_1);
					}
					else
					{
						this.string_5 += string.Format("Table: {0} duplicate id:{1}  lineno: {2}", this.pgcvsstruct_0.TableName, string_11, this.int_1);
					}
				}
				else if (int_4 - int_3 <= 1)
				{
					this.list_1.Insert(int_3 + 1, new GClass0.GClass19(string_12, this.int_1));
				}
				else
				{
					int num2 = int_3 + (int_4 - int_3) / 2;
					string[] array3 = this.list_1[num2].string_0;
					num = gclass16_0.method_2(array3, string_12, gclass16_1);
					if (num > 0)
					{
						this.method_23(gclass16_0, string_11, string_12, int_3, num2, gclass16_1);
					}
					else if (num < 0)
					{
						this.method_23(gclass16_0, string_11, string_12, num2, int_4, gclass16_1);
					}
					else if (gclass16_0.int_2 != 0)
					{
						this.method_22(num2, int_4, string_12, gclass16_0, gclass16_1);
					}
					else
					{
						this.string_5 += string.Format("Table: {0} duplicate id:{1}  lineno: {2}\r\n", this.pgcvsstruct_0.TableName, string_11, this.int_1);
					}
				}
			}
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00003B0C File Offset: 0x00001D0C
	private void method_24(Stream stream_0, Stream stream_1)
	{
		this.int_1 = 1;
		this.int_2 = 0;
		this.string_0 = "";
		this.string_1 = "";
		this.string_2 = "";
		this.list_1.Clear();
		this.gclass20_0.method_0();
		GClass0.GClass16 gclass = null;
		GClass0.GClass16 gclass2 = null;
		StreamReader streamReader = new StreamReader(stream_0);
		MemoryStream memoryStream = new MemoryStream();
		MemoryStream memoryStream2 = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
		int num = 0;
		if (GClass0.int_0 > 1)
		{
			binaryWriter.Write(num);
		}
		int num2 = 0;
		binaryWriter.Write(0);
		for (;;)
		{
			bool flag = true;
			string text = streamReader.ReadLine();
			if (text == null)
			{
				break;
			}
			text = text.TrimEnd(GClass0.char_2);
			string[] array = text.Split(new char[] { '\t' });
			if (array[0] == "ARENA_BUY_COOLDOWN")
			{
			}
			if (this.int_1 == 1)
			{
				byte b = this.method_10(array, ref gclass, ref gclass2);
				flag = b > 0;
				binaryWriter2.Write(b);
				if (b > 0)
				{
					for (int i = 0; i < this.list_0.Count; i++)
					{
						GClass0.GClass16 gclass3 = this.list_0[i];
						binaryWriter2.Write((byte)gclass3.etableFieldType_0);
						binaryWriter2.Write(gclass3.byte_0);
					}
				}
			}
			else if (this.int_1 != 2)
			{
				if (gclass != null)
				{
					this.method_23(gclass, array[gclass.int_0], array, 0, this.list_1.Count - 1, gclass2);
				}
				else
				{
					this.int_2 = this.int_1;
					if (!this.method_21(array, binaryWriter2, null, num2))
					{
						break;
					}
				}
				num2++;
			}
			if (!flag)
			{
				break;
			}
			this.int_1++;
		}
		if (gclass != null)
		{
			if (this.list_1.Count >= 64 || this.pgcvsstruct_0.ServerOnly)
			{
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				this.int_2 = this.list_1[j].int_0;
				if (!this.method_21(this.list_1[j].string_0, binaryWriter2, gclass, j))
				{
					break;
				}
			}
		}
		this.gclass20_0.method_2(binaryWriter);
		num = (int)binaryWriter.BaseStream.Position + (int)binaryWriter2.BaseStream.Position;
		binaryWriter.Seek(0, SeekOrigin.Begin);
		if (GClass0.int_0 > 1)
		{
			binaryWriter.Write(num);
		}
		binaryWriter.Write(num2);
		BinaryWriter binaryWriter3 = new BinaryWriter(stream_1);
		byte[] array2 = memoryStream.GetBuffer();
		int num3 = (int)memoryStream.Length;
		for (int k = 0; k < num3; k++)
		{
			binaryWriter3.Write(array2[k]);
		}
		array2 = memoryStream2.GetBuffer();
		int num4 = (int)memoryStream2.Length;
		for (int l = 0; l < num4; l++)
		{
			binaryWriter3.Write(array2[l]);
		}
		binaryWriter3.Close();
		binaryWriter.Close();
		binaryWriter2.Close();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\r\n");
		this.gclass20_0.method_3(stringBuilder);
		stringBuilder.AppendFormat("{0}\t\t{1}k\t\ttotal size\r\n", num, num / 1024);
		stringBuilder.AppendFormat("{0}\t\t{1}k\t\tdata size\r\n", num3, num3 / 1024);
		for (int m = 0; m < this.list_0.Count; m++)
		{
			GClass0.GClass16 gclass4 = this.list_0[m];
			stringBuilder.AppendFormat("{0}\t\t{1}k\t\t{2}\r\n", gclass4.int_3, gclass4.int_3 / 1024, gclass4.string_0);
		}
		this.string_6 = stringBuilder.ToString();
	}

	// Token: 0x04000001 RID: 1
	public static int int_0 = 2;

	// Token: 0x04000002 RID: 2
	public int int_1 = -1;

	// Token: 0x04000003 RID: 3
	public int int_2 = 0;

	// Token: 0x04000004 RID: 4
	public string string_0 = "";

	// Token: 0x04000005 RID: 5
	public string string_1 = "";

	// Token: 0x04000006 RID: 6
	public string string_2 = "";

	// Token: 0x04000007 RID: 7
	public string string_3 = "";

	// Token: 0x04000008 RID: 8
	public string string_4 = "";

	// Token: 0x04000009 RID: 9
	private string string_5 = "";

	// Token: 0x0400000A RID: 10
	private string string_6 = "";

	// Token: 0x0400000B RID: 11
	private string string_7 = "";

	// Token: 0x0400000C RID: 12
	private string string_8 = "";

	// Token: 0x0400000D RID: 13
	private string string_9 = "";

	// Token: 0x0400000E RID: 14
	private PGCVSStruct pgcvsstruct_0 = null;

	// Token: 0x0400000F RID: 15
	private List<GClass0.GClass16> list_0 = new List<GClass0.GClass16>();

	// Token: 0x04000010 RID: 16
	private List<GClass0.GClass19> list_1 = new List<GClass0.GClass19>();

	// Token: 0x04000011 RID: 17
	private GClass22<PGCVSStruct> gclass22_0 = null;

	// Token: 0x04000012 RID: 18
	private Dictionary<string, GClass0.GClass13> dictionary_0 = new Dictionary<string, GClass0.GClass13>();

	// Token: 0x04000013 RID: 19
	private GClass0.GClass13 gclass13_0 = null;

	// Token: 0x04000014 RID: 20
	private GClass0.GClass20 gclass20_0 = new GClass0.GClass20();

	// Token: 0x04000015 RID: 21
	private static readonly char[] char_0 = new char[] { '|' };

	// Token: 0x04000016 RID: 22
	private static readonly char[] char_1 = new char[] { '=' };

	// Token: 0x04000017 RID: 23
	private static readonly char[] char_2 = new char[] { '\r', '\n' };

	// Token: 0x04000018 RID: 24
	[NonSerialized]
	string string_10 = "";

	// Token: 0x02000003 RID: 3
	public abstract class GClass1
	{
		// Token: 0x0600001D RID: 29
		public abstract void vmethod_0(BinaryWriter binaryWriter_0, string string_1, GClass0.GClass20 gclass20_0);

		// Token: 0x0600001E RID: 30
		public abstract void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_1, int int_0, uint uint_0, bool bool_0);

		// Token: 0x0600001F RID: 31
		public abstract int vmethod_2(string string_1, string string_2);

		// Token: 0x04000019 RID: 25
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x02000004 RID: 4
	public sealed class GClass2 : GClass0.GClass1
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00003F0C File Offset: 0x0000210C
		public static uint smethod_0(string string_2)
		{
			uint num;
			if (string_2.StartsWith("0x"))
			{
				string_2 = string_2.Substring(2).Replace(",", "");
				num = Convert.ToUInt32(string_2, 2);
			}
			else
			{
				num = Convert.ToUInt32(string_2);
			}
			return num;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003F58 File Offset: 0x00002158
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			uint num = 0U;
			if (!string.IsNullOrEmpty(string_2))
			{
				num = GClass0.GClass2.smethod_0(string_2);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003F80 File Offset: 0x00002180
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_1, bool bool_0)
		{
			GClass0.GClass2.uint_0[0] = 0U;
			GClass0.GClass2.uint_0[1] = 0U;
			GClass0.GClass2.uint_0[2] = 0U;
			GClass0.GClass2.uint_0[3] = 0U;
			for (int i = 0; i < string_2.Length; i++)
			{
				if (!string.IsNullOrEmpty(string_2[i]))
				{
					GClass0.GClass2.uint_0[i] = GClass0.GClass2.smethod_0(string_2[i]);
				}
			}
			gclass20_0.method_1<uint>(GClass0.GClass2.uint_0, int_0, uint_1, binaryWriter_0, bool_0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003FEC File Offset: 0x000021EC
		public override int vmethod_2(string string_2, string string_3)
		{
			uint num = GClass0.GClass2.smethod_0(string_2);
			uint num2 = GClass0.GClass2.smethod_0(string_3);
			return num.CompareTo(num2);
		}

		// Token: 0x0400001A RID: 26
		private static uint[] uint_0 = new uint[4];

		// Token: 0x0400001B RID: 27
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000005 RID: 5
	public sealed class GClass3 : GClass0.GClass1
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00004014 File Offset: 0x00002214
		public static int smethod_0(string string_2)
		{
			int num;
			if (string_2.StartsWith("0x"))
			{
				string_2 = string_2.Substring(2).Replace(",", "");
				num = Convert.ToInt32(string_2, 2);
			}
			else
			{
				num = Convert.ToInt32(string_2);
			}
			return num;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004060 File Offset: 0x00002260
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			int num = 0;
			if (!string.IsNullOrEmpty(string_2))
			{
				num = GClass0.GClass3.smethod_0(string_2);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004088 File Offset: 0x00002288
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_1, uint uint_0, bool bool_0)
		{
			GClass0.GClass3.int_0[0] = 0;
			GClass0.GClass3.int_0[1] = 0;
			GClass0.GClass3.int_0[2] = 0;
			GClass0.GClass3.int_0[3] = 0;
			for (int i = 0; i < string_2.Length; i++)
			{
				if (!string.IsNullOrEmpty(string_2[i]))
				{
					GClass0.GClass3.int_0[i] = GClass0.GClass3.smethod_0(string_2[i]);
				}
			}
			gclass20_0.method_1<int>(GClass0.GClass3.int_0, int_1, uint_0, binaryWriter_0, bool_0);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000040F4 File Offset: 0x000022F4
		public override int vmethod_2(string string_2, string string_3)
		{
			int num = GClass0.GClass3.smethod_0(string_2);
			int num2 = GClass0.GClass3.smethod_0(string_3);
			return num.CompareTo(num2);
		}

		// Token: 0x0400001C RID: 28
		private static int[] int_0 = new int[4];

		// Token: 0x0400001D RID: 29
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000006 RID: 6
	public sealed class GClass4 : GClass0.GClass1
	{
		// Token: 0x0600002D RID: 45 RVA: 0x0000411C File Offset: 0x0000231C
		public static long smethod_0(string string_2)
		{
			long num;
			if (string_2.StartsWith("0x"))
			{
				string_2 = string_2.Substring(2).Replace(",", "");
				num = Convert.ToInt64(string_2, 2);
			}
			else
			{
				num = Convert.ToInt64(string_2);
			}
			return num;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004168 File Offset: 0x00002368
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			long num = 0L;
			if (!string.IsNullOrEmpty(string_2))
			{
				num = GClass0.GClass4.smethod_0(string_2);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004198 File Offset: 0x00002398
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
			GClass0.GClass4.long_0[0] = 0L;
			GClass0.GClass4.long_0[1] = 0L;
			GClass0.GClass4.long_0[2] = 0L;
			GClass0.GClass4.long_0[3] = 0L;
			for (int i = 0; i < string_2.Length; i++)
			{
				if (!string.IsNullOrEmpty(string_2[i]))
				{
					GClass0.GClass4.long_0[i] = GClass0.GClass4.smethod_0(string_2[i]);
				}
			}
			gclass20_0.method_1<long>(GClass0.GClass4.long_0, int_0, uint_0, binaryWriter_0, bool_0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004224 File Offset: 0x00002424
		public override int vmethod_2(string string_2, string string_3)
		{
			long num = GClass0.GClass4.smethod_0(string_2);
			long num2 = GClass0.GClass4.smethod_0(string_3);
			return num.CompareTo(num2);
		}

		// Token: 0x0400001E RID: 30
		private static long[] long_0 = new long[4];

		// Token: 0x0400001F RID: 31
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000007 RID: 7
	public sealed class GClass5 : GClass0.GClass1
	{
		// Token: 0x06000033 RID: 51 RVA: 0x0000424C File Offset: 0x0000244C
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			float num = 0f;
			if (!string.IsNullOrEmpty(string_2))
			{
				float.TryParse(string_2, out num);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000427C File Offset: 0x0000247C
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
			GClass0.GClass5.float_0[0] = 0f;
			GClass0.GClass5.float_0[1] = 0f;
			GClass0.GClass5.float_0[2] = 0f;
			GClass0.GClass5.float_0[3] = 0f;
			for (int i = 0; i < string_2.Length; i++)
			{
				float num = 0f;
				if (!string.IsNullOrEmpty(string_2[i]))
				{
					float.TryParse(string_2[i], out num);
				}
				GClass0.GClass5.float_0[i] = num;
			}
			gclass20_0.method_1<float>(GClass0.GClass5.float_0, int_0, uint_0, binaryWriter_0, bool_0);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004304 File Offset: 0x00002504
		public override int vmethod_2(string string_2, string string_3)
		{
			float num = 0f;
			float.TryParse(string_2, out num);
			float num2 = 0f;
			float.TryParse(string_3, out num2);
			return num.CompareTo(num2);
		}

		// Token: 0x04000020 RID: 32
		private static float[] float_0 = new float[4];

		// Token: 0x04000021 RID: 33
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000008 RID: 8
	public sealed class GClass6 : GClass0.GClass1
	{
		// Token: 0x06000038 RID: 56 RVA: 0x0000433C File Offset: 0x0000253C
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			double num = 0.0;
			if (!string.IsNullOrEmpty(string_2))
			{
				double.TryParse(string_2, out num);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004370 File Offset: 0x00002570
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
			GClass0.GClass6.double_0[0] = 0.0;
			GClass0.GClass6.double_0[1] = 0.0;
			GClass0.GClass6.double_0[2] = 0.0;
			GClass0.GClass6.double_0[3] = 0.0;
			for (int i = 0; i < string_2.Length; i++)
			{
				double num = 0.0;
				if (!string.IsNullOrEmpty(string_2[i]))
				{
					double.TryParse(string_2[i], out num);
				}
				GClass0.GClass6.double_0[i] = num;
			}
			gclass20_0.method_1<double>(GClass0.GClass6.double_0, int_0, uint_0, binaryWriter_0, bool_0);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000440C File Offset: 0x0000260C
		public override int vmethod_2(string string_2, string string_3)
		{
			double num = 0.0;
			double.TryParse(string_2, out num);
			double num2 = 0.0;
			double.TryParse(string_3, out num2);
			return num.CompareTo(num2);
		}

		// Token: 0x04000022 RID: 34
		private static double[] double_0 = new double[4];

		// Token: 0x04000023 RID: 35
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000009 RID: 9
	public sealed class GClass7 : GClass0.GClass1
	{
		// Token: 0x0600003D RID: 61 RVA: 0x0000444C File Offset: 0x0000264C
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_3, GClass0.GClass20 gclass20_0)
		{
			if (gclass20_0 != null)
			{
				uint num = GClass0.GClass9.smethod_0(string_3);
				GClass0.GClass7.string_1[0] = string_3;
				gclass20_0.method_1<string>(GClass0.GClass7.string_1, 1, num, binaryWriter_0, true);
			}
			else if (string.IsNullOrEmpty(string_3))
			{
				binaryWriter_0.Write("");
			}
			else
			{
				binaryWriter_0.Write(string_3);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000449C File Offset: 0x0000269C
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_3, int int_0, uint uint_0, bool bool_0)
		{
			GClass0.GClass7.string_1[0] = "";
			GClass0.GClass7.string_1[1] = "";
			GClass0.GClass7.string_1[2] = "";
			GClass0.GClass7.string_1[3] = "";
			for (int i = 0; i < string_3.Length; i++)
			{
				GClass0.GClass7.string_1[i] = string_3[i];
			}
			gclass20_0.method_1<string>(GClass0.GClass7.string_1, int_0, uint_0, binaryWriter_0, bool_0);
			gclass20_0.bool_0 = true;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000450C File Offset: 0x0000270C
		public override int vmethod_2(string string_3, string string_4)
		{
			return string_3.CompareTo(string_4);
		}

		// Token: 0x04000024 RID: 36
		private static string[] string_1 = new string[4];

		// Token: 0x04000025 RID: 37
		[NonSerialized]
		string string_2 = "";
	}

	// Token: 0x0200000A RID: 10
	public sealed class GClass8 : GClass0.GClass1
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00004524 File Offset: 0x00002724
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			uint num = 0U;
			if (!string.IsNullOrEmpty(string_2))
			{
				num = GClass0.GClass9.smethod_0(string_2);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002050 File Offset: 0x00000250
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000450C File Offset: 0x0000270C
		public override int vmethod_2(string string_2, string string_3)
		{
			return string_2.CompareTo(string_3);
		}

		// Token: 0x04000026 RID: 38
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x0200000B RID: 11
	public sealed class GClass9 : GClass0.GClass1
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000454C File Offset: 0x0000274C
		public static uint smethod_0(string string_2)
		{
			uint num;
			if (string.IsNullOrEmpty(string_2))
			{
				num = 0U;
			}
			else
			{
				int num2 = 5;
				uint num3 = 0U;
				for (int i = 0; i < string_2.Length; i++)
				{
					num3 = (num3 << num2) + num3 + (uint)string_2[i];
				}
				num = num3;
			}
			return num;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004594 File Offset: 0x00002794
		public static uint smethod_1(uint uint_0, string string_2)
		{
			uint num;
			if (string_2 == null)
			{
				num = uint_0;
			}
			else
			{
				int num2 = 5;
				foreach (char c in string_2)
				{
					uint_0 = (uint_0 << num2) + uint_0 + (uint)c;
				}
				num = uint_0;
			}
			return num;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004524 File Offset: 0x00002724
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			uint num = 0U;
			if (!string.IsNullOrEmpty(string_2))
			{
				num = GClass0.GClass9.smethod_0(string_2);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002050 File Offset: 0x00000250
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000450C File Offset: 0x0000270C
		public override int vmethod_2(string string_2, string string_3)
		{
			return string_2.CompareTo(string_3);
		}

		// Token: 0x04000027 RID: 39
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x0200000C RID: 12
	public sealed class GClass10 : GClass0.GClass1
	{
		// Token: 0x0600004C RID: 76 RVA: 0x000045DC File Offset: 0x000027DC
		private bool method_0(string string_2)
		{
			return string_2.Length != 0 && (string_2.ToLower() == "true" || string_2 == "1" || (!(string_2.ToLower() == "false") && !(string_2 == "0")));
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002105 File Offset: 0x00000305
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				binaryWriter_0.Write(false);
			}
			else
			{
				binaryWriter_0.Write(this.method_0(string_2));
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002050 File Offset: 0x00000250
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002125 File Offset: 0x00000325
		public override int vmethod_2(string string_2, string string_3)
		{
			return 0;
		}

		// Token: 0x04000028 RID: 40
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x0200000D RID: 13
	public sealed class GClass11 : GClass0.GClass1
	{
		// Token: 0x06000051 RID: 81 RVA: 0x0000464C File Offset: 0x0000284C
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			byte b = 0;
			if (!string.IsNullOrEmpty(string_2))
			{
				byte.TryParse(string_2, out b);
			}
			binaryWriter_0.Write(b);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002050 File Offset: 0x00000250
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004678 File Offset: 0x00002878
		public override int vmethod_2(string string_2, string string_3)
		{
			byte b = 0;
			byte.TryParse(string_2, out b);
			byte b2 = 0;
			byte.TryParse(string_3, out b2);
			return b.CompareTo(b2);
		}

		// Token: 0x04000029 RID: 41
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x0200000E RID: 14
	public sealed class GClass12 : GClass0.GClass1
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000046A8 File Offset: 0x000028A8
		public override void vmethod_0(BinaryWriter binaryWriter_0, string string_2, GClass0.GClass20 gclass20_0)
		{
			short num = 0;
			if (!string.IsNullOrEmpty(string_2))
			{
				short.TryParse(string_2, out num);
			}
			binaryWriter_0.Write(num);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002050 File Offset: 0x00000250
		public override void vmethod_1(BinaryWriter binaryWriter_0, GClass0.GClass20 gclass20_0, string[] string_2, int int_0, uint uint_0, bool bool_0)
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000046D4 File Offset: 0x000028D4
		public override int vmethod_2(string string_2, string string_3)
		{
			short num = 0;
			short.TryParse(string_2, out num);
			short num2 = 0;
			short.TryParse(string_3, out num2);
			return num.CompareTo(num2);
		}

		// Token: 0x0400002A RID: 42
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x0200000F RID: 15
	public abstract class GClass13
	{
		// Token: 0x06000059 RID: 89
		public abstract string vmethod_0(int int_0, string string_1);

		// Token: 0x0400002B RID: 43
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x02000010 RID: 16
	public sealed class GClass14 : GClass0.GClass13
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00004704 File Offset: 0x00002904
		public override string vmethod_0(int int_0, string string_2)
		{
			if (int_0 == 1)
			{
				string_2 = string_2.Replace("||", GClass0.GClass14.char_0.ToString() ?? "");
				string_2 = string_2.Replace("|[", GClass0.GClass14.char_1.ToString() ?? "");
				string_2 = string_2.Replace("|]", GClass0.GClass14.char_2.ToString() ?? "");
			}
			return string_2;
		}

		// Token: 0x0400002C RID: 44
		private static readonly char char_0 = '\u001f';

		// Token: 0x0400002D RID: 45
		private static readonly char char_1 = '\u0002';

		// Token: 0x0400002E RID: 46
		private static readonly char char_2 = '\u0003';

		// Token: 0x0400002F RID: 47
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000011 RID: 17
	public sealed class GClass15
	{
		// Token: 0x04000030 RID: 48
		public int int_0 = 0;

		// Token: 0x04000031 RID: 49
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x02000012 RID: 18
	public enum ETableFieldType
	{
		// Token: 0x04000033 RID: 51
		EValue,
		// Token: 0x04000034 RID: 52
		EArray,
		// Token: 0x04000035 RID: 53
		ESeq,
		// Token: 0x04000036 RID: 54
		ESeqList,
		// Token: 0x04000037 RID: 55
		ENum
	}

	// Token: 0x02000013 RID: 19
	public enum GEnum0
	{
		// Token: 0x04000039 RID: 57
		const_0,
		// Token: 0x0400003A RID: 58
		const_1,
		// Token: 0x0400003B RID: 59
		const_2,
		// Token: 0x0400003C RID: 60
		const_3,
		// Token: 0x0400003D RID: 61
		const_4,
		// Token: 0x0400003E RID: 62
		const_5,
		// Token: 0x0400003F RID: 63
		const_6,
		// Token: 0x04000040 RID: 64
		const_7,
		// Token: 0x04000041 RID: 65
		const_8,
		// Token: 0x04000042 RID: 66
		const_9
	}

	// Token: 0x02000014 RID: 20
	public class GClass16
	{
		// Token: 0x0600005F RID: 95 RVA: 0x0000478C File Offset: 0x0000298C
		public bool method_0(string string_3)
		{
			uint num = Class2.smethod_0(string_3);
			if (num <= 2699759368U)
			{
				if (num <= 727862914U)
				{
					if (num != 398550328U)
					{
						if (num == 727862914U)
						{
							if (string_3 == "string2Hash")
							{
								this.gclass1_0 = GClass0.GClass16.gclass8_0;
								this.string_1 = "U";
								this.byte_0 = 2;
								return true;
							}
						}
					}
					else if (string_3 == "string")
					{
						if (this.bool_0)
						{
							this.gclass1_0 = GClass0.GClass16.gclass9_0;
						}
						else
						{
							this.gclass1_0 = GClass0.GClass16.gclass7_0;
						}
						this.string_1 = "S";
						this.byte_0 = 5;
						return true;
					}
				}
				else if (num != 1683620383U)
				{
					if (num != 2515107422U)
					{
						if (num == 2699759368U)
						{
							if (string_3 == "double")
							{
								this.gclass1_0 = GClass0.GClass16.gclass6_0;
								this.string_1 = "D";
								this.byte_0 = 1;
								return true;
							}
						}
					}
					else if (string_3 == "int")
					{
						this.gclass1_0 = GClass0.GClass16.gclass3_0;
						this.string_1 = "I";
						this.byte_0 = 3;
						return true;
					}
				}
				else if (string_3 == "byte")
				{
					this.gclass1_0 = GClass0.GClass16.gclass11_0;
					this.string_1 = "T";
					this.byte_0 = 7;
					return true;
				}
			}
			else if (num <= 3122818005U)
			{
				if (num != 2797886853U)
				{
					if (num == 3122818005U)
					{
						if (string_3 == "short")
						{
							this.gclass1_0 = GClass0.GClass16.gclass12_0;
							this.string_1 = "H";
							this.byte_0 = 8;
							return true;
						}
					}
				}
				else if (string_3 == "float")
				{
					this.gclass1_0 = GClass0.GClass16.gclass5_0;
					this.string_1 = "F";
					this.byte_0 = 0;
					return true;
				}
			}
			else if (num != 3270303571U)
			{
				if (num != 3365180733U)
				{
					if (num == 3415750305U)
					{
						if (string_3 == "uint")
						{
							this.gclass1_0 = GClass0.GClass16.gclass2_0;
							this.string_1 = "U";
							this.byte_0 = 2;
							return true;
						}
					}
				}
				else if (string_3 == "bool")
				{
					this.gclass1_0 = GClass0.GClass16.gclass10_0;
					this.string_1 = "B";
					this.byte_0 = 6;
					return true;
				}
			}
			else if (string_3 == "long")
			{
				this.gclass1_0 = GClass0.GClass16.gclass4_0;
				this.string_1 = "L";
				this.byte_0 = 4;
				return true;
			}
			return false;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002154 File Offset: 0x00000354
		private void method_1(string string_3)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004A38 File Offset: 0x00002C38
		public int method_2(string[] string_3, string[] string_4, GClass0.GClass16 gclass16_0)
		{
			string text = string_3[this.int_0].Trim();
			string text2 = string_4[this.int_0].Trim();
			int num6;
			if (this.int_2 == 2)
			{
				uint num = GClass0.GClass9.smethod_0(text);
				uint num2 = GClass0.GClass9.smethod_0(text2);
				int num3 = num.CompareTo(num2);
				if (num3 == 0 && gclass16_0 != null)
				{
					uint num4 = 0U;
					uint.TryParse(string_3[gclass16_0.int_0].Trim(), out num4);
					uint num5 = 0U;
					uint.TryParse(string_4[gclass16_0.int_0].Trim(), out num5);
					num6 = num4.CompareTo(num5);
				}
				else
				{
					num6 = num3;
				}
			}
			else
			{
				num6 = this.gclass1_0.vmethod_2(text, text2);
			}
			return num6;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000215B File Offset: 0x0000035B
		[CompilerGenerated]
		public object method_3()
		{
			return this.object_0;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002163 File Offset: 0x00000363
		[CompilerGenerated]
		public void method_4(object object_1)
		{
			this.object_0 = object_1;
		}

		// Token: 0x04000043 RID: 67
		public int int_0 = -1;

		// Token: 0x04000044 RID: 68
		public string string_0 = "";

		// Token: 0x04000045 RID: 69
		public GClass0.ETableFieldType etableFieldType_0 = GClass0.ETableFieldType.EValue;

		// Token: 0x04000046 RID: 70
		public GClass0.GClass1 gclass1_0 = null;

		// Token: 0x04000047 RID: 71
		public int int_1 = 2;

		// Token: 0x04000048 RID: 72
		public string string_1 = "";

		// Token: 0x04000049 RID: 73
		public byte byte_0 = byte.MaxValue;

		// Token: 0x0400004A RID: 74
		public bool bool_0 = false;

		// Token: 0x0400004B RID: 75
		public int int_2 = 0;

		// Token: 0x0400004C RID: 76
		public int int_3 = 0;

		// Token: 0x0400004D RID: 77
		public static GClass0.GClass5 gclass5_0 = new GClass0.GClass5();

		// Token: 0x0400004E RID: 78
		public static GClass0.GClass6 gclass6_0 = new GClass0.GClass6();

		// Token: 0x0400004F RID: 79
		public static GClass0.GClass2 gclass2_0 = new GClass0.GClass2();

		// Token: 0x04000050 RID: 80
		public static GClass0.GClass3 gclass3_0 = new GClass0.GClass3();

		// Token: 0x04000051 RID: 81
		public static GClass0.GClass4 gclass4_0 = new GClass0.GClass4();

		// Token: 0x04000052 RID: 82
		public static GClass0.GClass7 gclass7_0 = new GClass0.GClass7();

		// Token: 0x04000053 RID: 83
		public static GClass0.GClass8 gclass8_0 = new GClass0.GClass8();

		// Token: 0x04000054 RID: 84
		public static GClass0.GClass10 gclass10_0 = new GClass0.GClass10();

		// Token: 0x04000055 RID: 85
		public static GClass0.GClass9 gclass9_0 = new GClass0.GClass9();

		// Token: 0x04000056 RID: 86
		public static GClass0.GClass11 gclass11_0 = new GClass0.GClass11();

		// Token: 0x04000057 RID: 87
		public static GClass0.GClass12 gclass12_0 = new GClass0.GClass12();

		// Token: 0x04000058 RID: 88
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private object object_0;

		// Token: 0x04000059 RID: 89
		[NonSerialized]
		string string_2 = "";
	}

	// Token: 0x02000015 RID: 21
	public class GClass17
	{
		// Token: 0x0400005A RID: 90
		public string string_0;

		// Token: 0x0400005B RID: 91
		public string string_1;

		// Token: 0x0400005C RID: 92
		[NonSerialized]
		string string_2 = "";
	}

	// Token: 0x02000016 RID: 22
	public class GClass18
	{
		// Token: 0x0400005D RID: 93
		public List<string> list_0;

		// Token: 0x0400005E RID: 94
		public List<GClass0.GClass17> list_1;

		// Token: 0x0400005F RID: 95
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x02000017 RID: 23
	public class GClass19
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000216C File Offset: 0x0000036C
		public GClass19(string[] string_2, int int_1)
		{
			this.string_0 = string_2;
			this.int_0 = int_1;
		}

		// Token: 0x04000060 RID: 96
		public string[] string_0;

		// Token: 0x04000061 RID: 97
		public int int_0;

		// Token: 0x04000062 RID: 98
		[NonSerialized]
		string string_1 = "";
	}

	// Token: 0x02000018 RID: 24
	public class GClass20
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00004BD0 File Offset: 0x00002DD0
		public static void smethod_0<T>(BinaryWriter binaryWriter_0, GClass0.GClass20.GDelegate0<T> gdelegate0_0)
		{
			int num = GClass0.GClass20.GClass21<T>.list_0.Count;
			if (num == 4)
			{
				num = 0;
			}
			int num2 = num;
			binaryWriter_0.Write(num2);
			for (int i = 0; i < num; i++)
			{
				gdelegate0_0(binaryWriter_0, GClass0.GClass20.GClass21<T>.list_0[i]);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002182 File Offset: 0x00000382
		private static void smethod_1(BinaryWriter binaryWriter_0, string string_1)
		{
			if (string_1 == null)
			{
				string_1 = string.Empty;
			}
			binaryWriter_0.Write(string_1);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002198 File Offset: 0x00000398
		private static void smethod_2(BinaryWriter binaryWriter_0, int int_0)
		{
			binaryWriter_0.Write(int_0);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000021A1 File Offset: 0x000003A1
		private static void smethod_3(BinaryWriter binaryWriter_0, uint uint_0)
		{
			binaryWriter_0.Write(uint_0);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000021AA File Offset: 0x000003AA
		private static void smethod_4(BinaryWriter binaryWriter_0, long long_0)
		{
			binaryWriter_0.Write(long_0);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000021B3 File Offset: 0x000003B3
		private static void smethod_5(BinaryWriter binaryWriter_0, float float_0)
		{
			binaryWriter_0.Write(float_0);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000021BC File Offset: 0x000003BC
		private static void smethod_6(BinaryWriter binaryWriter_0, double double_0)
		{
			binaryWriter_0.Write(double_0);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000021C5 File Offset: 0x000003C5
		public void method_0()
		{
			this.bool_0 = false;
			GClass0.GClass20.GClass21<string>.smethod_0();
			GClass0.GClass20.GClass21<int>.smethod_0();
			GClass0.GClass20.GClass21<uint>.smethod_0();
			GClass0.GClass20.GClass21<long>.smethod_0();
			GClass0.GClass20.GClass21<float>.smethod_0();
			GClass0.GClass20.GClass21<double>.smethod_0();
			GClass0.GClass20.list_0.Clear();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004C1C File Offset: 0x00002E1C
		public void method_1<T>(T[] gparam_0, int int_0, uint uint_0, BinaryWriter binaryWriter_0, bool bool_1)
		{
			GClass0.GClass20.GClass21<T> gclass = null;
			if (!GClass0.GClass20.GClass21<T>.dictionary_0.TryGetValue(uint_0, out gclass))
			{
				gclass = new GClass0.GClass20.GClass21<T>();
				gclass.int_1 = GClass0.GClass20.GClass21<T>.list_0.Count;
				GClass0.GClass20.GClass21<T>.dictionary_0.Add(uint_0, gclass);
				for (int i = 0; i < int_0; i++)
				{
					GClass0.GClass20.GClass21<T>.list_0.Add(gparam_0[i]);
				}
			}
			gclass.int_0++;
			if (bool_1)
			{
				if (gclass.int_1 > 65535)
				{
					Console.WriteLine("Too Many index!!");
				}
				int int_ = gclass.int_1;
				binaryWriter_0.Write(int_);
			}
			else
			{
				GClass0.GClass20.list_0.Add(gclass.int_1);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004CD0 File Offset: 0x00002ED0
		public void method_2(BinaryWriter binaryWriter_0)
		{
			binaryWriter_0.Write(this.bool_0);
			GClass0.GClass20.smethod_0<string>(binaryWriter_0, new GClass0.GClass20.GDelegate0<string>(GClass0.GClass20.smethod_1));
			GClass0.GClass20.smethod_0<int>(binaryWriter_0, new GClass0.GClass20.GDelegate0<int>(GClass0.GClass20.smethod_2));
			GClass0.GClass20.smethod_0<uint>(binaryWriter_0, new GClass0.GClass20.GDelegate0<uint>(GClass0.GClass20.smethod_3));
			GClass0.GClass20.smethod_0<long>(binaryWriter_0, new GClass0.GClass20.GDelegate0<long>(GClass0.GClass20.smethod_4));
			GClass0.GClass20.smethod_0<float>(binaryWriter_0, new GClass0.GClass20.GDelegate0<float>(GClass0.GClass20.smethod_5));
			GClass0.GClass20.smethod_0<double>(binaryWriter_0, new GClass0.GClass20.GDelegate0<double>(GClass0.GClass20.smethod_6));
			int count = GClass0.GClass20.list_0.Count;
			binaryWriter_0.Write(count);
			for (int i = 0; i < count; i++)
			{
				binaryWriter_0.Write(GClass0.GClass20.list_0[i]);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004D88 File Offset: 0x00002F88
		public void method_3(StringBuilder stringBuilder_0)
		{
			stringBuilder_0.AppendFormat("string count\t\t{0}\r\n", (GClass0.GClass20.GClass21<string>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<string>.list_0.Count);
			stringBuilder_0.AppendFormat("int count\t\t{0}\r\n", (GClass0.GClass20.GClass21<int>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<int>.list_0.Count);
			stringBuilder_0.AppendFormat("uint count\t\t{0}\r\n", (GClass0.GClass20.GClass21<uint>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<uint>.list_0.Count);
			stringBuilder_0.AppendFormat("long count\t\t{0}\r\n", (GClass0.GClass20.GClass21<long>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<long>.list_0.Count);
			stringBuilder_0.AppendFormat("float count\t\t{0}\r\n", (GClass0.GClass20.GClass21<float>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<float>.list_0.Count);
			stringBuilder_0.AppendFormat("double count\t\t{0}\r\n", (GClass0.GClass20.GClass21<double>.list_0.Count == 4) ? 0 : GClass0.GClass20.GClass21<double>.list_0.Count);
			stringBuilder_0.AppendFormat("index count\t\t{0}\r\n", GClass0.GClass20.list_0.Count);
		}

		// Token: 0x04000063 RID: 99
		public static List<int> list_0 = new List<int>();

		// Token: 0x04000064 RID: 100
		public bool bool_0 = false;

		// Token: 0x04000065 RID: 101
		[NonSerialized]
		string string_0 = "";

		// Token: 0x02000019 RID: 25
		public sealed class GDelegate0<T> : MulticastDelegate
		{
			// Token: 0x06000076 RID: 118
			public extern GDelegate0(object object_0, IntPtr intptr_0);

			// Token: 0x06000077 RID: 119
			public extern void Invoke(BinaryWriter binaryWriter_0, T gparam_0);

			// Token: 0x06000078 RID: 120
			public extern IAsyncResult BeginInvoke(BinaryWriter binaryWriter_0, T gparam_0, AsyncCallback asyncCallback_0, object object_0);

			// Token: 0x06000079 RID: 121
			public extern void EndInvoke(IAsyncResult iasyncResult_0);

			// Token: 0x04000066 RID: 102
			[NonSerialized]
			string string_0 = "";
		}

		// Token: 0x0200001A RID: 26
		public class GClass21<T>
		{
			// Token: 0x0600007A RID: 122 RVA: 0x00004EB8 File Offset: 0x000030B8
			public static void smethod_0()
			{
				GClass0.GClass20.GClass21<T>.dictionary_0.Clear();
				GClass0.GClass20.GClass21<T> gclass = new GClass0.GClass20.GClass21<T>();
				gclass.int_1 = 0;
				gclass.int_0 = 0;
				GClass0.GClass20.GClass21<T>.dictionary_0.Add(0U, gclass);
				GClass0.GClass20.GClass21<T>.list_0.Clear();
				GClass0.GClass20.GClass21<T>.list_0.Add(default(T));
				GClass0.GClass20.GClass21<T>.list_0.Add(default(T));
				GClass0.GClass20.GClass21<T>.list_0.Add(default(T));
				GClass0.GClass20.GClass21<T>.list_0.Add(default(T));
			}

			// Token: 0x04000067 RID: 103
			public int int_0 = 0;

			// Token: 0x04000068 RID: 104
			public int int_1 = 0;

			// Token: 0x04000069 RID: 105
			public static Dictionary<uint, GClass0.GClass20.GClass21<T>> dictionary_0 = new Dictionary<uint, GClass0.GClass20.GClass21<T>>();

			// Token: 0x0400006A RID: 106
			public static List<T> list_0 = new List<T>();

			// Token: 0x0400006B RID: 107
			[NonSerialized]
			string string_0 = "";
		}
	}
}
