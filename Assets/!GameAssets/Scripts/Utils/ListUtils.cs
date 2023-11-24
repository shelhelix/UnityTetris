using System.Collections.Generic;

namespace GameJamEntry._GameAssets.Scripts.Utils {
	public static class ListUtils {
		public static T GetOrDefault<T>(this List<T> list, int index) => (index >= 0) && (index < list.Count) ? list[index] : default;
	}
}