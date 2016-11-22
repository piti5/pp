using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BattleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var StageInfo = ScenesManager.SInfo.FindIndex (Info => Info.SelectStage == 1);
		GameObject.Instantiate (StagePrefab [StageInfo]);//, new Vector3(0,0,0)

	}

	public List<GameObject> StagePrefab = new List<GameObject>();
}
