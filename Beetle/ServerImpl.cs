namespace Beetle
{
	public class ServerImpl<T> : ServerBase<T> where T : Package
	{
		private IServerHandler iserverHandler_0;

		protected override void OnOpening()
		{
			base.OnOpening();
			iserverHandler_0.Opened(this);
		}

		public ServerImpl(string name, IServerHandler handler)
		{
			base.Name = name;
			iserverHandler_0 = handler;
		}

		protected override void OnServerError(object sender, TcpServerErrorArgs tcpServerErrorArgs_0)
		{
			base.OnServerError(sender, tcpServerErrorArgs_0);
			iserverHandler_0.ServerError(this, tcpServerErrorArgs_0);
		}

		protected override void OnCreatingChannel(object sender, ChannelCreatingArgs channelCreatingArgs_0)
		{
			base.OnCreatingChannel(sender, channelCreatingArgs_0);
			iserverHandler_0.SocketConnect(this, channelCreatingArgs_0);
		}

		protected override void OnMessageReceive(PacketRecieveMessagerArgs packetRecieveMessagerArgs_0)
		{
			base.OnMessageReceive(packetRecieveMessagerArgs_0);
			iserverHandler_0.ChannelReceiveMessage(this, packetRecieveMessagerArgs_0);
		}

		protected override void OnDisposed(object sender, ChannelDisposedEventArgs e)
		{
			base.OnDisposed(sender, e);
			iserverHandler_0.ChannelDisconnect(this, e);
		}

		protected override void OnConnected(object sender, ChannelEventArgs e)
		{
			base.OnConnected(sender, e);
			iserverHandler_0.ChannelCreated(this, e);
		}

		protected override void OnServerDisposed()
		{
			base.OnServerDisposed();
			iserverHandler_0.Disposed(this);
		}

		protected override void OnError(object sender, ChannelErrorEventArgs e)
		{
			base.OnError(sender, e);
			iserverHandler_0.ChannelError(this, e);
		}
	}
}
