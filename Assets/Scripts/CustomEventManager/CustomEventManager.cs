using UnityEngine;
using System.Collections;

namespace Custom.Manager{

	public delegate void EventListenerDelegate(CustomEventData data);

	public class CustomEventManager {
		private static CustomEventManager instance;
		private Hashtable listeners = new Hashtable();
		public static CustomEventManager GetInstance(){
			if (instance == null)
				instance = new CustomEventManager ();
			return instance;
		}
	
		public void AddEventListener(string name, EventListenerDelegate listener){
			var targetDelegate = listeners [name] as EventListenerDelegate;
			targetDelegate += listener;
			listeners [name] = targetDelegate;
		}

		public void RemoveEventListener(string name, EventListenerDelegate listener){
			var targetDelegate = listeners [name] as EventListenerDelegate;
			if (targetDelegate != null)
				targetDelegate -= listener;
			listeners [name] = targetDelegate;
		}

		public void DispatchEvent(CustomEventData data){
			var targetDelegate = listeners [data.Name] as EventListenerDelegate;
			if (targetDelegate != null)
				targetDelegate (data);
		}

		public void RemoveAll(){
			listeners.Clear ();
		}
	}
}
