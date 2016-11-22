using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageController : MonoBehaviour {

	public void StageSelectManager(GameObject _obj)
	{
		QuestBoard.SetActive (true);
		GameObject.Find ("StageName").GetComponent<UILabel>().text = _obj.name;
		StageUISet (_obj.name);
		SelectStageIndex = ScenesManager.SInfo.FindIndex (i => i.StageName == _obj.name);
		ScenesManager.SInfo [SelectStageIndex].SelectStage = 1;
	}

	public void CharSelectButtonClick()
	{
		QuestBoard.SetActive (false);
		CharBoard.SetActive (true);
	}

	public void QuestBackButtonClick()
	{
		QuestBoard.SetActive (false);
		ScenesManager.SInfo [SelectStageIndex].SelectStage = 0;
	}

	public void CharBackButtonClick()
	{
		CharBoard.SetActive (false);
		QuestBoard.SetActive (true);
	}

	public void BattleStart(GameObject _obj)
	{
		if (CharacterCheck ()) {
			ScenesManager.Instance.SceneChange (_obj.name);
		}

	}

	public bool CharacterCheck()
	{
		for (int i = 0; i < ScenesManager.CInfo.Count; ++i) {
			if (ScenesManager.CInfo [i].m_DeckInfo == 1) {
				return true;
			}
		}
		return false;
	}


	public void StageUISet(string _name)
	{
		for (int i = 0; i < ScenesManager.SInfo.Count; ++i) {
			LZItemData nItem = new LZItemData();

			if (ScenesManager.SInfo [i].StageName == _name) {
				for (int j = 0; j < ScenesManager.SInfo [i].Char.Count; ++j) {
					nItem.spriteName = ScenesManager.SInfo [i].Char [j];
					EnemySlot[j].GetComponent<LZItemSlot>().SetEnemySlot (nItem);
					if (nItem.spriteName == "null") {
						EnemySlot[j].GetComponent<LZItemSlot>().SetEnemySlot ();
					}
				}
			}
		}
	}

	public GameObject QuestBoard;
	public GameObject CharBoard;
	public UIAtlas EnemyAtlas;

	private int SelectStageIndex;
	private const float EnemySlotPosX = -400F;
	UISprite icon;
	public List<GameObject> EnemySlot;

	//public List<GameObject> 
}
