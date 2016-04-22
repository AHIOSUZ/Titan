using UnityEngine;
using System.Collections;

namespace Custom.Manager{
	public class CustomEventData{
		#region Data
		private string name;
		private Object sender;
		private Hashtable args;

		public string Name{
			get{
				return name;
			}
			set{
				name = value;
			}
		}

		public Object Sender{
			get{
				return sender;
			}
			set{
				sender = value;
			}
		}

		public IDictionary Args{
			get{
				return args;
			}
			set{
				args = value as Hashtable;
			}
		}
		#endregion

		public CustomEventData(string name, Object sender){
			this.Name = name;
			this.Sender = sender;
			if(args == null) args = new Hashtable();
		}

		public CustomEventData(string name, Hashtable args, Object sender){
			this.Name = name;
			this.Args = args;
			this.Sender = sender;
			if(args == null) args = new Hashtable();
		}

		public CustomEventData Clone(){
			return new CustomEventData (name, args, sender);
		}
	}
}
