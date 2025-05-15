using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace Beetle
{
	public class PoolSection : ConfigurationSection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_0 = "poolSection";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_1 = "xmlns";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		internal const string string_2 = "servers";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		public static PoolSection Instance
		{
			get
			{
				return (PoolSection)ConfigurationManager.GetSection("poolSection");
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[ConfigurationProperty("xmlns", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public string Xmlns
		{
			get
			{
				return (string)base["xmlns"];
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
		[ConfigurationProperty("servers", IsRequired = true, IsKey = false, IsDefaultCollection = false)]
		[Description("The Servers.")]
		public virtual Nodes Servers
		{
			get
			{
				return (Nodes)base["servers"];
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
