using System;

public static class ActionBinder
{
	public static Action Bind<TObj>(TObj obj, Action<TObj> function)
	{
		return () =>
		{
			function(obj);
		};
	}

	public static Action<TArg1> Bind<Tobj, TArg1>(Tobj obj, Action<Tobj, TArg1> function)
	{
		return (TArg1 arg1) =>
		{
			function(obj, arg1);
		};
	}
}
