using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class StartGame : MonoBehaviour {

	void Update () {
		if (Input.anyKey) {
			SceneManager.LoadScene ("Battle");
		}
	}
}
