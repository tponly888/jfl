using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

// Token: 0x02000022 RID: 34
public partial class Form1 : Form
{
	// Token: 0x060000BA RID: 186 RVA: 0x000054E0 File Offset: 0x000036E0
	public Form1()
	{
		this.InitializeComponent();
		this.textBox1.Text = this.string_6 + this.string_1;
		this.textBox2.Text = this.string_6 + this.string_2;
		this.textBox3.Text = this.string_6 + this.string_3;
		this.string_4 = this.string_6 + this.string_4;
		this.string_5 = this.string_6 + this.string_5;
		this.method_0();
	}

	// Token: 0x060000BB RID: 187 RVA: 0x0000237D File Offset: 0x0000057D
	private void button1_Click(object sender, EventArgs e)
	{
		Process.Start("explorer.exe", this.textBox1.Text);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00002395 File Offset: 0x00000595
	private void button2_Click(object sender, EventArgs e)
	{
		Process.Start("explorer.exe", this.textBox2.Text);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x000023AD File Offset: 0x000005AD
	private void button3_Click(object sender, EventArgs e)
	{
		Process.Start("explorer.exe", this.textBox3.Text);
	}

	// Token: 0x060000BE RID: 190 RVA: 0x000055F8 File Offset: 0x000037F8
	private void button4_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		Assembly assembly = Assembly.LoadFile(this.string_4);
		this.label6.Text = "0";
		this.label8.Text = "0";
		if (this.list_0.Count > 0)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				string text = this.list_0[i];
				string text2 = this.list_1[i];
				byte[] array = File.ReadAllBytes(text);
				try
				{
					Type type = assembly.GetType("XUtliPoolLib.XBinaryReader");
					MethodInfo method = type.GetMethod("Get");
					MethodInfo method2 = type.GetMethod("InitByte");
					object obj = Activator.CreateInstance(type);
					method.Invoke(obj, null);
					method2.Invoke(obj, new object[] { array, 0, 0 });
					string text3 = "XUtliPoolLib." + text2;
					text3 = "XUtliPoolLib." + Class1.smethod_8(text2);
					Type type2 = assembly.GetType(text3);
					if (type2 == null)
					{
						text3 = "XUtliPoolLib." + text2 + "Table";
						type2 = assembly.GetType(text3);
						if (type2 == null)
						{
							text3 = "XUtliPoolLib." + text2 + "List";
							type2 = assembly.GetType(text3);
							if (type2 == null)
							{
								throw new Exception("没有" + text2 + "方法");
							}
						}
					}
					Type type3 = assembly.GetType("XUtliPoolLib.CVSReader");
					MethodInfo method3 = type3.GetMethod("Init");
					method3.Invoke(type3, null);
					MethodInfo method4 = type2.GetMethod("ReadFile");
					object obj2 = Activator.CreateInstance(type2);
					method4.Invoke(obj2, new object[] { obj });
					Type type4 = obj2.GetType();
					FieldInfo[] fields = type4.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					type4.GetFields();
					object obj3 = null;
					int num3 = 0;
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.Name == "Table")
						{
							obj3 = fieldInfo.GetValue(obj2);
						}
						if (fieldInfo.Name == "lineno")
						{
							num3 = (int)fieldInfo.GetValue(obj2);
						}
						if (fieldInfo.Name == "columnno")
						{
							int num4 = (int)fieldInfo.GetValue(obj2);
						}
					}
					if (obj3 != null)
					{
						Type type5 = assembly.GetType(text3 + "+RowData[]");
						Type type6 = assembly.GetType(text3 + "+RowData");
						type6.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
						DataTable dataTable = new DataTable(text2);
						for (int k = 0; k < num3; k++)
						{
							MethodInfo method5 = type5.GetMethod("Get");
							object obj4 = Activator.CreateInstance(type6);
							obj4 = method5.Invoke(obj3, new object[] { k });
							FieldInfo[] fields2 = type6.GetFields();
							if (k == 0)
							{
								foreach (FieldInfo fieldInfo2 in fields2)
								{
									string text4 = fieldInfo2.Name.ToString();
									dataTable.Columns.Add(new DataColumn(text4, typeof(string)));
								}
							}
							DataRow dataRow = dataTable.NewRow();
							if (k == 16)
							{
							}
							foreach (FieldInfo fieldInfo3 in fields2)
							{
								string text5 = fieldInfo3.Name.ToString();
								FieldInfo field = obj4.GetType().GetField(text5);
								object value = field.GetValue(obj4);
								string text6 = Class1.smethod_0(value);
								dataRow[text5] = text6;
							}
							dataTable.Rows.Add(dataRow);
						}
						Class1.smethod_1(dataTable, this.string_2 + text2 + ".txt");
						string text7 = string.Concat(new object[] { text2, "共：", num3, "行" });
						num++;
						this.label6.Text = num.ToString();
						GClass23.smethod_0(string.Concat(new object[] { "[", i, "][成功]：解密文件", text2, "成功\r\n", text, "\r\n", text7 }), "", "", out this.string_0);
					}
					else
					{
						string text8 = string.Concat(new object[] { text2, "共：", num3, "行" });
						GClass23.smethod_0(string.Concat(new object[] { "[", i, "][未成功]：解密文件", text2, "未成功\r\n", text, "\r\n", text8 }), "", "", out this.string_0);
					}
				}
				catch (Exception)
				{
					num2++;
					this.label8.Text = num2.ToString();
				}
			}
			MessageBox.Show("解密完成");
		}
		else
		{
			MessageBox.Show("没有文件");
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00005B88 File Offset: 0x00003D88
	private void button5_Click(object sender, EventArgs e)
	{
		string[] array = new string[] { "-root", this.string_6, "-tables" };
		if (GClass0.smethod_0(array))
		{
			MessageBox.Show("加密完成");
		}
		else
		{
			MessageBox.Show("加密失败");
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00005BDC File Offset: 0x00003DDC
	private void button6_Click(object sender, EventArgs e)
	{
		if (this.textBox4.Text == "")
		{
			MessageBox.Show("没文件效验个der啊");
		}
		else
		{
			byte[] array = File.ReadAllBytes(this.textBox4.Text);
			using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create("sha1"))
			{
				hashAlgorithm.ComputeHash(array);
				MessageBox.Show("效验完成");
			}
		}
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00005C60 File Offset: 0x00003E60
	public void method_0()
	{
		this.label4.Text = "0";
		this.int_0 = 0;
		this.list_0 = new List<string>();
		try
		{
			string[] files = Directory.GetFiles(this.textBox1.Text.ToString());
			foreach (string text in files)
			{
				string text2 = Path.GetExtension(text).ToLower();
				if (text2 == ".txt")
				{
					char[] array2 = new char[] { '.', '\\' };
					string[] array3 = Path.GetFileName(text).Split(array2);
					string text3 = array3[array3.Length - 2].ToString();
					this.list_1.Add(text3);
					this.list_0.Add(text);
				}
			}
			if (this.list_0.Count > 0)
			{
				this.int_0 = this.list_0.Count;
				this.label4.Text = string.Concat(this.list_0.Count);
			}
			else
			{
				MessageBox.Show("暂无可解包文件");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("发生错误" + ex.ToString());
		}
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00005DA4 File Offset: 0x00003FA4
	private void textBox4_DragDrop(object sender, DragEventArgs e)
	{
		string text = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		this.textBox4.Text = text;
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x000023C5 File Offset: 0x000005C5
	private void textBox4_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.All;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	// Token: 0x04000082 RID: 130
	private List<string> list_0 = new List<string>();

	// Token: 0x04000083 RID: 131
	private List<string> list_1 = new List<string>();

	// Token: 0x04000084 RID: 132
	private int int_0 = 0;

	// Token: 0x04000085 RID: 133
	private string string_0 = "";

	// Token: 0x04000086 RID: 134
	private string string_1 = "客户端文件\\";

	// Token: 0x04000087 RID: 135
	private string string_2 = "客户端解密\\";

	// Token: 0x04000088 RID: 136
	private string string_3 = "客户端加密\\";

	// Token: 0x04000089 RID: 137
	private string string_4 = "XUtliPoolLib.dll";

	// Token: 0x0400008A RID: 138
	private string string_5 = "cvs.xml";

	// Token: 0x0400008B RID: 139
	private string string_6 = AppDomain.CurrentDomain.BaseDirectory;

	// Token: 0x040000A1 RID: 161
	[NonSerialized]
	string string_7 = "";
}
