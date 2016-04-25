using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Custom.Manager{
	public class EventTriggerManager {

		private static EventTriggerManager instance;

		public static EventTriggerManager GetInstance () {
			if (instance == null)
				instance = new EventTriggerManager ();
			return instance;
		}
			
		private EventTrigger GetEventTrigger (GameObject go) {
			EventTrigger trigger = go.transform.GetComponent<EventTrigger> ();
			if (trigger == null)
				trigger = go.AddComponent<EventTrigger> ();
			return trigger;
		}

		public void AddTriggerEvent (GameObject go, EventTriggerType eventID, UnityAction<BaseEventData> listener) {
			var trigger = this.GetEventTrigger (go);
			var newEntry = new EventTrigger.Entry ();
			newEntry.eventID = eventID;
			newEntry.callback.AddListener (listener);
			trigger.triggers.Add (newEntry);
		}

		public delegate void CustomEventDelegate(BaseEventData data, Hashtable args);
		public void AddTriggerEvent (GameObject go, EventTriggerType eventID, CustomEventDelegate listener, Hashtable args) {
			var trigger = this.GetEventTrigger (go);
			var newEntry = new EventTrigger.Entry ();
			newEntry.eventID = eventID;
			newEntry.callback.AddListener ((BaseEventData) => {
				listener(BaseEventData, args);
			});
			trigger.triggers.Add (newEntry);
		}
	}
}
