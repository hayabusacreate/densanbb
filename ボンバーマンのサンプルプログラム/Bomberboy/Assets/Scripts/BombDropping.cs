using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BombDropping : NetworkBehaviour {

	[SerializeField]
	private GameObject bombPrefab;
	
	// Update is called once per frame
	void Update () {
		if (this.isLocalPlayer && Input.GetKeyDown ("space")) {
			CmdDropBomb ();
		}
	}

	[Command]
	void CmdDropBomb() {
		if (NetworkServer.active) {
			GameObject bomb = Instantiate (bombPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			NetworkServer.Spawn (bomb);
		}
	}
}
