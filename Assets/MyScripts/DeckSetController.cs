using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DeckSetController : MonoBehaviour {

	public void ClickCharacter(GameObject _obj)
	{
		if (_obj.GetComponent<UISprite> ().enabled == true) {
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
	}
	public List<GameObject> CharModel = new List<GameObject> ();
}
