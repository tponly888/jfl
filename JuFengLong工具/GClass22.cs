using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

// Token: 0x0200001B RID: 27
public class GClass22<T> where T : class, GInterface0
{
	// Token: 0x0600007D RID: 125 RVA: 0x0000223D File Offset: 0x0000043D
	[CompilerGenerated]
	public GClass22<T>.GDelegate1 method_0()
	{
		return this.gdelegate1_0;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00002245 File Offset: 0x00000445
	[CompilerGenerated]
	public void method_1(GClass22<T>.GDelegate1 gdelegate1_1)
	{
		this.gdelegate1_0 = gdelegate1_1;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000224E File Offset: 0x0000044E
	[CompilerGenerated]
	public GClass22<T>.GDelegate2 method_2()
	{
		return this.gdelegate2_0;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00002256 File Offset: 0x00000456
	[CompilerGenerated]
	public void method_3(GClass22<T>.GDelegate2 gdelegate2_1)
	{
		this.gdelegate2_0 = gdelegate2_1;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0000225F File Offset: 0x0000045F
	[CompilerGenerated]
	public GClass22<T>.GDelegate3 method_4()
	{
		return this.gdelegate3_0;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00002267 File Offset: 0x00000467
	[CompilerGenerated]
	public void method_5(GClass22<T>.GDelegate3 gdelegate3_1)
	{
		this.gdelegate3_0 = gdelegate3_1;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00002270 File Offset: 0x00000470
	[CompilerGenerated]
	public GClass22<T>.GDelegate4 method_6()
	{
		return this.gdelegate4_0;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00002278 File Offset: 0x00000478
	[CompilerGenerated]
	public void method_7(GClass22<T>.GDelegate4 gdelegate4_1)
	{
		this.gdelegate4_0 = gdelegate4_1;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00002281 File Offset: 0x00000481
	[CompilerGenerated]
	public GClass22<T>.GDelegate5 method_8()
	{
		return this.gdelegate5_0;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00002289 File Offset: 0x00000489
	[CompilerGenerated]
	public void method_9(GClass22<T>.GDelegate5 gdelegate5_1)
	{
		this.gdelegate5_0 = gdelegate5_1;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00004F48 File Offset: 0x00003148
	public static GClass22<T> smethod_0()
	{
		return GClass22<T>.gclass22_0;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00002292 File Offset: 0x00000492
	[CompilerGenerated]
	public string method_10()
	{
		return this.string_0;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000229A File Offset: 0x0000049A
	[CompilerGenerated]
	public void method_11(string string_3)
	{
		this.string_0 = string_3;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000022A3 File Offset: 0x000004A3
	[CompilerGenerated]
	public string method_12()
	{
		return this.string_1;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x000022AB File Offset: 0x000004AB
	[CompilerGenerated]
	public void method_13(string string_3)
	{
		this.string_1 = string_3;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00004F5C File Offset: 0x0000315C
	public List<string> method_14()
	{
		return this.dictionary_0.Keys.ToList<string>();
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00004F7C File Offset: 0x0000317C
	public List<T> method_15()
	{
		return this.dictionary_0.Values.ToList<T>();
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00004F9C File Offset: 0x0000319C
	public List<string> method_16(string string_3)
	{
		List<string> list;
		if (string_3.Length == 0)
		{
			list = this.method_14();
		}
		else
		{
			List<string> list2 = new List<string>();
			foreach (string text in this.method_14())
			{
				if (text.IndexOf(string_3, StringComparison.OrdinalIgnoreCase) != -1)
				{
					list2.Add(text);
				}
			}
			list = list2;
		}
		return list;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00005024 File Offset: 0x00003224
	public bool method_17(T gparam_0)
	{
		bool flag;
		if (this.dictionary_0.ContainsKey(gparam_0.imethod_0()))
		{
			flag = false;
		}
		else
		{
			this.dictionary_0[gparam_0.imethod_0()] = gparam_0;
			if (this.method_0() != null)
			{
				this.method_0()(gparam_0);
			}
			flag = true;
		}
		return flag;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000022B4 File Offset: 0x000004B4
	public void method_18(string string_3)
	{
		if (this.method_2() != null)
		{
			this.method_2()(this.dictionary_0[string_3]);
		}
		this.dictionary_0.Remove(string_3);
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00005080 File Offset: 0x00003280
	public T method_19(string string_3)
	{
		T t;
		if (this.dictionary_0.ContainsKey(string_3))
		{
			t = this.dictionary_0[string_3];
		}
		else
		{
			t = default(T);
		}
		return t;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000050B8 File Offset: 0x000032B8
	public void method_20(T gparam_0)
	{
		string text = gparam_0.imethod_0();
		if (this.method_4() != null)
		{
			T t = this.dictionary_0[text];
			this.method_4()(t, gparam_0);
		}
		this.dictionary_0[text] = gparam_0;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x000022E5 File Offset: 0x000004E5
	public void method_21()
	{
		this.method_24();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00005104 File Offset: 0x00003304
	public void method_22()
	{
		this.method_25();
		if (!string.IsNullOrEmpty(this.method_12()))
		{
			try
			{
				File.Copy(this.method_10(), this.method_12(), true);
				if (this.method_8() != null)
				{
					this.method_8()("文件" + this.method_10() + " copy 成功，目标：" + this.method_12());
				}
			}
			catch (Exception ex)
			{
				if (this.method_8() != null)
				{
					this.method_8()(string.Concat(new string[]
					{
						"文件",
						this.method_10(),
						" copy 出错，目标：",
						this.method_12(),
						" ",
						ex.Message
					}));
				}
			}
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000022ED File Offset: 0x000004ED
	private void method_23()
	{
		this.dictionary_0.Clear();
		this.method_24();
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000051E0 File Offset: 0x000033E0
	public void method_24()
	{
		List<T> list = new List<T>();
		XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
		try
		{
			string text = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + this.method_10();
			FileStream fileStream = new FileStream(text, FileMode.Open);
			list = (List<T>)xmlSerializer.Deserialize(fileStream);
			foreach (T t in list)
			{
				this.dictionary_0.Add(t.imethod_0(), t);
			}
			fileStream.Close();
			FileInfo fileInfo = new FileInfo(text);
			this.dateTime_0 = fileInfo.LastWriteTime;
			if (this.method_6() != null)
			{
				this.method_6()();
			}
		}
		catch (FileNotFoundException ex)
		{
			if (this.method_8() != null)
			{
				this.method_8()(ex.ToString());
			}
		}
	}

	// Token: 0x06000097 RID: 151 RVA: 0x000052E8 File Offset: 0x000034E8
	public void method_25()
	{
		if (this.bool_0)
		{
			FileInfo fileInfo = new FileInfo(this.method_10());
			if (this.dateTime_0 < fileInfo.LastWriteTime)
			{
				if (this.method_8() != null)
				{
					this.method_8()("文件" + this.method_10() + "已经被其他程序改变，需要退出后重新启动！");
					return;
				}
				return;
			}
		}
		List<T> list = this.dictionary_0.Values.ToList<T>();
		XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
		FileStream fileStream = new FileStream(this.method_10(), FileMode.OpenOrCreate);
		fileStream.SetLength(0L);
		xmlSerializer.Serialize(fileStream, list);
		fileStream.Close();
		FileInfo fileInfo2 = new FileInfo(this.method_10());
		this.dateTime_0 = fileInfo2.LastWriteTime;
	}

	// Token: 0x0400006C RID: 108
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GClass22<T>.GDelegate1 gdelegate1_0;

	// Token: 0x0400006D RID: 109
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GClass22<T>.GDelegate2 gdelegate2_0;

	// Token: 0x0400006E RID: 110
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GClass22<T>.GDelegate3 gdelegate3_0;

	// Token: 0x0400006F RID: 111
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GClass22<T>.GDelegate4 gdelegate4_0;

	// Token: 0x04000070 RID: 112
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GClass22<T>.GDelegate5 gdelegate5_0;

	// Token: 0x04000071 RID: 113
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_0;

	// Token: 0x04000072 RID: 114
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_1;

	// Token: 0x04000073 RID: 115
	private static GClass22<T> gclass22_0 = new GClass22<T>();

	// Token: 0x04000074 RID: 116
	public bool bool_0 = true;

	// Token: 0x04000075 RID: 117
	private DateTime dateTime_0;

	// Token: 0x04000076 RID: 118
	private Dictionary<string, T> dictionary_0 = new Dictionary<string, T>();

	// Token: 0x04000077 RID: 119
	[NonSerialized]
	string string_2 = "";

	// Token: 0x0200001C RID: 28
	public sealed class GDelegate1 : MulticastDelegate
	{
		// Token: 0x0600009A RID: 154
		public extern GDelegate1(object object_0, IntPtr intptr_0);

		// Token: 0x0600009B RID: 155
		public extern void Invoke(T gparam_0);

		// Token: 0x0600009C RID: 156
		public extern IAsyncResult BeginInvoke(T gparam_0, AsyncCallback asyncCallback_0, object object_0);

		// Token: 0x0600009D RID: 157
		public extern void EndInvoke(IAsyncResult iasyncResult_0);

		// Token: 0x04000078 RID: 120
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x0200001D RID: 29
	public sealed class GDelegate2 : MulticastDelegate
	{
		// Token: 0x0600009E RID: 158
		public extern GDelegate2(object object_0, IntPtr intptr_0);

		// Token: 0x0600009F RID: 159
		public extern void Invoke(T gparam_0);

		// Token: 0x060000A0 RID: 160
		public extern IAsyncResult BeginInvoke(T gparam_0, AsyncCallback asyncCallback_0, object object_0);

		// Token: 0x060000A1 RID: 161
		public extern void EndInvoke(IAsyncResult iasyncResult_0);

		// Token: 0x04000079 RID: 121
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x0200001E RID: 30
	public sealed class GDelegate3 : MulticastDelegate
	{
		// Token: 0x060000A2 RID: 162
		public extern GDelegate3(object object_0, IntPtr intptr_0);

		// Token: 0x060000A3 RID: 163
		public extern void Invoke(T gparam_0, T gparam_1);

		// Token: 0x060000A4 RID: 164
		public extern IAsyncResult BeginInvoke(T gparam_0, T gparam_1, AsyncCallback asyncCallback_0, object object_0);

		// Token: 0x060000A5 RID: 165
		public extern void EndInvoke(IAsyncResult iasyncResult_0);

		// Token: 0x0400007A RID: 122
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x0200001F RID: 31
	public sealed class GDelegate4 : MulticastDelegate
	{
		// Token: 0x060000A6 RID: 166
		public extern GDelegate4(object object_0, IntPtr intptr_0);

		// Token: 0x060000A7 RID: 167
		public extern void Invoke();

		// Token: 0x060000A8 RID: 168
		public extern IAsyncResult BeginInvoke(AsyncCallback asyncCallback_0, object object_0);

		// Token: 0x060000A9 RID: 169
		public extern void EndInvoke(IAsyncResult iasyncResult_0);

		// Token: 0x0400007B RID: 123
		[NonSerialized]
		string string_0 = "";
	}

	// Token: 0x02000020 RID: 32
	public sealed class GDelegate5 : MulticastDelegate
	{
		// Token: 0x060000AA RID: 170
		public extern GDelegate5(object object_0, IntPtr intptr_0);

		// Token: 0x060000AB RID: 171
		public extern void Invoke(string string_1);

		// Token: 0x060000AC RID: 172
		public extern IAsyncResult BeginInvoke(string string_1, AsyncCallback asyncCallback_0, object object_0);

		// Token: 0x060000AD RID: 173
		public extern void EndInvoke(IAsyncResult iasyncResult_0);

		// Token: 0x0400007C RID: 124
		[NonSerialized]
		string string_0 = "";
	}
}
