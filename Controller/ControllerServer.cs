using System;

namespace Beetle.Controller
{
	public class ControllerServer<T> : ServerBase<T> where T : Package
	{
		private MessageAttribute attribute0_0 = new MessageAttribute();

		protected override void OnOpening()
		{
			attribute0_0.method_3(this);
			base.OnOpening();
		}

		public void RegisterController(Type type)
		{
			attribute0_0.method_2(type);
		}

		public void RegisterController(object controller)
		{
			attribute0_0.method_3(controller);
		}

		protected override void OnMessageReceive(PacketRecieveMessagerArgs packetRecieveMessagerArgs_0)
		{
			base.OnMessageReceive(packetRecieveMessagerArgs_0);
			if (!attribute0_0.Invoke(packetRecieveMessagerArgs_0.Channel, packetRecieveMessagerArgs_0.Message))
			{
				NotControllerInvokeMessage(packetRecieveMessagerArgs_0);
			}
		}

		protected virtual void NotControllerInvokeMessage(PacketRecieveMessagerArgs packetRecieveMessagerArgs_0)
		{
		}
	}
}
