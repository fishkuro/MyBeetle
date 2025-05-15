using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Beetle
{
	public interface IChannel : IDisposable, LRUDetect.IConnecton
	{
		string Name { get; set; }

		object this[string name] { get; set; }

		ChannelStatus Status { get; set; }

		DateTime CreateTime { get; }

		int TickCount { get; }

		object Tag { get; set; }

		Package Package { get; }

		bool LittleEndian { get; set; }

		Socket Socket { get; }

		Encoding Coding { get; set; }

		long ClientID { get; }

		TcpServer Server { get; }

		bool IsDisposed { get; }

		IPEndPoint EndPoint { get; }

		EventSendMessageCompleted SendMessageCompleted { get; set; }

		EventDataReceive DataReceive { get; set; }

		EventMessageWriter MessageWriting { get; set; }

		EventMessageWriter MessageWrited { get; set; }

		bool EnabledSendCompeletedEvent { get; set; }

		event EventChannelError ChannelError;

		event EventChannelDisposed ChannelDisposed;

		Package SetPackage<T>() where T : Package;

		void BeginReceive();

		bool Send<T, T1, T2>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, EventCallBackHandler<T1> callback1, EventCallBackHandler<T2> callback2, object usertoken = null) where T : ICallBackMessage where T1 : ICallBackMessage where T2 : ICallBackMessage;

		bool Send<T, T1>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, EventCallBackHandler<T1> callback1, object usertoken = null) where T : ICallBackMessage where T1 : ICallBackMessage;

		bool Send<T>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, object usertoken = null) where T : ICallBackMessage;

		bool Send(object message);

		long GetSendBytes();

		long GetReceiveBytes();

		int GetSendQueues();

		int GetReceiveQueues();

		string GetCloseStatus();

		void InvokeChannelError(ChannelErrorEventArgs channelErrorEventArgs_0);
	}
}
