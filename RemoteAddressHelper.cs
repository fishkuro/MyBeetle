using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

internal class RemoteAddressHelper
{
	private RSACryptoServiceProvider rsacryptoServiceProvider_0;

	public RemoteAddressHelper()
	{
		rsacryptoServiceProvider_0 = new RSACryptoServiceProvider(1024);
	}

	public RemoteAddressHelper(int int_0)
	{
		rsacryptoServiceProvider_0 = new RSACryptoServiceProvider(int_0);
	}

	[SpecialName]
	public string method_0()
	{
		return rsacryptoServiceProvider_0.ToXmlString(false);
	}

	[SpecialName]
	public void method_1(string string_0)
	{
		rsacryptoServiceProvider_0.FromXmlString(string_0);
	}

	public void method_2(bool bool_0, RemoteAddressHelper class18_0)
	{
		RSAParameters parameters = rsacryptoServiceProvider_0.ExportParameters(bool_0);
		class18_0.rsacryptoServiceProvider_0.ImportParameters(parameters);
	}

	public RSAParameters method_3(bool bool_0)
	{
		return rsacryptoServiceProvider_0.ExportParameters(bool_0);
	}

	public void method_4(RSAParameters rsaparameters_0)
	{
		rsacryptoServiceProvider_0.ImportParameters(rsaparameters_0);
	}

	[SpecialName]
	public string method_5()
	{
		return rsacryptoServiceProvider_0.ToXmlString(true);
	}

	[SpecialName]
	public void method_6(string string_0)
	{
		rsacryptoServiceProvider_0.FromXmlString(string_0);
	}

	public string method_7(string string_0)
	{
		return Convert.ToBase64String(method_8(Encoding.UTF8.GetBytes(string_0)));
	}

	public byte[] method_8(byte[] byte_0)
	{
		return rsacryptoServiceProvider_0.SignData(byte_0, "MD5");
	}

	public bool method_9(string string_0, string string_1)
	{
		return method_10(Encoding.UTF8.GetBytes(string_0), Convert.FromBase64String(string_1));
	}

	public bool method_10(byte[] byte_0, byte[] byte_1)
	{
		return rsacryptoServiceProvider_0.VerifyData(byte_0, "MD5", byte_1);
	}

	public string method_11(string string_0)
	{
		return Convert.ToBase64String(method_13(Encoding.UTF8.GetBytes(string_0)));
	}

	public string method_12(string string_0)
	{
		return Encoding.UTF8.GetString(method_14(Convert.FromBase64String(string_0)));
	}

	public byte[] method_13(byte[] byte_0)
	{
		return rsacryptoServiceProvider_0.Encrypt(byte_0, false);
	}

	public byte[] method_14(byte[] byte_0)
	{
		return rsacryptoServiceProvider_0.Decrypt(byte_0, false);
	}

	public string method_15(bool bool_0)
	{
		RSAParameters rSAParameters = rsacryptoServiceProvider_0.ExportParameters(bool_0);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append((rSAParameters.D != null) ? Convert.ToBase64String(rSAParameters.D) : "").Append("\n");
		stringBuilder.Append((rSAParameters.DP != null) ? Convert.ToBase64String(rSAParameters.DP) : "").Append("\n");
		stringBuilder.Append((rSAParameters.DQ != null) ? Convert.ToBase64String(rSAParameters.DQ) : "").Append("\n");
		stringBuilder.Append((rSAParameters.Exponent != null) ? Convert.ToBase64String(rSAParameters.Exponent) : "").Append("\n");
		stringBuilder.Append((rSAParameters.InverseQ != null) ? Convert.ToBase64String(rSAParameters.InverseQ) : "").Append("\n");
		stringBuilder.Append((rSAParameters.Modulus != null) ? Convert.ToBase64String(rSAParameters.Modulus) : "").Append("\n");
		stringBuilder.Append((rSAParameters.P != null) ? Convert.ToBase64String(rSAParameters.P) : "").Append("\n");
		stringBuilder.Append((rSAParameters.Q != null) ? Convert.ToBase64String(rSAParameters.Q) : "").Append("\n");
		return stringBuilder.ToString();
	}

	public void method_16(string string_0)
	{
		RSAParameters parameters = default(RSAParameters);
		string[] array = string_0.Split('\n');
		parameters.D = (string.IsNullOrEmpty(array[0]) ? null : Convert.FromBase64String(array[0]));
		parameters.DP = (string.IsNullOrEmpty(array[1]) ? null : Convert.FromBase64String(array[1]));
		parameters.DQ = (string.IsNullOrEmpty(array[2]) ? null : Convert.FromBase64String(array[2]));
		parameters.Exponent = (string.IsNullOrEmpty(array[3]) ? null : Convert.FromBase64String(array[3]));
		parameters.Modulus = (string.IsNullOrEmpty(array[4]) ? null : Convert.FromBase64String(array[4]));
		parameters.Modulus = (string.IsNullOrEmpty(array[5]) ? null : Convert.FromBase64String(array[5]));
		parameters.P = (string.IsNullOrEmpty(array[6]) ? null : Convert.FromBase64String(array[6]));
		parameters.Q = (string.IsNullOrEmpty(array[7]) ? null : Convert.FromBase64String(array[7]));
		rsacryptoServiceProvider_0.ImportParameters(parameters);
	}
}
