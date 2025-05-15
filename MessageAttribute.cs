using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Beetle;
using Beetle.Controller;

[AttributeUsage(AttributeTargets.Class)]
internal class MessageAttribute : Attribute
{
	private Dictionary<Type, BeetleTcpClient> dictionary_0 = new Dictionary<Type, BeetleTcpClient>(256);

	private BeetleTcpClient method_0(Type type_0)
	{
		BeetleTcpClient value = null;
		dictionary_0.TryGetValue(type_0, out value);
		return value;
	}

	public void method_1(Assembly assembly_0)
	{
		Type[] types = assembly_0.GetTypes();
		foreach (Type type_ in types)
		{
			method_2(type_);
		}
	}

	public void method_2(Type type_0)
	{
		MessageAttribute[] typeAttributes = SocketConnectionFilter.GetTypeAttributes<MessageAttribute>(type_0, false);
		if (typeAttributes.Length > 0 && !type_0.IsAbstract)
		{
			method_5(type_0, Activator.CreateInstance(type_0), SocketConnectionFilter.GetTypeAttributes<FilterAttribute>(type_0, false));
		}
	}

	public void method_3(object object_0)
	{
		Type type = object_0.GetType();
		method_5(type, object_0, SocketConnectionFilter.GetTypeAttributes<FilterAttribute>(type, false));
	}

	private List<Type> method_4(MethodInfo methodInfo_0)
	{
		List<Type> list = new List<Type>(8);
		SkipFilterAttribute[] methodAttributes = SocketConnectionFilter.GetMethodAttributes<SkipFilterAttribute>(methodInfo_0, false);
		foreach (SkipFilterAttribute skipFilterAttribute in methodAttributes)
		{
			if (skipFilterAttribute.Types != null)
			{
				Type[] types = skipFilterAttribute.Types;
				foreach (Type item in types)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	private void method_5(Type type_0, object object_0, FilterAttribute[] filterAttribute_0)
	{
		MethodInfo[] methods = type_0.GetMethods(BindingFlags.Instance | BindingFlags.Public);
		foreach (MethodInfo methodInfo in methods)
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != 2 || !(parameters[0].ParameterType == typeof(IChannel)))
			{
				continue;
			}
			List<Type> list = method_4(methodInfo);
			BeetleTcpClient @class = new BeetleTcpClient();
			@class.class14_0 = new StreamInputHandler(methodInfo);
			@class.object_0 = object_0;
			@class.bool_0 = SocketConnectionFilter.GetMethodAttributes<UseThreadPool>(methodInfo, false).Length > 0;
			foreach (FilterAttribute filterAttribute in filterAttribute_0)
			{
				if (!list.Contains(filterAttribute.GetType()))
				{
					@class.ilist_0.Add(filterAttribute);
				}
			}
			FilterAttribute[] methodAttributes = SocketConnectionFilter.GetMethodAttributes<FilterAttribute>(methodInfo, false);
			foreach (FilterAttribute filterAttribute2 in methodAttributes)
			{
				if (!list.Contains(filterAttribute2.GetType()))
				{
					@class.ilist_0.Add(filterAttribute2);
				}
			}
			dictionary_0[parameters[1].ParameterType] = @class;
		}
	}

	public bool Invoke(IChannel ichannel_0, object object_0)
	{
		BeetleTcpClient @class = method_0(object_0.GetType());
		if (@class != null)
		{
			if (@class.bool_0)
			{
				ThreadPool.QueueUserWorkItem(method_6, new object[3] { ichannel_0, object_0, @class });
			}
			else
			{
				method_6(new object[3] { ichannel_0, object_0, @class });
			}
			return true;
		}
		return false;
	}

	private void method_6(object object_0)
	{
		IChannel channel = null;
		object[] array = (object[])object_0;
		try
		{
			channel = (IChannel)array[0];
			BeetleTcpClient class5_ = (BeetleTcpClient)array[2];
			using (ActionContext actionContext = ActionContext.GetContext())
			{
				actionContext.method_0(channel, array[1], class5_);
				actionContext.Execute();
				if (actionContext.Result != null)
				{
					channel.Send(actionContext.Result);
				}
			}
		}
		catch (Exception exception)
		{
			try
			{
				IChannel channel2 = channel;
				ControllerError controllerError = new ControllerError();
				controllerError.Channel = channel;
				controllerError.Exception = exception;
				controllerError.Message = array[1];
				channel2.InvokeChannelError(controllerError);
			}
			catch
			{
			}
		}
	}
}
