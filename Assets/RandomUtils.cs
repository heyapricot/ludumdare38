using UnityEngine;

namespace AssemblyCSharp
{
	public class RandomUtils
	{
		public static T Choice<T>(T[] array) {
			return array [Random.Range(0, array.Length - 1)];
		}
		public static Vector2 InBox(Vector2 center, Vector2 size) {
			return new Vector2 (center.x - size.x / 2 + (Random.value * size.x),
				center.y - size.y / 2 + (Random.value * size.y));
		}
	}
}

