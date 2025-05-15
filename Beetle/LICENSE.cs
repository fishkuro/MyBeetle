using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Beetle
{
	public class LICENSE
	{
		private static LICENSE license_0 = null;

		private static RSACryptoServiceProvider rsacryptoServiceProvider_0 = new RSACryptoServiceProvider(2048);

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private DateTime dateTime_0;

		[CompilerGenerated]
		private int int_0;

		public string Company
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string EMail
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public DateTime ValidDate
		{
			[CompilerGenerated]
			get
			{
				return dateTime_0;
			}
			[CompilerGenerated]
			set
			{
				dateTime_0 = value;
			}
		}

		public int MaxConnections
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Version:{0}\r\n", GetType().Assembly.GetName().Version);
			stringBuilder.AppendFormat("Company:{0}\r\n", Company);
			stringBuilder.AppendFormat("EMail:{0}\r\n", EMail);
			stringBuilder.AppendFormat("ValidDate:{0}\r\n", ValidDate);
			stringBuilder.AppendFormat("MaxConnections:{0}\r\n", MaxConnections);
			return stringBuilder.ToString();
		}

		public static LICENSE GetLICENSE()
		{
			lock (typeof(LICENSE))
			{
				if (license_0 == null)
				{
					license_0 = new LICENSE();
					try
					{
						rsacryptoServiceProvider_0.FromXmlString("<RSAKeyValue><Modulus>pkeTDrmB8cQUC7zd/CStdr02vmgn1TscKGVDLuDTeJ1I3zkzQmlYAy/FvROUTIfvJnf/sNrEsl86o50XaTUXQy6kPm5Kmaoi3A24EajELKhq7+lOjjF7jC7WA5DwIOjTb4wZ/3rzaouVbdyUYEM6XRTFUVxeIKgplzpVVYPjv4uD3P5y9XVKtT3ltcpNPVk+AJjKwasZRQ4a/r3It9Fl4isKi122VWWpZd3tCa+Q8usX1VvDZYuREeql5iek21ca8aaLT1zxZq/j/6V+vyUxQH3GIfaAI8NipG09nu9EU6CHqjlQuCWBfH865CbrjMiRmM5KByAsC5JazDNSMrRo5Q==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
						string path = TcpUtils.smethod_0() + "license.sn";
						using (StreamReader streamReader = new StreamReader(path))
						{
							string[] array = streamReader.ReadToEnd().Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
							if (smethod_1(array[0], array[1]))
							{
								string[] array2 = Encoding.UTF8.GetString(Convert.FromBase64String(array[0])).Split(';');
								license_0.Company = array2[0];
								license_0.EMail = array2[1];
								license_0.MaxConnections = int.Parse(array2[2]);
								license_0.ValidDate = new DateTime(long.Parse(array2[3]));
							}
						}
					}
					catch (Exception ex)
					{
						string message = ex.Message;
					}
				}
			}
			return license_0;
		}

		internal static string smethod_0(string string_2)
		{
			return Convert.ToBase64String(smethod_4(Encoding.UTF8.GetBytes(string_2)));
		}

		internal static bool smethod_1(string string_2, string string_3)
		{
			return smethod_2(Encoding.UTF8.GetBytes(string_2), Convert.FromBase64String(string_3));
		}

		internal static bool smethod_2(byte[] byte_0, byte[] byte_1)
		{
			return rsacryptoServiceProvider_0.VerifyData(byte_0, "MD5", byte_1);
		}

		internal static string smethod_3(string string_2)
		{
			return Encoding.UTF8.GetString(smethod_5(Convert.FromBase64String(string_2)));
		}

		internal static byte[] smethod_4(byte[] byte_0)
		{
			return rsacryptoServiceProvider_0.Encrypt(byte_0, false);
		}

		internal static byte[] smethod_5(byte[] byte_0)
		{
			return rsacryptoServiceProvider_0.Decrypt(byte_0, false);
		}
	}
}
