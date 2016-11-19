using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LZInventoryManager : MonoBehaviour {

	public UIAtlas atlas;
	public List<LZItemSlot> equipSlots;
	public List<LZItemSlot> DeckSlots;
	public List<string> itemSpriteNames;

	void Start()
	{
		
		Invoke("SetupEquiptSlot", 0.5f);
	}

	public void SetupEquiptSlot()
	{
		int equipIndex = 0;
		int Deckindex = 0;


		for (int i = 0; i < ScenesManager.CInfo.Count; ++i) {
			itemSpriteNames.Add(ScenesManager.CInfo [i].m_Name);
		}

		for(int i = 0; i < itemSpriteNames.Count; ++i)
		{
			
			LZItemData nItem = new LZItemData();
			nItem.spriteName = itemSpriteNames[i];

			if (ScenesManager.CInfo [i].m_DeckInfo == 1) {
				foreach (ScenesManager.CharData C in ScenesManager.CInfo) {
					if (C.m_Name == nItem.spriteName) {
						DeckSlots [Deckindex].SetSlot (nItem);
						++Deckindex;
					}
				}
			}
			else {
				equipSlots[equipIndex].SetSlot(nItem);
				++equipIndex;
			}
		}
		itemSpriteNames.Clear ();

		SortSetSlot ();
	}


	public void SortSetSlot()
	{
		int equipIndex = 0;
		int Deckindex = 0;


		for (int i = 0; i < DeckSlots.Count; ++i) {
			DeckSlots [i].SetSlot ();
		}

		for (int i = 0; i < equipSlots.Count; ++i) {
			equipSlots [i].SetSlot ();
		}

		for (int i = 0; i < ScenesManager.SelectChar.Count; ++i) {
			LZItemData nItem = new LZItemData();
			nItem.spriteName = ScenesManager.SelectChar [i].m_Name;
			foreach (ScenesManager.CharData C in ScenesManager.SelectChar) {
				if (C.m_Name == nItem.spriteName) {
					DeckSlots [Deckindex].SetSlot (nItem);
					++Deckindex;
				}
			}
		}
		ScenesManager.SelectChar.Clear ();

		for (int i = 0; i < ScenesManager.NonSelectChar.Count; ++i) {
			LZItemData nItem = new LZItemData();
			nItem.spriteName = ScenesManager.NonSelectChar [i].m_Name;
			foreach (ScenesManager.CharData C in ScenesManager.NonSelectChar) {
				if (C.m_Name == nItem.spriteName) {
					equipSlots [equipIndex].SetSlot (nItem);
					++equipIndex;
				}
			}
		}
		ScenesManager.NonSelectChar.Clear ();

	}
}
