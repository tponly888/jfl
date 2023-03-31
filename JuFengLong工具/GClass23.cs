using System;
using System.IO;
using System.Text;

// Token: 0x02000024 RID: 36
public class GClass23
{
	// Token: 0x060000C9 RID: 201 RVA: 0x000068CC File Offset: 0x00004ACC
	public static bool smethod_0(string string_1, string string_2, string string_3, out string string_4)
	{
		string_4 = string.Empty;
		StreamWriter streamWriter = null;
		string text = DateTime.Now.ToString("yyyy-MM-dd");
		string text2 = text + string_2 + ".txt";
		string text3 = string.Empty;
		if (string_3 != null && string_3.Trim().Length > 0)
		{
			text2 = string.Concat(new string[]
			{
				AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
				"Log\\",
				string_3,
				"\\",
				text2
			});
			text3 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Log\\" + string_3;
		}
		else
		{
			text2 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Log\\" + text2;
			text3 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Log\\";
		}
		try
		{
			if (!Directory.Exists(text3))
			{
				Directory.CreateDirectory(text3);
			}
			if (File.Exists(text2))
			{
				streamWriter = new StreamWriter(text2, true, Encoding.GetEncoding("UTF-8"));
			}
			else
			{
				streamWriter = new StreamWriter(text2, false, Encoding.GetEncoding("UTF-8"));
			}
			string text4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
			streamWriter.WriteLine(string.Concat(new string[] { "【", text4, "】 \r\n ", string_1, "\r\n" }));
		}
		catch (IOException ex)
		{
			string_4 = ex.ToString();
			return false;
		}
		finally
		{
			if (streamWriter != null)
			{
				streamWriter.Close();
			}
		}
		return true;
	}

	// Token: 0x040000A2 RID: 162
	[NonSerialized]
	string string_0 = "";
}
