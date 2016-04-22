using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Custom.Manager;
using DG.Tweening;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour {

	public GameObject loginPanel;
	public GameObject serverPanel;

	private DOTweenAnimation tweenAni;
	private Text username;
	void Awake () {
		GameObject nameBtn = transform.Find ("Btn-UserName").gameObject;
		GameObject serverBtn = transform.Find ("Btn-Server").gameObject;
		GameObject startBtn = transform.Find ("Btn-Start").gameObject;

		EventTriggerManager.GetInstance ().AddTriggerEvent (nameBtn, EventTriggerType.PointerClick, OnNameClick);
		EventTriggerManager.GetInstance ().AddTriggerEvent (serverBtn, EventTriggerType.PointerClick, OnServerClick);
		EventTriggerManager.GetInstance ().AddTriggerEvent (startBtn, EventTriggerType.PointerClick, OnStartClick);

		tweenAni = transform.GetComponent<DOTweenAnimation> ();
		username = nameBtn.transform.Find ("Name").GetComponent<Text> ();

		CustomEventManager.GetInstance ().AddEventListener ("AccountChange", OnEventAccountChange);
	}

	void OnDestory () {
		CustomEventManager.GetInstance ().RemoveEventListener ("AccountChange", OnEventAccountChange);
	}
	public void FadeIn () {
		print ("main fadein......");
		tweenAni.DOPlayBackwards ();
	}

	public void FadeOut () {
		print ("main fadeout......");
		tweenAni.DOPlayForward ();
	}

	public void OnNameClick (BaseEventData data) {
		print ("Name");

		this.FadeOut ();
		loginPanel.transform.GetComponent<Login> ().MoveIn ();
	}

	public void OnServerClick (BaseEventData data) {
		print ("Server");
	}

	public void OnStartClick (BaseEventData data) {
		print ("Start");
	}
		
	public void OnEventAccountChange (CustomEventData data) {
		username.text = data.Args ["UserName"] as string;
	}
}
