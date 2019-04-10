using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace linq_slideviews
{
	public static class ExtensionsTask
	{
		public static double Median(this IEnumerable<double> items)
		{
			if (items.Count() != 0)
			{
				var elements = items.ToList();
				elements.Sort();
				if (elements.Count % 2 != 0)
					return elements[elements.Count / 2];
				
				return (elements[elements.Count / 2] + elements[(elements.Count / 2) - 1]) / 2.0;
			}
			throw new InvalidOperationException();
		}

		public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
		{
			var enumerator = items.GetEnumerator();
			enumerator.MoveNext();
			var current = enumerator.Current;
			while (enumerator.MoveNext())
			{
				yield return Tuple.Create(current,enumerator.Current);
				current = enumerator.Current;
			}
		}
	}
}