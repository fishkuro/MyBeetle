using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace Beetle
{
	public class ServerFactorySection : ConfigurationElement
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "beetleSection";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_1 = "servers";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The BeetleSection.")]
		[ConfigurationProperty("beetleSection", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public virtual string BeetleSection
		{
			get
			{
				return (string)base["beetleSection"];
			}
			set
			{
				base["beetleSection"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[Description("The Servers.")]
		[ConfigurationProperty("servers", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public virtual ServerCollection Servers
		{
			get
			{
				return (ServerCollection)base["servers"];
			}
			set
			{
				base["servers"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
