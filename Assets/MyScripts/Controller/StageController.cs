using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageController : MonoBehaviour {

	public void StageSelectManager(GameObject _obj)
	{
		QuestBoard.SetActive (true);
		GameObject.Find ("StageName").GetComponent<UILabel>().text = _obj.name;
		//UIEventListener.Get (_obj).onPress += UIManager.Instance.StageButton_OnPress;
	}

	public void QuestBackButtonClick()
	{
		QuestBoard.SetActive (false);
	}

	public void CharBackButtonClick()
	{
		CharBoard.SetActive (false);
		QuestBoard.SetActive (true);
	}

	public void StageUISet(string _name)
	{
		
//		for(int i = 0; i < itemSpriteNames.Count; ++i)
//		{
//
//			LZItemData nItem = new LZItemData();
//			nItem.spriteName = itemSpriteNames[i];
//
//			if (ScenesManager.CInfo [i].m_DeckInfo == 1) {
//				foreach (ScenesManager.CharData C in ScenesManager.CInfo) {
//					if (C.m_Name == nItem.spriteName) {
//						DeckSlots [Deckindex].SetSlot (nItem);
//						++Deckindex;
//					}
//				}
//			}
//			else {
//				equipSlots[equipIndex].SetSlot(nItem);
//				++equipIndex;
//			}
//		}
//		itemSpriteNames.Clear ();
	}

	public GameObject QuestBoard;
	public GameObject CharBoard;
	public UIAtlas EnemyAtlas;
	UISprite icon;
	public List<LZItemSlot> EnemySlot;
	public List<string> EnemyName;
}
