using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour {
	private string serverAdress;
	private int serverID;
	private string serverName;
	private bool isCrowed;

	private Text serverText;
	private Image serverImage;

	private Sprite isCrowedSp;
	private Sprite noCrowedSp;

	private Color isCrowedColor;
	private Color noCrowedColor;

	private bool isTargetServer = false;

	void Awake () {
		serverText = transform.Find ("Name").GetComponent<Text> ();
		serverImage = transform.GetComponent<Image> ();
		isCrowedSp = Resources.Load<GameObject> ("Menu/btn_火爆1").GetComponent<SpriteRenderer>().sprite;
		noCrowedSp = Resources.Load<GameObject> ("Menu/btn_流畅1").GetComponent<SpriteRenderer>().sprite;
		isCrowedColor = Color.red;
		noCrowedColor = Color.green;
	}
		
	public string ServerAdress {
		get{
			return serverAdress;
		}
	}
	public int ServerID {
		get{
			return serverID;
		}
	}
	public string ServerName {
		get{
			return serverName;
		}
	}
	public bool IsCrowed {
		get{
			return isCrowed;
		}
	}
	public bool IsTargetServer {
		get{
			return isTargetServer;
		}
		set{
			isTargetServer = value;
		}
	}

	public void CloneData (ServerItem targetItem) {
		serverAdress = targetItem.ServerAdress;
		serverName = targetItem.ServerName;
		serverID = targetItem.ServerID;
		isCrowed = targetItem.IsCrowed;

		this.UpdateServerItem ();
	}

	public void InitServerItem (string adress, int id, string name, bool crowedEnable) {
		serverAdress = adress;
		serverID = id;
		serverName = name;
		isCrowed = crowedEnable;

		this.UpdateServerItem ();
	}

	private void UpdateServerItem () {
		serverText.text = serverID + "区  " + serverName;
		if (isCrowed) {
			serverText.color = isCrowedColor;
			serverImage.sprite = GameObject.Instantiate (isCrowedSp) as Sprite;
		} else {
			serverText.color = noCrowedColor;
			serverImage.sprite = GameObject.Instantiate (noCrowedSp) as Sprite;
		}
	}
}
