using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace CustomIMGUI{
	[System.Serializable]
	public class IMButton : ICustomIMGUI{
		public GUIContent label = new GUIContent();
		public Color backgroundColor = Color.white;

		private Subject<Unit> onClickSubject = new Subject<Unit>();
		public IObservable<Unit> OnClickAsObservable(){
			return onClickSubject;
		}

		public IMButton(){
			label.text = "Button";
		}

		public void Draw(){
			
			if (!Event.current.type.IsAny (EventType.Layout, EventType.Repaint, EventType.MouseUp, EventType.MouseDown)) {
				return;
			}

			using (new BackgroundColorScope (backgroundColor)) {
				if (GUILayout.Button (label)) {
					onClickSubject.OnNext (Unit.Default);
				}
			}
		}
	}
}
