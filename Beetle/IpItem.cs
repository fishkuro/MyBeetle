using System.Net;

namespace Beetle
{
	public class IpItem
	{
		private bool bool_0 = true;

		private bool bool_1;

		private byte[] byte_0;

		private byte[] byte_1;

		private string string_0;

		public bool Permit
		{
			get
			{
				return bool_0;
			}
		}

		public string AddressValue
		{
			get
			{
				return string_0;
			}
		}

		public IpItem(IPAddress ipaddress_0)
		{
			byte_0 = ipaddress_0.GetAddressBytes();
		}

		public IpItem(IPAddress startip, IPAddress endip)
		{
			byte_0 = startip.GetAddressBytes();
			byte_1 = endip.GetAddressBytes();
			bool_1 = true;
		}

		public IpItem(IPAddress startip, IPAddress endip, bool permit)
		{
			byte_0 = startip.GetAddressBytes();
			byte_1 = endip.GetAddressBytes();
			bool_1 = true;
			bool_0 = true;
		}

		public bool Verification(IPAddress ipaddress_0)
		{
			bool flag = false;
			byte[] addressBytes = ipaddress_0.GetAddressBytes();
			flag = ((!bool_1) ? ((addressBytes[0] == byte_0[0]) & (addressBytes[1] == byte_0[1]) & (addressBytes[2] == byte_0[2]) & (addressBytes[3] == byte_0[3])) : (addressBytes[0] >= byte_0[0] && ((addressBytes[0] <= byte_1[0]) & (addressBytes[1] >= byte_0[1])) && ((addressBytes[0] <= byte_1[1]) & (addressBytes[2] >= byte_0[2])) && ((addressBytes[0] <= byte_1[2]) & (addressBytes[3] >= byte_0[3])) && addressBytes[0] <= byte_1[3]));
			if (bool_0)
			{
				return flag;
			}
			return !flag;
		}

		public static IpItem From(string ipaddress, bool permit)
		{
			IpItem ipItem = null;
			IPAddress address = null;
			IPAddress address2 = null;
			string[] array = ipaddress.Split('-');
			if (array.Length == 2)
			{
				if (IPAddress.TryParse(array[0], out address) && IPAddress.TryParse(array[1], out address2))
				{
					ipItem = new IpItem(address, address2, permit);
					ipItem.string_0 = ipaddress;
				}
			}
			else if (IPAddress.TryParse(array[0], out address))
			{
				ipItem = new IpItem(address);
				ipItem.bool_0 = permit;
				ipItem.string_0 = ipaddress;
			}
			return ipItem;
		}
	}
}
