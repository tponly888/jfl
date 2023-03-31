using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

// Token: 0x02000026 RID: 38
internal class Class1
{
	// Token: 0x060000CB RID: 203 RVA: 0x00006A84 File Offset: 0x00004C84
	public static string smethod_0(object object_0)
	{
		string text = "";
		string text2;
		if (object_0 == null)
		{
			text2 = "";
		}
		else
		{
			Type type = object_0.GetType();
			if (object_0 is Array)
			{
				string name = type.Name;
				if (type == typeof(uint[]))
				{
					uint[] array = (uint[])object_0;
					foreach (uint num in array)
					{
						text = text + num.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(byte[]))
				{
					byte[] array3 = (byte[])object_0;
					foreach (byte b in array3)
					{
						text = text + b.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(string[]))
				{
					string[] array5 = (string[])object_0;
					foreach (string text3 in array5)
					{
						text = text + text3.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(int[]))
				{
					int[] array7 = (int[])object_0;
					foreach (int num2 in array7)
					{
						text = text + num2.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(float[]))
				{
					float[] array9 = (float[])object_0;
					foreach (float num3 in array9)
					{
						text = text + num3.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(float[]))
				{
					float[] array11 = (float[])object_0;
					foreach (float num4 in array11)
					{
						text = text + num4.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
				if (type == typeof(short[]))
				{
					short[] array13 = (short[])object_0;
					foreach (short num6 in array13)
					{
						text = text + num6.ToString() + "|";
					}
					return Class1.smethod_5(text);
				}
			}
			text = object_0.ToString();
			text2 = text;
		}
		return text2;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00006D44 File Offset: 0x00004F44
	public static void smethod_1(DataTable dataTable_0, string string_1)
	{
		StringWriter stringWriter = new StringWriter();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < dataTable_0.Columns.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append("\t");
			}
			stringBuilder.Append(dataTable_0.Columns[i].ColumnName);
		}
		stringWriter.WriteLine(stringBuilder.ToString());
		for (int j = 0; j < dataTable_0.Rows.Count; j++)
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int k = 0; k < dataTable_0.Columns.Count; k++)
			{
				if (k > 0)
				{
					stringBuilder2.Append("\t");
				}
				stringBuilder2.Append(dataTable_0.Rows[j][k].ToString());
			}
			stringWriter.WriteLine(stringBuilder2.ToString());
		}
		using (FileStream fileStream = new FileStream(string_1, FileMode.Create, FileAccess.Write))
		{
			using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("gb2312")))
			{
				textWriter.Write(stringWriter.ToString());
			}
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00006E94 File Offset: 0x00005094
	public static DataTable smethod_2(string string_1, string string_2)
	{
		StreamReader streamReader = new StreamReader(string_1, Encoding.GetEncoding(string_2));
		string text = streamReader.ReadToEnd();
		string[] array = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
		//array = array.Where(new Func<string, bool>(Class1.<>c.<>9.method_0)).ToArray<string>();
		DataTable dataTable = new DataTable();
		string[] array2 = array[0].Split(new string[] { "\t" }, StringSplitOptions.None);
		foreach (string text2 in array2)
		{
			dataTable.Columns.Add(new DataColumn(text2, typeof(string)));
		}
		for (int j = 1; j < array.Length; j++)
		{
			string[] array4 = array[j].Split(new string[] { "\t" }, StringSplitOptions.None);
			DataRow dataRow = dataTable.NewRow();
			for (int k = 0; k < array4.Length; k++)
			{
				string text3 = array2[k].ToString();
				dataRow[text3] = array4[k].ToString();
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00006FD8 File Offset: 0x000051D8
	public static DataTable smethod_3(string string_1)
	{
		StreamReader streamReader = new StreamReader(string_1, Encoding.GetEncoding("utf-8"));
		string text = streamReader.ReadToEnd();
		string[] array = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
		//array = array.Where(new Func<string, bool>(Class1.<>c.<>9.method_1)).ToArray<string>();
		DataTable dataTable = new DataTable();
		string[] array2 = array[0].Split(new string[] { "\t" }, StringSplitOptions.None);
		foreach (string text2 in array2)
		{
			dataTable.Columns.Add(new DataColumn(text2, typeof(string)));
		}
		for (int j = 1; j < array.Length; j++)
		{
			string[] array4 = array[j].Split(new string[] { "\t" }, StringSplitOptions.None);
			DataRow dataRow = dataTable.NewRow();
			for (int k = 0; k < array4.Length; k++)
			{
				string text3 = array2[k].ToString();
				dataRow[text3] = array4[k].ToString();
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00007120 File Offset: 0x00005320
	public static string smethod_4(string string_1)
	{
		string text;
		if (string_1.Length < 1)
		{
			text = "";
		}
		else
		{
			text = string_1.Substring(0, string_1.LastIndexOf(","));
		}
		return text;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0000715C File Offset: 0x0000535C
	public static string smethod_5(string string_1)
	{
		string text;
		if (string_1.Length < 1)
		{
			text = "";
		}
		else
		{
			string text2 = string_1.Remove(0, string_1.Length - 1);
			if (text2 == "|")
			{
				text = string_1.Substring(0, string_1.LastIndexOf("|"));
			}
			else
			{
				text = string_1;
			}
		}
		return text;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x000071B8 File Offset: 0x000053B8
	public static byte[] smethod_6(string string_1)
	{
		byte[] array2;
		try
		{
			using (FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read))
			{
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				array2 = array;
			}
		}
		catch
		{
			array2 = null;
		}
		return array2;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00007218 File Offset: 0x00005418
	public static bool smethod_7(byte[] byte_0, string string_1)
	{
		bool flag = false;
		try
		{
			using (FileStream fileStream = new FileStream(string_1, FileMode.OpenOrCreate, FileAccess.Write))
			{
				fileStream.Write(byte_0, 0, byte_0.Length);
				flag = true;
			}
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00007270 File Offset: 0x00005470
	public static string smethod_8(string string_1)
	{
		string text;
		if (string_1 == "Achievement")
		{
			text = "AchievementV2Table";
		}
		else if (string_1 == "AchivementList")
		{
			text = "AchivementTable";
		}
		else if (string_1 == "AuctionList")
		{
			text = "AuctionTypeList";
		}
		else if (string_1 == "BackFlowShop")
		{
			text = "BackflowShop";
		}
		else if (string_1 == "BQ")
		{
			text = "FpStrengthenTable";
		}
		else if (string_1 == "BuffList")
		{
			text = "BuffTable";
		}
		else if (string_1 == "BuffListPVP")
		{
			text = "BuffTable";
		}
		else if (string_1 == "ChapterList")
		{
			text = "XChapter";
		}
		else if (string_1 == "CharacterAttributes")
		{
			text = "CharacterAttributesList";
		}
		else if (string_1 == "CombatParamList")
		{
			text = "CombatParamTable";
		}
		else if (string_1 == "DNExpedition")
		{
			text = "ExpeditionTable";
		}
		else if (string_1 == "DragonNestList")
		{
			text = "DragonNestTable";
		}
		else if (string_1 == "DragonNestList")
		{
			text = "EmblemBasic";
		}
		else if (string_1 == "FashionFx")
		{
			text = "FashionEnhanceFx";
		}
		else if (string_1 == "festivalscenelist")
		{
			text = "FestScene";
		}
		else if (string_1 == "FlowerNotice")
		{
			text = "FlowerSendNoticeTable";
		}
		else if (string_1 == "FriendSystemConfig")
		{
			text = "FriendSysConfigTable";
		}
		else if (string_1 == "GardenFishing")
		{
			text = "GardenFishConfig";
		}
		else if (string_1 == "GetMilitaryExploitConfig")
		{
			text = "MilitaryRankByExploit";
		}
		else if (string_1 == "GlobalConfig")
		{
			text = "GlobalTable";
		}
		else if (string_1 == "GuildBoss")
		{
			text = "GuildBossConfigTable";
		}
		else if (string_1 == "GuildIntroduce")
		{
			text = "Guildintroduce";
		}
		else if (string_1 == "GuildIntroduce")
		{
			text = "Guildintroduce";
		}
		else if (string_1 == "Guildsalary")
		{
			text = "GuildSalaryTable";
		}
		else if (string_1 == "ItemCompose")
		{
			text = "ItemComposeTable";
		}
		else if (string_1 == "Jade")
		{
			text = "JadeTable";
		}
		else if (string_1 == "OperatingActivity")
		{
			text = "OperatingActivity";
		}
		else if (string_1 == "PhotographEffect")
		{
			text = "PhotographEffectCfg";
		}
		else if (string_1 == "PkPointReward")
		{
			text = "PkPointTable";
		}
		else if (string_1 == "PkRankReward")
		{
			text = "PkRankTable";
		}
		else if (string_1 == "PreloadFxList")
		{
			text = "PreloadAnimationList";
		}
		else if (string_1 == "ProfessionConversionParameter")
		{
			text = "ProfessionConvertTable";
		}
		else if (string_1 == "ProfessionSkill")
		{
			text = "ProfSkillTable";
		}
		else if (string_1 == "RandomEntityList")
		{
			text = "RandomBossTable";
		}
		else if (string_1 == "RandomSceneList")
		{
			text = "RandomSceneTable";
		}
		else if (string_1 == "randomtask")
		{
			text = "RandomTaskTable";
		}
		else if (string_1 == "SceneList")
		{
			text = "SceneTable";
		}
		else if (string_1 == "SystemList")
		{
			text = "OpenSystemTable";
		}
		else if (string_1 == "TaskListNew")
		{
			text = "TaskTableNew";
		}
		else if (string_1 == "TeamTower")
		{
			text = "TeamTowerRewardTable";
		}
		else if (string_1 == "territorybattle")
		{
			text = "TerritoryBattle";
		}
		else if (string_1 == "Vip")
		{
			text = "VIPTable";
		}
		else if (string_1 == "XNpcList")
		{
			text = "XNpcInfo";
		}
		else if (string_1 == "AttributeList")
		{
			text = "PowerPointCoeffTable";
		}
		else if (string_1 == "Carnival")
		{
			text = "SuperActivity";
		}
		else
		{
			text = string_1;
		}
		return text;
	}

	// Token: 0x040000A4 RID: 164
	[NonSerialized]
	private string string_0 = "";
}
