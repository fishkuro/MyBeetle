using System.CodeDom.Compiler;
using System.Configuration;

namespace Beetle
{
	[ConfigurationCollection(typeof(ServerSection), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMapAlternate, AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
	public class ServerCollection : ConfigurationElementCollection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "serverSection";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.AddRemoveClearMapAlternate;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override string ElementName
		{
			get
			{
				return "serverSection";
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerSection this[int index]
		{
			get
			{
				return (ServerSection)BaseGet(index);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerSection this[object name]
		{
			get
			{
				return (ServerSection)BaseGet(name);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override bool IsElementName(string elementName)
		{
			return elementName == "serverSection";
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ServerSection)element).Name;
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override ConfigurationElement CreateNewElement()
		{
			return new ServerSection();
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public void Add(ServerSection serverSection)
		{
			base.BaseAdd(serverSection);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public void Remove(ServerSection serverSection)
		{
			BaseRemove(GetElementKey(serverSection));
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerSection GetItemAt(int index)
		{
			return (ServerSection)BaseGet(index);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerSection GetItemByKey(string name)
		{
			return (ServerSection)BaseGet(name);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
