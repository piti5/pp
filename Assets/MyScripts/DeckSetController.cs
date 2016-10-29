using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DeckSetController : MonoBehaviour {

	public void ClickCharacter(GameObject _obj)
	{
		foreach (GameObject model in CharModel) {
			model.SetActive (false);
		}
		GameObject temp = CharModel.Where (obj => obj.name == _obj.GetComponent<UISprite>().spriteName).SingleOrDefault ();
		if (temp == null) {
			return;
		} else {
			temp.SetActive (true);
		}

	}

	public void Character_DragEnd(GameObject _obj)
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
		//PlayerPrefs.SetString ("Deck", SetCharacter.ToString ());
	}

	public static List<string> SetCharacter = new List<string> ();
	public List<GameObject> CharModel = new List<GameObject> ();
}
