using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Beetle
{
	public class ByteArraySegment
	{
		private int int_0;

		private Stream stream_0;

		internal byte[] byte_0;

		public int Offset;

		public int Count;

		public byte[] Array
		{
			get
			{
				return byte_0;
			}
			private set
			{
				byte_0 = value;
			}
		}

		public int BufferLength
		{
			get
			{
				if (Array == null)
				{
					return 0;
				}
				return Array.Length;
			}
		}

		public ByteArraySegment()
		{
		}

		public byte GetData(int index)
		{
			return byte_0[Offset + index];
		}

		public ByteArraySegment(int length)
		{
			Array = new byte[length];
		}

		public void Encoding(string value, Encoding coding)
		{
			try
			{
				if (string.IsNullOrEmpty(value))
				{
					SetInfo(0, 0);
					return;
				}
				int bytes = coding.GetBytes(value, 0, value.Length, Array, 0);
				SetInfo(0, bytes);
			}
			catch (Exception innerexception)
			{
				throw NetTcpException.StringEncodingError(innerexception);
			}
		}

		public void Import(ByteArraySegment byteArraySegment_0)
		{
			Import(byteArraySegment_0.Array, byteArraySegment_0.Offset, byteArraySegment_0.Count);
		}

		public void Import(Stream steram)
		{
			int count = steram.Read(Array, 0, (int)steram.Length);
			SetInfo(0, count);
			SetPostion(0);
		}

		public void Import(byte[] data, int offet, int count)
		{
			Buffer.BlockCopy(data, offet, Array, 0, count);
			SetInfo(0, count);
			SetPostion(0);
		}

		public string Decoding(Encoding coding)
		{
			if (Count == 0)
			{
				return null;
			}
			return coding.GetString(byte_0, Offset, Count);
		}

		public string Decoding(Encoding coding, byte[] data, int poffset, int pcount)
		{
			return coding.GetString(data, poffset, pcount);
		}

		public string ToBase64String(byte[] data, int poffset, int pcount)
		{
			return Convert.ToBase64String(data, poffset, pcount);
		}

		public string ToBase64String()
		{
			return Convert.ToBase64String(byte_0, Offset, Count);
		}

		public void FromBase64String(string value)
		{
			try
			{
				byte[] array = Convert.FromBase64String(value);
				Import(array, 0, array.Length);
			}
			catch (Exception innerexception)
			{
				throw NetTcpException.StringEncodingError(innerexception);
			}
		}

		public Stream GetStream()
		{
			if (stream_0 == null)
			{
				stream_0 = new ArraySegmentStream(byte_0);
			}
			return stream_0;
		}

		public void SetInfo(int offset, int count)
		{
			Offset = offset;
			Count = count;
		}

		public void SetPostion(int value)
		{
			int_0 = value;
		}

		public void SetInfo(byte[] data, int offset, int count)
		{
			Array = data;
			Offset = offset;
			Count = count;
		}

		public void Clear()
		{
			Array = null;
		}

		public void EncryptTo(ByteArraySegment segment, DESCryptoServiceProvider mDESProvider)
		{
			MemoryStream memoryStream = new MemoryStream(segment.byte_0);
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, mDESProvider.CreateEncryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(byte_0, Offset, Count);
				cryptoStream.FlushFinalBlock();
				segment.SetInfo(0, (int)memoryStream.Position);
				cryptoStream.Close();
			}
		}

		public void DecryptTo(ByteArraySegment segment, DESCryptoServiceProvider mDESProvider)
		{
			MemoryStream stream = new MemoryStream(byte_0, Offset, Count);
			int num = 0;
			using (CryptoStream cryptoStream = new CryptoStream(stream, mDESProvider.CreateDecryptor(), CryptoStreamMode.Read))
			{
				for (int num2 = (byte)cryptoStream.ReadByte(); num2 >= 0; num2 = cryptoStream.ReadByte())
				{
					segment.byte_0[num] = (byte)num2;
					num++;
				}
				segment.SetInfo(0, num);
			}
		}
	}
}
