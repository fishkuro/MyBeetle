using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Beetle.Controller;

internal class Class16
{
	private static Dictionary<FieldInfo, GetValueHandler> dictionary_0 = new Dictionary<FieldInfo, GetValueHandler>();

	private static Dictionary<FieldInfo, SetValueHandler> dictionary_1 = new Dictionary<FieldInfo, SetValueHandler>();

	private static Dictionary<PropertyInfo, GetValueHandler> dictionary_2 = new Dictionary<PropertyInfo, GetValueHandler>();

	private static Dictionary<PropertyInfo, SetValueHandler> dictionary_3 = new Dictionary<PropertyInfo, SetValueHandler>();

	private static Dictionary<MethodInfo, FastMethodHandler> dictionary_4 = new Dictionary<MethodInfo, FastMethodHandler>();

	private static Dictionary<Type, ObjectInstanceHandler> dictionary_5 = new Dictionary<Type, ObjectInstanceHandler>();

	public static GetValueHandler smethod_0(FieldInfo fieldInfo_0)
	{
		if (dictionary_0.ContainsKey(fieldInfo_0))
		{
			return dictionary_0[fieldInfo_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_0.ContainsKey(fieldInfo_0))
			{
				return dictionary_0[fieldInfo_0];
			}
			GetValueHandler getValueHandler = smethod_1(fieldInfo_0);
			dictionary_0.Add(fieldInfo_0, getValueHandler);
			return getValueHandler;
		}
	}

	private static GetValueHandler smethod_1(FieldInfo fieldInfo_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod("", typeof(object), new Type[1] { typeof(object) }, fieldInfo_0.DeclaringType);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldfld, fieldInfo_0);
		smethod_13(iLGenerator, fieldInfo_0.FieldType);
		iLGenerator.Emit(OpCodes.Ret);
		return (GetValueHandler)dynamicMethod.CreateDelegate(typeof(GetValueHandler));
	}

	public static SetValueHandler smethod_2(FieldInfo fieldInfo_0)
	{
		if (dictionary_1.ContainsKey(fieldInfo_0))
		{
			return dictionary_1[fieldInfo_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_1.ContainsKey(fieldInfo_0))
			{
				return dictionary_1[fieldInfo_0];
			}
			SetValueHandler setValueHandler = smethod_3(fieldInfo_0);
			dictionary_1.Add(fieldInfo_0, setValueHandler);
			return setValueHandler;
		}
	}

	private static SetValueHandler smethod_3(FieldInfo fieldInfo_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod("", null, new Type[2]
		{
			typeof(object),
			typeof(object)
		}, fieldInfo_0.DeclaringType);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		smethod_12(iLGenerator, fieldInfo_0.FieldType);
		iLGenerator.Emit(OpCodes.Stfld, fieldInfo_0);
		iLGenerator.Emit(OpCodes.Ret);
		return (SetValueHandler)dynamicMethod.CreateDelegate(typeof(SetValueHandler));
	}

	public static SetValueHandler smethod_4(PropertyInfo propertyInfo_0)
	{
		if (dictionary_3.ContainsKey(propertyInfo_0))
		{
			return dictionary_3[propertyInfo_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_3.ContainsKey(propertyInfo_0))
			{
				return dictionary_3[propertyInfo_0];
			}
			SetValueHandler setValueHandler = smethod_5(propertyInfo_0);
			dictionary_3.Add(propertyInfo_0, setValueHandler);
			return setValueHandler;
		}
	}

	private static SetValueHandler smethod_5(PropertyInfo propertyInfo_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, null, new Type[2]
		{
			typeof(object),
			typeof(object)
		}, propertyInfo_0.DeclaringType.Module);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		smethod_12(iLGenerator, propertyInfo_0.PropertyType);
		iLGenerator.EmitCall(OpCodes.Callvirt, propertyInfo_0.GetSetMethod(), null);
		iLGenerator.Emit(OpCodes.Ret);
		return (SetValueHandler)dynamicMethod.CreateDelegate(typeof(SetValueHandler));
	}

	public static GetValueHandler smethod_6(PropertyInfo propertyInfo_0)
	{
		if (dictionary_2.ContainsKey(propertyInfo_0))
		{
			return dictionary_2[propertyInfo_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_2.ContainsKey(propertyInfo_0))
			{
				return dictionary_2[propertyInfo_0];
			}
			GetValueHandler getValueHandler = smethod_7(propertyInfo_0);
			dictionary_2.Add(propertyInfo_0, getValueHandler);
			return getValueHandler;
		}
	}

	private static GetValueHandler smethod_7(PropertyInfo propertyInfo_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[1] { typeof(object) }, propertyInfo_0.DeclaringType.Module);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.EmitCall(OpCodes.Callvirt, propertyInfo_0.GetGetMethod(), null);
		smethod_13(iLGenerator, propertyInfo_0.PropertyType);
		iLGenerator.Emit(OpCodes.Ret);
		return (GetValueHandler)dynamicMethod.CreateDelegate(typeof(GetValueHandler));
	}

	public static FastMethodHandler smethod_8(MethodInfo methodInfo_0)
	{
		FastMethodHandler fastMethodHandler = null;
		if (dictionary_4.ContainsKey(methodInfo_0))
		{
			return dictionary_4[methodInfo_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_4.ContainsKey(methodInfo_0))
			{
				return dictionary_4[methodInfo_0];
			}
			fastMethodHandler = smethod_9(methodInfo_0);
			dictionary_4.Add(methodInfo_0, fastMethodHandler);
			return fastMethodHandler;
		}
	}

	private static FastMethodHandler smethod_9(MethodInfo methodInfo_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
		{
			typeof(object),
			typeof(object[])
		}, methodInfo_0.DeclaringType.Module);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = methodInfo_0.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				array[i] = parameters[i].ParameterType.GetElementType();
			}
			else
			{
				array[i] = parameters[i].ParameterType;
			}
		}
		LocalBuilder[] array2 = new LocalBuilder[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = iLGenerator.DeclareLocal(array[j], true);
		}
		for (int k = 0; k < array.Length; k++)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
			smethod_14(iLGenerator, k);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			smethod_12(iLGenerator, array[k]);
			iLGenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (!methodInfo_0.IsStatic)
		{
			iLGenerator.Emit(OpCodes.Ldarg_0);
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (parameters[l].ParameterType.IsByRef)
			{
				iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
			}
		}
		if (methodInfo_0.IsStatic)
		{
			iLGenerator.EmitCall(OpCodes.Call, methodInfo_0, null);
		}
		else
		{
			iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo_0, null);
		}
		if (methodInfo_0.ReturnType == typeof(void))
		{
			iLGenerator.Emit(OpCodes.Ldnull);
		}
		else
		{
			smethod_13(iLGenerator, methodInfo_0.ReturnType);
		}
		for (int m = 0; m < array.Length; m++)
		{
			if (parameters[m].ParameterType.IsByRef)
			{
				iLGenerator.Emit(OpCodes.Ldarg_1);
				smethod_14(iLGenerator, m);
				iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
				if (array2[m].LocalType.IsValueType)
				{
					iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
				}
				iLGenerator.Emit(OpCodes.Stelem_Ref);
			}
		}
		iLGenerator.Emit(OpCodes.Ret);
		return (FastMethodHandler)dynamicMethod.CreateDelegate(typeof(FastMethodHandler));
	}

	public static ObjectInstanceHandler smethod_10(Type type_0)
	{
		if (dictionary_5.ContainsKey(type_0))
		{
			return dictionary_5[type_0];
		}
		lock (typeof(Class16))
		{
			if (dictionary_5.ContainsKey(type_0))
			{
				return dictionary_5[type_0];
			}
			ObjectInstanceHandler objectInstanceHandler = smethod_11(type_0);
			dictionary_5.Add(type_0, objectInstanceHandler);
			return objectInstanceHandler;
		}
	}

	private static ObjectInstanceHandler smethod_11(Type type_0)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, type_0, null, type_0.Module);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.DeclareLocal(type_0, true);
		iLGenerator.Emit(OpCodes.Newobj, type_0.GetConstructor(new Type[0]));
		iLGenerator.Emit(OpCodes.Stloc_0);
		iLGenerator.Emit(OpCodes.Ldloc_0);
		iLGenerator.Emit(OpCodes.Ret);
		return (ObjectInstanceHandler)dynamicMethod.CreateDelegate(typeof(ObjectInstanceHandler));
	}

	private static void smethod_12(ILGenerator ilgenerator_0, Type type_0)
	{
		if (type_0.IsValueType)
		{
			ilgenerator_0.Emit(OpCodes.Unbox_Any, type_0);
		}
		else
		{
			ilgenerator_0.Emit(OpCodes.Castclass, type_0);
		}
	}

	private static void smethod_13(ILGenerator ilgenerator_0, Type type_0)
	{
		if (type_0.IsValueType)
		{
			ilgenerator_0.Emit(OpCodes.Box, type_0);
		}
	}

	private static void smethod_14(ILGenerator ilgenerator_0, int int_0)
	{
		switch (int_0)
		{
		case -1:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_8);
			return;
		}
		if (int_0 > -129 && int_0 < 128)
		{
			ilgenerator_0.Emit(OpCodes.Ldc_I4_S, (sbyte)int_0);
		}
		else
		{
			ilgenerator_0.Emit(OpCodes.Ldc_I4, int_0);
		}
	}
}
