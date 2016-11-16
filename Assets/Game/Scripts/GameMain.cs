using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	public List<Dialogue> DialogueList;
	public Dictionary<string, DialogueNode> DialogDictionary;

	// Use this for initialization
	void Start () {

		Dialogue D;
		DialogueNode DNode;
		DialogueOptions DOption;

		//Dialogue questions character
		D = new Dialogue();

		//Dialogue Node
		DNode = new DialogueNode(1, "initial_node");
		//Options
		DOption = new DialogueActionItem("Quem é você?", "next", new string[] { "{input}" });
		DNode.AddOption(DOption);
		//D.AddNode(DNode);
		DialogDictionary.Add(DNode.name, DNode);

		//Dialogue Node
		DNode = new DialogueNode(2, "race_question");
		//Options
		DOption = new DialogueOptionItem("Qual raça voccê é?", "next", new string[] { "Human", "Elf", "Dwarf", "Halfling", "Gnome", "Half-orc" });
		DNode.AddOption(DOption);
		DialogDictionary.Add(DNode.name, DNode);
		//D.AddNode(DNode);

		//Dialogue Node
		DNode = new DialogueNode(3, "class_question");
		//Options
		DOption = new DialogueOptionItem("Qual classe voccê é?", "next", new string[] { "Fighter", "Wizard", "Cleric", "Rogue", "Ranger" });
		DialogDictionary.Add(DNode.name, DNode);
		//DNode.AddOption(DOption);

		D.AddNode(DNode);


		DialogueList.Add(D);

		Debug.Log(DialogDictionary["initial_node"]);
	}
}
