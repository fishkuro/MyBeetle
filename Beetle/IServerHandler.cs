namespace Beetle
{
	public interface IServerHandler
	{
		void Opened(ServerBase server);

		void SocketConnect(ServerBase server, ChannelCreatingArgs channelCreatingArgs_0);

		void ChannelCreated(ServerBase server, ChannelEventArgs channelEventArgs_0);

		void ChannelDisconnect(ServerBase server, ChannelDisposedEventArgs channelDisposedEventArgs_0);

		void ServerError(ServerBase server, TcpServerErrorArgs tcpServerErrorArgs_0);

		void ChannelError(ServerBase server, ChannelErrorEventArgs channelErrorEventArgs_0);

		void ChannelReceiveMessage(ServerBase server, PacketRecieveMessagerArgs packetRecieveMessagerArgs_0);

		void Disposed(ServerBase server);
	}
}
