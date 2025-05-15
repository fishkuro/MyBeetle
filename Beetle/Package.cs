using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Beetle
{
	public abstract class Package : IDisposable
	{
		private Dictionary<long, Class38> dictionary_0 = new Dictionary<long, Class38>();

		private bool bool_0 = true;

		public int BufferOffset;

		public int BufferCount;

		private Class25 class25_0 = Class25.smethod_6();

		public EventPacketRecievMessage ReceiveMessage;

		private PacketRecieveMessagerArgs packetRecieveMessagerArgs_0 = new PacketRecieveMessagerArgs(null, null);

		public IChannel Channel;

		protected IDataWriter Writer;

		private IDataWriter idataWriter_0;

		private bool bool_1;

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private Encoding encoding_0;

		public bool ReadSinglePackage
		{
			[CompilerGenerated]
			get
			{
				return bool_2;
			}
			[CompilerGenerated]
			set
			{
				bool_2 = value;
			}
		}

		public bool LittleEndian
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
				if (Writer != null)
				{
					Writer.LittleEndian = value;
				}
				if (idataWriter_0 != null)
				{
					idataWriter_0.LittleEndian = value;
				}
			}
		}

		public Encoding Coding
		{
			[CompilerGenerated]
			get
			{
				return encoding_0;
			}
			[CompilerGenerated]
			set
			{
				encoding_0 = value;
			}
		}

		public Package()
		{
			Coding = Encoding.UTF8;
			ReadSinglePackage = false;
		}

		internal void method_0(long long_0, Class38 class38_0)
		{
			lock (dictionary_0)
			{
				dictionary_0[long_0] = class38_0;
			}
		}

		public Package(IChannel channel)
		{
			LittleEndian = channel.LittleEndian;
			((Class40)channel).package_0 = this;
			Channel = channel;
			Coding = channel.Coding;
			((Class40)channel).eventDataReceive_0 = ImportReceiveData;
			((Class40)channel).eventMessageWriter_0 = MessageWrite;
			((Class40)channel).eventMessageWriter_1 = MessageWrited;
			packetRecieveMessagerArgs_0.Channel = channel;
			CreateWriterReader();
		}

		public virtual object WriteCast(object message)
		{
			return message;
		}

		public virtual object ReadCast(object message)
		{
			return message;
		}

		public void GetPools()
		{
		}

		public abstract void MessageWrite(IMessage imessage_0, IDataWriter writer);

		public virtual void MessageWrited(IMessage imessage_0, IDataWriter writer)
		{
		}

		public abstract IMessage MessageRead(IDataReader reader);

		public void CreateWriterReader()
		{
			Writer = new Stream0(TcpUtils.class7_1);
			Writer.LittleEndian = LittleEndian;
			((Stream0)Writer).encoding_0 = Coding;
			((Stream0)Writer).Channel = (Class40)Channel;
			idataWriter_0 = new Stream0(TcpUtils.class7_1);
			((Stream0)idataWriter_0).encoding_0 = Coding;
			((Stream0)idataWriter_0).Channel = (Class40)Channel;
			idataWriter_0.LittleEndian = LittleEndian;
			if (Channel != null && !class25_0.method_0(((Class40)Channel).int_0) && Channel.Server != null)
			{
				method_1();
			}
		}

		public void MessageToArraySegment(object object_0, ByteArraySegment data)
		{
			try
			{
				MessageWrite((IMessage)WriteCast(object_0), idataWriter_0);
				idataWriter_0.Position = 0L;
				data.Import((Stream)idataWriter_0);
			}
			finally
			{
				((Stream0)idataWriter_0).Reset();
			}
		}

		internal void method_1()
		{
			((Class40)Channel).string_2 = "package reset!";
			Channel.Dispose();
		}

		public void ImportReceiveData(object sender, ChannelReceiveEventArgs e)
		{
			Import(e.Data.Array, 0, e.Data.Count);
		}

		public abstract void Import(byte[] data, int start, int count);

		protected virtual void OnMessageDataReader(IDataWriter writer)
		{
			Interlocked.Increment(ref TcpUtils.ReceiveMessages);
			IMessage imessage_ = null;
			try
			{
				writer.Position = 0L;
				imessage_ = MessageRead((IDataReader)writer);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				((Stream0)writer).method_5(false);
			}
			method_2(imessage_, null);
		}

		protected virtual void OnReceiveMessage(PacketRecieveMessagerArgs packetRecieveMessagerArgs_1)
		{
			if (packetRecieveMessagerArgs_1.Message is ICallBackMessage)
			{
				ICallBackMessage callBackMessage = (ICallBackMessage)packetRecieveMessagerArgs_1.Message;
				Class38 value = null;
				if (dictionary_0.TryGetValue(callBackMessage.MessageID, out value))
				{
					lock (dictionary_0)
					{
						dictionary_0.Remove(callBackMessage.MessageID);
					}
					value.method_3(Channel, callBackMessage, value.method_0());
				}
				else if (ReceiveMessage != null)
				{
					ReceiveMessage(packetRecieveMessagerArgs_1);
				}
			}
			else if (ReceiveMessage != null)
			{
				ReceiveMessage(packetRecieveMessagerArgs_1);
			}
		}

		internal void method_2(IMessage imessage_0, object object_0)
		{
			try
			{
				packetRecieveMessagerArgs_0.Message = ReadCast(imessage_0);
				OnReceiveMessage(packetRecieveMessagerArgs_0);
			}
			catch (Exception innererr)
			{
				throw new LogicException(innererr, "message handler error!");
			}
		}

		protected virtual void OnDisposed()
		{
			if (Writer != null)
			{
				((Stream0)Writer).Channel = null;
				((Stream0)Writer).method_5(true);
				Writer = null;
			}
			if (idataWriter_0 != null)
			{
				((Stream0)idataWriter_0).Channel = null;
				((Stream0)idataWriter_0).method_5(true);
				idataWriter_0 = null;
			}
			dictionary_0.Clear();
			packetRecieveMessagerArgs_0.Channel = null;
			packetRecieveMessagerArgs_0.Message = null;
			packetRecieveMessagerArgs_0 = null;
			ReceiveMessage = null;
			Channel = null;
		}

		public void Dispose()
		{
			lock (this)
			{
				if (!bool_1)
				{
					bool_1 = true;
					OnDisposed();
				}
			}
		}
	}
}
