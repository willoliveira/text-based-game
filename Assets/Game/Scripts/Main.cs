using System.IO;
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine(loadXml());
	}
	
	IEnumerator loadXml()
	{
		var www = new WWW(Path.Combine(Application.dataPath, "Game/Data/monsters.xml"));
		yield return www;

		Debug.Log(www.text);
		var monsterCollection = MonsterContainer.LoadFromText(www.text);

		
	}

}
