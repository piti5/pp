using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDataParse : MonoBehaviour {

	void Start () {
		List<Dictionary<string,object>> data = CSVReader.Read("PlayerCharacterTable");

		for(var i=0; i< data.Count; i++){
			ScenesManager.CharData Data;
			Data.m_Name = (string)data [i] ["Name"];
			Data.m_Attack = (int)data [i] ["Attack"];
			Data.m_MagicAttack = (int)data [i] ["MagicAttack"];
			Data.m_HP = (int)data [i] ["HP"];
			Data.m_Distance = (int)data [i] ["Distance"];
			Data.m_DeckInfo = (int)data[i]["DeckInfo"];
			ScenesManager.CInfo.Add (Data);
		}
	}
}
