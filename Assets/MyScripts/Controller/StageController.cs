using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public void StageSelectManager(GameObject _obj)
	{
		QuestBoard.SetActive (true);
		GameObject.Find ("StageName").GetComponent<UILabel>().text = _obj.name;
		//UIEventListener.Get (_obj).onPress += UIManager.Instance.StageButton_OnPress;
	}

	public GameObject QuestBoard;
}
