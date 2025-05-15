using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace Beetle
{
	public class ServerNode : ConfigurationElement
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "host";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_1 = "port";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_2 = "name";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_3 = "detectTime";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_4 = "maxConnections";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_5 = "group";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_6 = "timeOut";

		[ConfigurationProperty("host", IsRequired = true, IsKey = false, IsDefaultCollection = false)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The Host.")]
		public virtual string Host
		{
			get
			{
				return (string)base["host"];
			}
			set
			{
				base["host"] = value;
			}
		}

		[Description("The Port.")]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[ConfigurationProperty("port", IsRequired = true, IsKey = false, IsDefaultCollection = false)]
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

		[Description("The Name.")]
		[ConfigurationProperty("name", IsRequired = true, IsKey = true, IsDefaultCollection = false)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
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

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The DetectTime.")]
		[ConfigurationProperty("detectTime", IsRequired = false, IsKey = false, IsDefaultCollection = false, DefaultValue = 10)]
		public virtual int DetectTime
		{
			get
			{
				return (int)base["detectTime"];
			}
			set
			{
				base["detectTime"] = value;
			}
		}

		[ConfigurationProperty("maxConnections", IsRequired = false, IsKey = false, IsDefaultCollection = false, DefaultValue = 20)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The MaxConnections.")]
		public virtual int MaxConnections
		{
			get
			{
				return (int)base["maxConnections"];
			}
			set
			{
				base["maxConnections"] = value;
			}
		}

		[ConfigurationProperty("group", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The Group.")]
		public virtual string Group
		{
			get
			{
				return (string)base["group"];
			}
			set
			{
				base["group"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The TimeOut.")]
		[ConfigurationProperty("timeOut", IsRequired = false, IsKey = false, IsDefaultCollection = false, DefaultValue = 30)]
		public virtual int TimeOut
		{
			get
			{
				return (int)base["timeOut"];
			}
			set
			{
				base["timeOut"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
