using UnityEngine;
using System.Collections;

public class DistanceSearch : MonoBehaviour {

	private const string ttag = "enemyAim";
	private const string ptag = "player";
	public Transform target;

	private float dist;

	private bool Flag = true;
	public bool SearchedFlag = false;

	GameObject[] taggedEnemys;
	GameObject[] taggedPlayer;

	// Use this for initialization
	void Start () {
		if (transform.CompareTag (ptag)) {
			InvokeRepeating ("getClosestEnemy", 5.0f, 1.0f);
		} else if (transform.CompareTag (ttag)) {
			InvokeRepeating ("getClosestPlayer", 5.0f, 1.0f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (target != null) {
			Debug.DrawLine (transform.position, target.position,
				Color.yellow);
		} else {
			Flag = true;
			SearchedFlag = false;
		}
	}
		
	void getClosestEnemy()  
	{
		if (Flag) {
			taggedEnemys = GameObject.FindGameObjectsWithTag(ttag);
			float closestDistSqr = Mathf.Infinity;//최단거리 하나만 판단하기 위한 변수
			Transform closestEnemy = null;
			for (int i = 0; i < taggedEnemys.Length; ++i) {

				Vector3 objectPos = taggedEnemys[i].transform.position;
				dist = (objectPos - transform.position).sqrMagnitude;
				//적이 특정 거리 안으로 들어올때
				if(dist < 300.0f)
				{
					if(dist < closestDistSqr)
					{
						closestDistSqr = dist;
						closestEnemy = taggedEnemys[i].transform;
						Flag = false;
						SearchedFlag = true;
					}
				}
			}
			target = closestEnemy;
		}
	}

	void getClosestPlayer()  
	{
		if (Flag) {
			taggedPlayer = GameObject.FindGameObjectsWithTag(ptag);
			float closestDistSqr = Mathf.Infinity;//최단거리 하나만 판단하기 위한 변수
			Transform closestPlayer = null;
			for (int i = 0; i < taggedPlayer.Length; ++i) {

				Vector3 objectPos = taggedPlayer[i].transform.position;
				dist = (objectPos - transform.position).sqrMagnitude;
				//적이 특정 거리 안으로 들어올때
				if(dist < 200.0f)
				{
					if(dist < closestDistSqr)
					{
						closestDistSqr = dist;
						closestPlayer = taggedPlayer[i].transform;
						Flag = false;
						SearchedFlag = true;
					}
				}
			}
			target = closestPlayer;
		}
	}
}
