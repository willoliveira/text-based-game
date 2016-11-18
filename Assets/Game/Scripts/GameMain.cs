using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	public DialogueControl dialogueControl;

	private Dictionary<string, Dialogue> DialogueList = new Dictionary<string, Dialogue>();

	// Use this for initialization
	void Start () {

		Dialogue D;
		DialogueNode DNode;
		DialogueOptions DOption;
		
		//Dialogue questions character
		D = new Dialogue();

		//Dialogue Node
		//DNode = new DialogueNode("initial_node", "Quem é você?");
		////Options
		//DOption = new DialogueActionItem("race_question", "{input}");
		//DNode.AddOption(DOption);
		//D.AddNode(DNode);

		//Dialogue Node
		DNode = new DialogueNode("race_question", "Qual raça voccê é?");
		//Options
		DOption = new DialogueOptionItem("class_question", "Human");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("class_question", "Elf");		DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("class_question", "Dwarf");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("class_question", "Dwarf");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("class_question", "Halfling"); DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("class_question", "Gnome");	DNode.AddOption(DOption);
		D.AddNode(DNode);

		//Dialogue Node
		DNode = new DialogueNode("class_question", "Qual classe voccê é?");
		//Options
		DOption = new DialogueOptionItem("{end}", "Fighter");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("{end}", "Wizard");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("{end}", "Cleric");	DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("{end}", "Rogue");		DNode.AddOption(DOption);
		DOption = new DialogueOptionItem("{end}", "Ranger");	DNode.AddOption(DOption);
		D.AddNode(DNode);

		//definindo o nó inicial
		//TODO: usar isso depois
		D.actual_dialogue_id = "race_question";


		DialogueList.Add("stat_dialogue", D);

		//starta o role
		//TODO: meio na gambs ainda
		dialogueControl.dialogueList = DialogueList;
		dialogueControl.StartDialogue(D);
	}

	

}
