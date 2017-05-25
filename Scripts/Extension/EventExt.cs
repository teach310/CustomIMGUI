using UnityEngine;
using System.Linq;

public static partial class EventExt {

	/// <summary>
	/// いずれかと等しいかどうかを返す
	/// </summary>
	public static bool IsAny(this EventType self, params EventType[] values){
		return values.Any (c => c == self);
	}
}
