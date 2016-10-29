using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Singleton SceneManager
public class ScenesManager : MonoBehaviour {

	//Singleton
	private static ScenesManager _instance = null;

	public static ScenesManager Instance
	{
		get{
			if (_instance == null)
				Debug.LogError ("ScenesManager == null");
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		DontDestroyOnLoad (transform.gameObject);
	}


	public void SceneChange(string MenuName)
	{
		Debug.Log (MenuName);
		SceneManager.LoadScene (MenuName);
	}

	public void BattleSceneChange(string StageName)
	{
		SelectStageName = StageName;
		//SceneManager.LoadScene ("BattleStage");
	}



	private GameObject LastObject;


	private static string LastScene;
	private static string SelectStageName;
}
