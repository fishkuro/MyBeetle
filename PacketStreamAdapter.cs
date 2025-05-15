using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

internal class PacketStreamAdapter
{
	public class MessageDispatcher
	{
		private byte[] byte_0;

		private byte[] byte_1;

		[SpecialName]
		public byte[] method_0()
		{
			return byte_0;
		}

		[SpecialName]
		public void method_1(byte[] byte_2)
		{
			byte_0 = byte_2;
		}

		[SpecialName]
		public byte[] method_2()
		{
			return byte_1;
		}

		[SpecialName]
		public void method_3(byte[] byte_2)
		{
			byte_1 = byte_2;
		}
	}

	private DESCryptoServiceProvider descryptoServiceProvider_0 = new DESCryptoServiceProvider();

	private RemoteAddressHelper class18_0;

	private RemoteAddressHelper class18_1;

	[SpecialName]
	public MessageDispatcher method_0()
	{
		MessageDispatcher @class = new MessageDispatcher();
		if (method_4() != null)
		{
			@class.method_1(method_4().method_13(descryptoServiceProvider_0.Key));
			@class.method_3(method_4().method_13(descryptoServiceProvider_0.IV));
		}
		else
		{
			@class.method_1(descryptoServiceProvider_0.Key);
			@class.method_3(descryptoServiceProvider_0.IV);
		}
		return @class;
	}

	[SpecialName]
	public void method_1(MessageDispatcher class20_0)
	{
		if (method_2() != null)
		{
			descryptoServiceProvider_0.Key = method_2().method_14(class20_0.method_0());
			descryptoServiceProvider_0.IV = method_2().method_14(class20_0.method_2());
		}
		else
		{
			descryptoServiceProvider_0.Key = class20_0.method_0();
			descryptoServiceProvider_0.IV = class20_0.method_2();
		}
	}

	[SpecialName]
	public RemoteAddressHelper method_2()
	{
		return class18_0;
	}

	[SpecialName]
	public void method_3(RemoteAddressHelper class18_2)
	{
		class18_0 = class18_2;
	}

	[SpecialName]
	public RemoteAddressHelper method_4()
	{
		return class18_1;
	}

	[SpecialName]
	public void method_5(RemoteAddressHelper class18_2)
	{
		class18_1 = class18_2;
	}

	public string method_6(string string_0)
	{
		return Convert.ToBase64String(method_7(Encoding.UTF8.GetBytes(string_0)));
	}

	public byte[] method_7(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider_0.CreateEncryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_0, 0, byte_0.Length);
		cryptoStream.Close();
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		return result;
	}

	public string method_8(string string_0)
	{
		return Encoding.UTF8.GetString(method_9(Convert.FromBase64String(string_0)));
	}

	public byte[] method_9(byte[] byte_0)
	{
		IList<byte> list = new List<byte>();
		MemoryStream memoryStream = new MemoryStream(byte_0);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider_0.CreateDecryptor(), CryptoStreamMode.Read);
		for (int num = cryptoStream.ReadByte(); num >= 0; num = cryptoStream.ReadByte())
		{
			list.Add((byte)num);
		}
		cryptoStream.Close();
		memoryStream.Close();
		byte[] array = new byte[list.Count];
		list.CopyTo(array, 0);
		return array;
	}
}
