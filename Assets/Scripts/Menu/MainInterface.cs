using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Custom.Manager;
using DG.Tweening;

public class MainInterface : MonoBehaviour {

	public GameObject loginPanel;
	public GameObject serverPanel;

	private DOTweenAnimation tweenAni;

	void Awake () {
		GameObject nameBtn = transform.Find ("Btn-UserName").gameObject;
		GameObject serverBtn = transform.Find ("Btn-Server").gameObject;
		GameObject startBtn = transform.Find ("Btn-Start").gameObject;

		EventTriggerManager.GetInstance ().AddTriggerEvent (nameBtn, EventTriggerType.PointerClick, OnNameClick);
		EventTriggerManager.GetInstance ().AddTriggerEvent (serverBtn, EventTriggerType.PointerClick, OnServerClick);
		EventTriggerManager.GetInstance ().AddTriggerEvent (startBtn, EventTriggerType.PointerClick, OnStartClick);

		tweenAni = transform.GetComponent<DOTweenAnimation> ();
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
		loginPanel.transform.GetComponent<Login> ().FadeIn ();
	}

	public void OnServerClick (BaseEventData data) {
		print ("Server");
	}

	public void OnStartClick (BaseEventData data) {
		print ("Start");
	}
}
