using UnityEngine;
using UnityEditor;
using UniRx;
using System.Collections.Generic;

namespace CustomIMGUI
{
	public class SampleWindow : EditorWindow
	{
		
		[MenuItem("Tools/Sample")]
		public static void Open(){
			GetWindow (typeof(SampleWindow), false, "Sample");
		}

		IMButton button;

		// Optional
		List<ICustomIMGUI> guiList = new List<ICustomIMGUI>();

		void OnEnable(){
			button = new IMButton (){backgroundColor = Color.yellow};
			button.OnClickAsObservable ().Subscribe (_ => Debug.Log ("Click!"));

			guiList.Add (button);
		}


		void OnGUI(){
			// 描画
			foreach (var item in guiList) {
				item.Draw ();
			}
		}
	}
}
