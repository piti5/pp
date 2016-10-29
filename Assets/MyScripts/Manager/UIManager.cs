using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UIManager : MonoBehaviour {


	//Singleton
	private static UIManager _instance = null;

	public static UIManager Instance
	{
		get{
			if (_instance == null)
				Debug.LogError ("UIManager == null");
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
		DontDestroyOnLoad (transform.gameObject);
	}



	private bool DetectHoverSameObject(GameObject _obj)
	{
		RaycastHit hit;
		Ray ray = NGUITools.FindCameraForLayer (_obj.layer).ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
		{
			return(hit.collider.gameObject == _obj);
		}
		return false;
	}

	public void GlobalButton_OnPress(GameObject _obj, bool isPressed)
	{
		if (!isPressed && DetectHoverSameObject (_obj)) {
			ScenesManager.Instance.SceneChange (_obj.name);
		}
	}

	public void StageButton_OnPress(GameObject _obj, bool isPressed)
	{
		if (!isPressed && DetectHoverSameObject (_obj)) {
			GameObject.Find ("StageName").GetComponent<UILabel>().text = _obj.name;
		}
	}

//	public void CharacterButton_OnPress(GameObject _obj, bool isPressed)
//	{
//		foreach (GameObject model in CharModel) {
//			model.SetActive (false);
//		}
//		if (!isPressed && DetectHoverSameObject (_obj)) {
//			GameObject temp = CharModel.Where (obj => obj.name == _obj.name).SingleOrDefault ();
//			temp.SetActive (true);
//		}
//	}

	public void CharacterButton_OnDragEnd(GameObject _obj)
	{
		
		if (_obj.transform.parent.name == "SetDeck") 
		{
			if (GameObject.Find ("SetDeck").transform.childCount < 6) {
				SetCharacter.Add (_obj.name);
			}
		} 
		else if (_obj.transform.parent.name == "Grid") 
		{
			SetCharacter.Remove (_obj.name);
		}
		PlayerPrefs.SetString ("Deck", SetCharacter.ToString ());
	}
		
	public static List<string> SetCharacter = new List<string> ();
	public List<GameObject> CharModel = new List<GameObject> ();

}
