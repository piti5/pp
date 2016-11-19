using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {

	//public int _exp = 0;

	void Start () {
		List<Dictionary<string,object>> data = CSVReader.Read("PlayerCharacterTable");

		for(var i=0; i< data.Count; i++){
			Debug.Log("index " + (i).ToString() + " : " + data[i]["Name"]);
		}



		//_exp = (int)data[0]["Name"];
		//Debug.Log(_exp);
	}

	List<CharacterClass> Test = new List<CharacterClass>();
}
