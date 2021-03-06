﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
using Custom.Manager;
using UnityEngine.EventSystems;

public class Server : MonoBehaviour {
	public GameObject maininterfacePanel;

	private GameObject serverItem;
	private Transform serverGrid;
	private GameObject targetServer;
	private DOTweenAnimation tweenAni;

	void Awake () {
		tweenAni = transform.GetComponent<DOTweenAnimation> ();
		serverItem = Resources.Load<GameObject> ("Menu/ServerItem");
		serverGrid = transform.Find ("ServerView/ServerGrid");
		targetServer = transform.Find ("TargetServer").gameObject;

		GameObject closeBtn = transform.Find ("Btn-Close").gameObject;
		EventTriggerManager.GetInstance ().AddTriggerEvent (closeBtn, EventTriggerType.PointerClick, OnCloseClick);

		this.InitServerList();
	}

	void InitServerList () {
		int serverCount = 10;
		serverGrid.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1200, (serverCount / 2 + serverCount % 2) * 100);
		for (int i = 1; i <= serverCount; i++) {
			GameObject go = GameObject.Instantiate (serverItem);
			var item = go.GetComponent<ServerItem> ();
			item.InitServerItem ("127", i, "弗雷尔卓德", Random.Range (0, 100) > 50);
			go.transform.SetParent (serverGrid, false);

			Hashtable args = new Hashtable ();
			args.Add ("adress", item.ServerAdress);
			args.Add ("id", item.ServerID);
			args.Add ("name", item.ServerName);
			args.Add ("peopel", item.IsCrowed);

			EventTriggerManager.GetInstance ().AddTriggerEvent (go, EventTriggerType.PointerClick, OnServerItemClick, args);
		}
	}
		

	public void MoveIn () {
		tweenAni.DOPlayForward ();
	}

	public void MoveOut () {
		tweenAni.DOPlayBackwards ();
	}

	public void OnCloseClick (BaseEventData data) {
		this.MoveOut ();
		maininterfacePanel.GetComponent<MainInterface> ().FadeIn ();
	}

	public void OnTargetServerClick () {
	
	}

	public void OnServerItemClick (BaseEventData data, Hashtable args) {
	}
}
