using System.CodeDom.Compiler;
using System.Configuration;

namespace Beetle
{
	[ConfigurationCollection(typeof(ServerNode), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMapAlternate, AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
	public class Nodes : ConfigurationElementCollection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "item";

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
				return "item";
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerNode this[int index]
		{
			get
			{
				return (ServerNode)BaseGet(index);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerNode this[object name]
		{
			get
			{
				return (ServerNode)BaseGet(name);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override bool IsElementName(string elementName)
		{
			return elementName == "item";
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ServerNode)element).Name;
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		protected override ConfigurationElement CreateNewElement()
		{
			return new ServerNode();
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public void Add(ServerNode item)
		{
			base.BaseAdd(item);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public void Remove(ServerNode item)
		{
			BaseRemove(GetElementKey(item));
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerNode GetItemAt(int index)
		{
			return (ServerNode)BaseGet(index);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public ServerNode GetItemByKey(string name)
		{
			return (ServerNode)BaseGet(name);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
