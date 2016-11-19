using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

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
		//SceneManager.MoveGameObjectToScene (transform.gameObject, );
		SceneManager.LoadScene (MenuName);
	}

	public void BattleSceneChange(string StageName)
	{
		SelectStageName = StageName;
		//SceneManager.LoadScene ("BattleStage");
	}

	public string SceneCheck()
	{
		return SceneManager.GetActiveScene ().name;
	}

	public void DeckInfoChange(int _index, int value)
	{
		CharData temp = CInfo [_index];
		temp.m_DeckInfo = value;
		CInfo [_index] = temp;
		SortCharacter_Distance (value);
	}



	//원하는 것만 선택해서 소팅하기
	private void SortCharacter_Distance(int _DeckInfo)
	{
		List<CharData> SelectTemp = new List<CharData> ();
		List<CharData> NonSelectTemp = new List<CharData> ();

		SelectTemp = CInfo.Where (obj => obj.m_DeckInfo == SelectDeckInfo).OrderBy (x => x.m_Distance).ToList ();
		NonSelectTemp = CInfo.Where (obj => obj.m_DeckInfo == NonSelectDeckInfo).OrderBy (x => x.m_Distance).ToList ();
		SortCharacter_HP (SelectTemp, NonSelectTemp);

	}
	private void SortCharacter_HP(List<CharData> Seltemp, List<CharData> NonSeltemp)
	{
		SelectChar = Seltemp.OrderByDescending (x => x.m_HP).ToList ();
		NonSelectChar = NonSeltemp.OrderByDescending (x => x.m_HP).ToList ();
	}
		
	private GameObject LastObject;

	private static string LastScene;
	private static string SelectStageName;

	public struct CharData
	{
		public string m_Name;
		public int m_Attack;
		public int m_MagicAttack;
		public int m_HP;
		public int m_Distance;
		public int m_DeckInfo;
	}

	public static List<CharData> CInfo = new List<CharData>();
	public static List<CharData> SelectChar = new List<CharData>();
	public static List<CharData> NonSelectChar = new List<CharData>();

	const int SelectDeckInfo = 1;
	const int NonSelectDeckInfo = 0;

	public LZInventoryManager _inven;

	public static List<StageInfoClass> SInfo = new List<StageInfoClass>();
}
