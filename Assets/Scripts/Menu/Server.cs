using UnityEngine;
using System.Collections;
using DG.Tweening;
using Custom.Manager;
using UnityEngine.EventSystems;

public class Server : MonoBehaviour {
	public GameObject maininterfacePanel;

	private GameObject serverItem;
	private Transform serverGrid;
	private DOTweenAnimation tweenAni;

	void Awake () {
		tweenAni = transform.GetComponent<DOTweenAnimation> ();
		serverItem = Resources.Load<GameObject> ("Menu/ServerItem");
		serverGrid = transform.Find ("ServerView/ServerGrid");

		GameObject closeBtn = transform.Find ("Btn-Close").gameObject;
		EventTriggerManager.GetInstance ().AddTriggerEvent (closeBtn, EventTriggerType.PointerClick, OnCloseClick);

		this.InitServerList();
	}

	void InitServerList () {
		int serverCount = 10;
		serverGrid.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1200, (serverCount / 2 + serverCount % 2) * 100);
		for (int i = 1; i <= serverCount; i++) {
			GameObject go = GameObject.Instantiate (serverItem);
			go.GetComponent<ServerItem> ().InitServerItem ("127", i, "弗雷尔卓德", Random.Range (0, 100) > 50);
			go.transform.SetParent (serverGrid, false);
		}
	}
		
	public void OnCloseClick (BaseEventData data) {
		this.MoveOut ();
		maininterfacePanel.GetComponent<MainInterface> ().FadeIn ();
	}

	public void MoveIn () {
		tweenAni.DOPlayForward ();
	}

	public void MoveOut () {
		tweenAni.DOPlayBackwards ();
	}
}
