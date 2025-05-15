namespace Beetle
{
	public class ReadObjectInfo
	{
		public int TypeOfInt = -1;

		public string TypeofString;

		public override string ToString()
		{
			if (TypeOfInt != -1)
			{
				return TypeOfInt.ToString();
			}
			return TypeofString;
		}
	}
}
