using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace Beetle
{
	public class ServerSection : ConfigurationElement
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "name";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_1 = "type";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_2 = "host";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_3 = "port";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_4 = "littleEndian";

		[ConfigurationProperty("name", IsRequired = true, IsKey = true, IsDefaultCollection = false)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The Name.")]
		public virtual string Name
		{
			get
			{
				return (string)base["name"];
			}
			set
			{
				base["name"] = value;
			}
		}

		[ConfigurationProperty("type", IsRequired = true, IsKey = false, IsDefaultCollection = false)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The Type.")]
		public virtual string Type
		{
			get
			{
				return (string)base["type"];
			}
			set
			{
				base["type"] = value;
			}
		}

		[Description("The Host.")]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[ConfigurationProperty("host", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public virtual float Host
		{
			get
			{
				return (float)base["host"];
			}
			set
			{
				base["host"] = value;
			}
		}

		[Description("The Port.")]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[ConfigurationProperty("port", IsRequired = false, IsKey = false, IsDefaultCollection = false, DefaultValue = 8088)]
		public virtual int Port
		{
			get
			{
				return (int)base["port"];
			}
			set
			{
				base["port"] = value;
			}
		}

		[ConfigurationProperty("littleEndian", IsRequired = false, IsKey = false, IsDefaultCollection = false, DefaultValue = true)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The LittleEndian.")]
		public virtual bool LittleEndian
		{
			get
			{
				return (bool)base["littleEndian"];
			}
			set
			{
				base["littleEndian"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
