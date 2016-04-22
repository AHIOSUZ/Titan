using UnityEngine;
using System.Collections;
using Custom.Manager;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	public GameObject maininterfacePanel;

	private DOTweenAnimation tweenAni;
	private InputField account;

	void Awake () {
		GameObject loginBtn = transform.Find ("Btn-Login").gameObject;
		GameObject closeBtn = transform.Find ("Btn-Close").gameObject;

		EventTriggerManager.GetInstance ().AddTriggerEvent (loginBtn, EventTriggerType.PointerClick, OnLoginClick);
		EventTriggerManager.GetInstance ().AddTriggerEvent (closeBtn, EventTriggerType.PointerClick, OnCloseClick);

		tweenAni = transform.GetComponent<DOTweenAnimation> ();
		account = transform.Find ("Account/InputField").GetComponent<InputField> ();
	}

	public void FadeIn () {
		this.gameObject.SetActive (true);
		tweenAni.DOPlayBackwards ();
	}

	public void FadeOut () {
		tweenAni.DOPlayForward ();
	}

	public void OnLoginClick (BaseEventData data) {
		print ("login");
		this.FadeOut ();
		maininterfacePanel.transform.GetComponent<MainInterface> ().FadeIn ();
	}

	public void OnCloseClick (BaseEventData data) {
		print ("close");
		this.FadeOut ();
		maininterfacePanel.transform.GetComponent<MainInterface> ().FadeIn ();
	}
}
