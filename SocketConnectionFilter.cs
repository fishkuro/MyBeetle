using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Beetle.Controller;

internal class SocketConnectionFilter
{
	private static string string_0 = "abcdefghijklmnopqrstuvwxyz";

	private static Dictionary<string, Type> dictionary_0 = new Dictionary<string, Type>();

	private static Dictionary<string, XmlSerializer> dictionary_1 = new Dictionary<string, XmlSerializer>();

	private static object object_0 = new object();

	public static int int_0 = 524288;

	[ThreadStatic]
	private static char[] char_0;

	[CompilerGenerated]
	private static AsyncCallback asyncCallback_0;

	public static long smethod_0(DirectoryInfo directoryInfo_0)
	{
		long num = 0L;
		FileInfo[] files = directoryInfo_0.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			num += fileInfo.Length;
		}
		DirectoryInfo[] directories = directoryInfo_0.GetDirectories();
		DirectoryInfo[] array2 = directories;
		foreach (DirectoryInfo directoryInfo_ in array2)
		{
			num += smethod_0(directoryInfo_);
		}
		return num;
	}

	public static string smethod_1(int int_1)
	{
		Random random = new Random(Environment.TickCount);
		string text = "";
		for (int i = 0; i < int_1; i++)
		{
			text += string_0.Substring(random.Next(25), 1);
		}
		return text;
	}

	public static bool smethod_2(Array array_0)
	{
		if (array_0 != null && array_0.Length != 0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_3(IList ilist_0)
	{
		if (ilist_0 != null && ilist_0.Count != 0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_4(IDictionary idictionary_0)
	{
		if (idictionary_0 != null && idictionary_0.Count != 0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_5(string string_1)
	{
		return string.IsNullOrEmpty(string_1);
	}

	public static string smethod_6(Assembly assembly_0)
	{
		return Path.GetDirectoryName(assembly_0.Location) + "\\";
	}

	public static string smethod_7(string string_1)
	{
		if (string_1.Substring(string_1.Length - 1, 1) != "\\")
		{
			return string_1 + "\\";
		}
		return string_1;
	}

	public static bool smethod_8(DateTime dateTime_0)
	{
		if (dateTime_0 == DateTime.MinValue)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_9(string string_1)
	{
		int result;
		return int.TryParse(string_1, out result);
	}

	public static bool smethod_10(object object_1)
	{
		return smethod_9(object_1.ToString());
	}

	public static bool smethod_11(string string_1)
	{
		return Regex.IsMatch(string_1, "^(\\d+|(\\d+\\.\\d+)+)$", RegexOptions.IgnoreCase);
	}

	public static bool smethod_12(object object_1)
	{
		return smethod_11(object_1.ToString());
	}

	public static bool smethod_13(string string_1)
	{
		DateTime result;
		return DateTime.TryParse(string_1, out result);
	}

	public static bool smethod_14(object object_1)
	{
		return smethod_13(object_1.ToString());
	}

	public static Type smethod_15(string string_1)
	{
		string[] array = string_1.Split(',');
		Assembly assembly = Assembly.Load(array[1]);
		return assembly.GetType(array[0], true);
	}

	public static Type smethod_16(string string_1)
	{
		if (!dictionary_0.ContainsKey(string_1))
		{
			lock (dictionary_0)
			{
				if (!dictionary_0.ContainsKey(string_1))
				{
					Type type = Type.GetType(string_1);
					dictionary_0.Add(string_1, type);
				}
			}
		}
		return dictionary_0[string_1];
	}

	public static byte[] smethod_17(object object_1)
	{
		if (object_1 == null)
		{
			return null;
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, object_1);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
			memoryStream.Close();
			return array;
		}
	}

	public static string smethod_18(object object_1)
	{
		byte[] inArray = smethod_17(object_1);
		return Convert.ToBase64String(inArray);
	}

	public static object smethod_19(byte[] byte_0)
	{
		return smethod_21(byte_0, byte_0.Length);
	}

	public static object smethod_20(byte[] byte_0, int int_1, int int_2)
	{
		object result = null;
		if (byte_0 == null)
		{
			return result;
		}
		using (MemoryStream memoryStream = new MemoryStream(byte_0, int_1, int_2))
		{
			memoryStream.Position = 0L;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			result = binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			return result;
		}
	}

	public static object smethod_21(byte[] byte_0, int int_1)
	{
		return smethod_20(byte_0, 0, int_1);
	}

	public static object smethod_22(string string_1)
	{
		byte[] byte_ = Convert.FromBase64String(string_1);
		return smethod_19(byte_);
	}

	public static string smethod_23(DateTime dateTime_0)
	{
		string text = "〇一二三四五六七八九";
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = new string[3]
		{
			dateTime_0.Year.ToString(),
			dateTime_0.Month.ToString("00"),
			dateTime_0.Day.ToString("00")
		};
		for (int i = 0; i < array[0].Length; i++)
		{
			int startIndex = int.Parse(array[0].Substring(i, 1));
			stringBuilder.Append(text.Substring(startIndex, 1));
		}
		stringBuilder.Append("年");
		for (int j = 0; j < array[1].Length; j++)
		{
			int startIndex = int.Parse(array[1].Substring(j, 1));
			if (j == 0)
			{
				if (startIndex > 0)
				{
					stringBuilder.Append("十");
				}
			}
			else if (startIndex > 0)
			{
				stringBuilder.Append(text.Substring(startIndex, 1));
			}
		}
		stringBuilder.Append("月");
		for (int k = 0; k < array[2].Length; k++)
		{
			int startIndex = int.Parse(array[2].Substring(k, 1));
			if (k == 0)
			{
				if (startIndex > 0)
				{
					if (startIndex > 1)
					{
						stringBuilder.Append(text.Substring(startIndex, 1));
					}
					stringBuilder.Append("十");
				}
			}
			else if (startIndex > 0)
			{
				stringBuilder.Append(text.Substring(startIndex, 1));
			}
		}
		stringBuilder.Append("日");
		return stringBuilder.ToString();
	}

	public static T[] ListToArray<T>(IList list)
	{
		T[] array = new T[list.Count];
		list.CopyTo(array, 0);
		return array;
	}

	public static int smethod_24(string string_1)
	{
		int num = 0;
		foreach (char char_ in string_1)
		{
			if (smethod_29(char_))
			{
				num++;
			}
		}
		if (num % 2 != 0)
		{
			num--;
		}
		return num / 2;
	}

	public static byte[] smethod_25(string string_1, out int int_1)
	{
		int_1 = 0;
		string text = "";
		foreach (char c in string_1)
		{
			if (smethod_29(c))
			{
				text += c;
			}
			else
			{
				int_1++;
			}
		}
		if (text.Length % 2 != 0)
		{
			int_1++;
			text = text.Substring(0, text.Length - 1);
		}
		int num = text.Length / 2;
		byte[] array = new byte[num];
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			string string_2 = new string(new char[2]
			{
				text[num2],
				text[num2 + 1]
			});
			array[j] = smethod_30(string_2);
			num2 += 2;
		}
		return array;
	}

	public static string smethod_26(Encoding encoding_0, byte[] byte_0, int int_1, int int_2)
	{
		return encoding_0.GetString(byte_0, int_1, int_2);
	}

	public static string smethod_27(byte[] byte_0)
	{
		string text = "";
		for (int i = 0; i < byte_0.Length; i++)
		{
			text += byte_0[i].ToString("X2");
		}
		return text;
	}

	public static bool smethod_28(string string_1)
	{
		bool result = true;
		foreach (char char_ in string_1)
		{
			if (!smethod_29(char_))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public static bool smethod_29(char char_1)
	{
		int num = Convert.ToInt32('A');
		int num2 = Convert.ToInt32('0');
		char_1 = char.ToUpper(char_1);
		int num3 = Convert.ToInt32(char_1);
		if (num3 >= num && num3 < num + 6)
		{
			return true;
		}
		if (num3 >= num2 && num3 < num2 + 10)
		{
			return true;
		}
		return false;
	}

	private static byte smethod_30(string string_1)
	{
		if (string_1.Length > 2 || string_1.Length <= 0)
		{
			throw new ArgumentException("hex must be 1 or 2 characters in length");
		}
		return byte.Parse(string_1, NumberStyles.HexNumber);
	}

	public static byte[] smethod_31(byte[] byte_0)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		return mD5CryptoServiceProvider.ComputeHash(byte_0);
	}

	public static string smethod_32(string string_1)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(string_1);
		bytes = smethod_31(bytes);
		return smethod_27(bytes);
	}

	public static T[] GetFieldAttributes<T>(FieldInfo field, bool inhert) where T : Attribute
	{
		return (T[])field.GetCustomAttributes(typeof(T), inhert);
	}

	public static T[] GetTypeAttributes<T>(Type type, bool inhert) where T : Attribute
	{
		return (T[])type.GetCustomAttributes(typeof(T), inhert);
	}

	public static T[] GetPropertyAttributes<T>(PropertyInfo propertyInfo_0, bool inhert) where T : Attribute
	{
		return (T[])propertyInfo_0.GetCustomAttributes(typeof(T), inhert);
	}

	public static T[] GetMethodAttributes<T>(MethodInfo methodInfo_0, bool inhert) where T : Attribute
	{
		return (T[])methodInfo_0.GetCustomAttributes(typeof(T), inhert);
	}

	public static T[] GetParemeterAttributes<T>(ParameterInfo parameterInfo_0, bool inhert) where T : Attribute
	{
		return (T[])parameterInfo_0.GetCustomAttributes(typeof(T), inhert);
	}

	public static void smethod_33(AsyncDelegate asyncDelegate_0)
	{
		asyncDelegate_0.BeginInvoke(delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	public static void Action<T>(T gparam_0, AsyncDelegate<T> handler)
	{
		handler.BeginInvoke(gparam_0, delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate<T>>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	public static void Action<T, T1>(T gparam_0, T1 gparam_1, AsyncDelegate<T, T1> handler)
	{
		handler.BeginInvoke(gparam_0, gparam_1, delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate<T, T1>>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	public static void Action<T, T1, T2>(T gparam_0, T1 gparam_1, T2 gparam_2, AsyncDelegate<T, T1, T2> handler)
	{
		handler.BeginInvoke(gparam_0, gparam_1, gparam_2, delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate<T, T1, T2>>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	public static void Action<T, T1, T2, T3>(T gparam_0, T1 gparam_1, T2 gparam_2, T3 gparam_3, AsyncDelegate<T, T1, T2, T3> handler)
	{
		handler.BeginInvoke(gparam_0, gparam_1, gparam_2, gparam_3, delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate<T, T1, T2, T3>>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	public static void Action<T, T1, T2, T3, T4>(T gparam_0, T1 gparam_1, T2 gparam_2, T3 gparam_3, T4 gparam_4, AsyncDelegate<T, T1, T2, T3, T4> handler)
	{
		handler.BeginInvoke(gparam_0, gparam_1, gparam_2, gparam_3, gparam_4, delegate(IAsyncResult iasyncResult_0)
		{
			GetEndHandler<AsyncDelegate<T, T1, T2, T3, T4>>(iasyncResult_0).EndInvoke(iasyncResult_0);
		}, null);
	}

	private static T GetEndHandler<T>(IAsyncResult iasyncResult_0)
	{
		return (T)((AsyncResult)iasyncResult_0).AsyncDelegate;
	}

	public static XmlSerializer smethod_34(Type type_0, XmlRootAttribute xmlRootAttribute_0)
	{
		string key = type_0.FullName + ((xmlRootAttribute_0 != null) ? xmlRootAttribute_0.ElementName : "");
		if (!dictionary_1.ContainsKey(key))
		{
			lock (object_0)
			{
				if (!dictionary_1.ContainsKey(key))
				{
					if (xmlRootAttribute_0 != null)
					{
						dictionary_1.Add(key, new XmlSerializer(type_0, xmlRootAttribute_0));
					}
					else
					{
						dictionary_1.Add(key, new XmlSerializer(type_0));
					}
				}
			}
		}
		return dictionary_1[key];
	}

	public void method_0(string string_1, string string_2, string string_3, string string_4, bool bool_0, IEnumerable<string> ienumerable_0, IEnumerable<string> ienumerable_1)
	{
		MailMessage mailMessage = new MailMessage();
		mailMessage.From = new MailAddress(string_1);
		foreach (string item in ienumerable_0)
		{
			mailMessage.To.Add(item);
		}
		if (ienumerable_1 != null)
		{
			foreach (string item2 in ienumerable_1)
			{
				Attachment attachment = new Attachment(item2, "application/octet-stream");
				ContentDisposition contentDisposition = attachment.ContentDisposition;
				contentDisposition.CreationDate = File.GetCreationTime(item2);
				contentDisposition.ModificationDate = File.GetLastWriteTime(item2);
				contentDisposition.ReadDate = File.GetLastAccessTime(item2);
				mailMessage.Attachments.Add(attachment);
			}
		}
		mailMessage.Subject = string_3;
		mailMessage.Body = string_4;
		mailMessage.BodyEncoding = Encoding.UTF8;
		mailMessage.IsBodyHtml = bool_0;
		mailMessage.Priority = MailPriority.Normal;
		SmtpClient smtpClient = new SmtpClient();
		smtpClient.Credentials = new NetworkCredential(mailMessage.From.Address, string_2);
		smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		smtpClient.Host = "smtp." + mailMessage.From.Host;
		smtpClient.Send(mailMessage);
	}

	public static bool smethod_35(string string_1, out string string_2)
	{
		string_2 = ConfigurationManager.AppSettings[string_1];
		return !string.IsNullOrEmpty(string_2);
	}

	public static string smethod_36(string string_1)
	{
		return ConfigurationManager.AppSettings[string_1];
	}

	public static T AppSettingValue<T>(string name)
	{
		object obj = smethod_36(name);
		if (obj == null)
		{
			return default(T);
		}
		return (T)Convert.ChangeType(obj, typeof(T));
	}

	public static void Is<T>(object object_1, AsyncDelegate<T> handler)
	{
		if (object_1 is T)
		{
			handler((T)object_1);
		}
	}

	public static IEnumerable<T> Find<T>(IEnumerable source, EventFindHandler<T> handler)
	{
		List<T> list = new List<T>();
		if (source != null)
		{
			foreach (object item in source)
			{
				if (handler((T)item))
				{
					list.Add((T)item);
				}
			}
			return list;
		}
		return list;
	}

	[SpecialName]
	public static string smethod_37()
	{
		return Path.GetDirectoryName(typeof(SocketConnectionFilter).Assembly.Location) + "\\";
	}

	public static char[] smethod_38()
	{
		if (char_0 == null)
		{
			char_0 = new char[int_0];
		}
		return char_0;
	}

	public static string smethod_39(string string_1, string string_2, string string_3)
	{
		char[] array = smethod_38();
		int num = 0;
		int num2 = 0;
		int length = string_1.Length;
		int length2 = string_2.Length;
		int length3 = string_3.Length;
		int num3 = 0;
		int num4 = 0;
		bool flag = false;
		while (num3 < string_1.Length)
		{
			flag = true;
			for (int i = 0; i < length2; i++)
			{
				if (string_1[num3 + i] != string_2[i])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				num4 = num3 - num2;
				string_1.CopyTo(num2, array, num, num4);
				num += num4;
				num3 += length2;
				num2 = num3;
				string_3.CopyTo(0, array, num, length3);
				num += length3;
			}
			else
			{
				num3++;
			}
		}
		if (num2 < length)
		{
			num4 = num3 - num2;
			string_1.CopyTo(num2, array, num, num4);
			num += num4;
		}
		return new string(array, 0, num);
	}

	[CompilerGenerated]
	private static void smethod_40(IAsyncResult iasyncResult_0)
	{
		GetEndHandler<AsyncDelegate>(iasyncResult_0).EndInvoke(iasyncResult_0);
	}
}
