using UnityEngine;

namespace GameProgramming2D {
	public static class Extensions {
		// TComponent = mikä tahansa (syötetty) komponentti.
		// Where-systeemi: Täytyy olla Component tai sen perillinen.
		public static TComponent GetOrAddComponent<TComponent> (this GameObject go) where TComponent : Component {
			TComponent result = go.GetComponent<TComponent> ();
			if (result == null) {
				result = go.AddComponent<TComponent>();
			}

			return result;
		}
	}
}
