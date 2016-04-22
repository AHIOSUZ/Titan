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

	public void MoveIn () {
		this.gameObject.SetActive (true);
		tweenAni.DOPlayForward ();
	}

	public void MoveOut () {
		tweenAni.DOPlayBackwards ();
	}

	public void OnLoginClick (BaseEventData data) {
		print ("login");
		this.MoveOut ();
		maininterfacePanel.transform.GetComponent<MainInterface> ().FadeIn ();

		Hashtable table = new Hashtable ();
		table.Add ("UserName", account.text);
		CustomEventData eventdata = new CustomEventData ("AccountChange", table, this.gameObject);
		CustomEventManager.GetInstance ().DispatchEvent (eventdata);
	}

	public void OnCloseClick (BaseEventData data) {
		print ("close");
		this.MoveOut ();
		maininterfacePanel.transform.GetComponent<MainInterface> ().FadeIn ();
	}
}
