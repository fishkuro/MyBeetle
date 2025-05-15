namespace Beetle.Controller
{
	public delegate void AsyncDelegate();
	public delegate void AsyncDelegate<T>(T gparam_0);
	public delegate void AsyncDelegate<T, T1>(T gparam_0, T1 gparam_1);
	public delegate void AsyncDelegate<T, T1, T2>(T gparam_0, T1 gparam_1, T2 gparam_2);
	public delegate void AsyncDelegate<T, T1, T2, T3>(T gparam_0, T1 gparam_1, T2 gparam_2, T3 gparam_3);
	public delegate void AsyncDelegate<T, T1, T2, T3, T4>(T gparam_0, T1 gparam_1, T2 gparam_2, T3 gparam_3, T4 gparam_4);
}
