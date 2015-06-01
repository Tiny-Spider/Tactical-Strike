/* Tuple class for Unity3D */

using System;

public static class Tuple
{
	public static Tuple<T1> Create<T1>(T1 value1)
	{
		return new Tuple<T1>(value1);
	}

	public static Tuple<T1, T2> Create<T1, T2>(T1 value1, T2 value2)
	{
		return new Tuple<T1, T2>(value1, value2);
	}

	public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
	{
		return new Tuple<T1, T2, T3>(value1, value2, value3);
	}

	public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
	{
		return new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4);
	}

	public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
	{
		return new Tuple<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5);
	}

	public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
	{
		return new Tuple<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6);
	}

	public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
	{
		return new Tuple<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7);
	}

	public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
	{
		return new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(value1, value2, value3, value4, value5, value6, value7, new Tuple<T8>(value8));
	}
}

public class Tuple<T1>
{
	public T1 Item1 { get; set; }

	public Tuple(T1 value1)
	{
		Item1 = value1;
	}
}

public class Tuple<T1, T2>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }

	public Tuple(T1 value1, T2 value2)
	{
		Item1 = value1;
		Item2 = value2;
	}
}

public class Tuple<T1, T2, T3>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
	}
}

public class Tuple<T1, T2, T3, T4>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }
	public T4 Item4 { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3, T4 value4)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
		Item4 = value4;
	}
}

public class Tuple<T1, T2, T3, T4, T5>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }
	public T4 Item4 { get; set; }
	public T5 Item5 { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
		Item4 = value4;
		Item5 = value5;
	}
}

public class Tuple<T1, T2, T3, T4, T5, T6>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }
	public T4 Item4 { get; set; }
	public T5 Item5 { get; set; }
	public T6 Item6 { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
		Item4 = value4;
		Item5 = value5;
		Item6 = value6;
	}
}

public class Tuple<T1, T2, T3, T4, T5, T6, T7>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }
	public T4 Item4 { get; set; }
	public T5 Item5 { get; set; }
	public T6 Item6 { get; set; }
	public T7 Item7 { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
		Item4 = value4;
		Item5 = value5;
		Item6 = value6;
		Item7 = value7;
	}
}

public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
{
	public T1 Item1 { get; set; }
	public T2 Item2 { get; set; }
	public T3 Item3 { get; set; }
	public T4 Item4 { get; set; }
	public T5 Item5 { get; set; }
	public T6 Item6 { get; set; }
	public T7 Item7 { get; set; }
	public TRest Rest { get; set; }

	public Tuple(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, TRest restValue)
	{
		Item1 = value1;
		Item2 = value2;
		Item3 = value3;
		Item4 = value4;
		Item5 = value5;
		Item6 = value6;
		Item7 = value7;
		Rest = restValue;
	}
}