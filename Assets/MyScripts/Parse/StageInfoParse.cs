using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageInfoParse : MonoBehaviour {

	void Start () {
		List<Dictionary<string,object>> data = CSVReader.Read("Deck");

		for(var i=0; i< data.Count; i++){
			StageInfoClass Data = null;
			Data.StageName = (string)data [i] ["StageName"];
			Data.Char.Add((string)data[i]["Char1"]);
			Data.Char.Add((string)data[i]["Char2"]);
			Data.Char.Add((string)data[i]["Char3"]);
			Data.Char.Add((string)data[i]["Char4"]);
			Data.Char.Add((string)data[i]["Char5"]);
			ScenesManager.SInfo.Add (Data);
		}
	}

	public string GetChar(string StageName)
	{
		
		return "1";
	}
}
