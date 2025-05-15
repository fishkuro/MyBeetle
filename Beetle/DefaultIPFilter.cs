using System.Collections.Generic;
using System.Net;

namespace Beetle
{
	public class DefaultIPFilter : IIPFiler
	{
		private List<IpItem> list_0 = new List<IpItem>();

		public void Add(IpItem item)
		{
			lock (list_0)
			{
				list_0.Add(item);
			}
		}

		public void Remove(string ipvalue, bool permit)
		{
			lock (list_0)
			{
				IList<IpItem> list = new List<IpItem>();
				foreach (IpItem item in list_0)
				{
					if (item.AddressValue == ipvalue && item.Permit == permit)
					{
						list.Add(item);
					}
				}
				foreach (IpItem item2 in list)
				{
					list_0.Remove(item2);
				}
			}
		}

		public void Add(string ipvalue, bool permit)
		{
			IpItem ipItem = IpItem.From(ipvalue, permit);
			if (ipItem != null)
			{
				Add(ipItem);
			}
		}

		public IpItem[] GetItems()
		{
			lock (list_0)
			{
				IpItem[] array = new IpItem[list_0.Count];
				list_0.CopyTo(array, 0);
				return array;
			}
		}

		public bool Execute(IPEndPoint point)
		{
			bool result = false;
			IpItem[] items = GetItems();
			if (items.Length == 0)
			{
				return true;
			}
			IpItem[] items2 = GetItems();
			foreach (IpItem ipItem in items2)
			{
				if (!(result = ipItem.Verification(point.Address)))
				{
					break;
				}
			}
			return result;
		}
	}
}
