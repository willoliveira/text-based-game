using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	public Dictionary<string, Dialogue> DialogueList =  new Dictionary<string, Dialogue>();

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
		D.actual_dialogue_id = "race_question";


		DialogueList.Add("stat_dialogue", D);


		StartDialogue(D);
	}

	public GameObject dialoguesContainer;
	public GameObject dialoguePanel;
	public GameObject dialogueOption;

	GameObject instance;
	void StartDialogue(Dialogue dialogue)
	{
		//colocando o dialogue panel na tela
		instance = Instantiate(dialoguePanel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(dialoguesContainer.transform, false);
		//chama o proximo dialogo
		NextDialgue(dialogue.actual_dialogue_id);
	}

	void NextDialgue(string idDialogue)
	{
		//dialoguePanel
		//	Enunciation
		//	OptionsContainer
		//set enunciado
		instance.transform.Find("Enunciation").GetComponent<Text>().text = DialogueList["stat_dialogue"].dialogDictionary[idDialogue].enunciation;
		//pega referencia do container
		Transform optionsContainer = instance.transform.Find("OptionsContainer") as Transform;
		foreach (DialogueOptions option in DialogueList["stat_dialogue"].dialogDictionary[idDialogue].options)
		{
			if (option.GetType() == typeof(DialogueOptionItem))
			{
				//cache do option
				DialogueOptionItem optionCache = (DialogueOptionItem) option;
				//instanciando um option
				GameObject instanceDialogueOption = Instantiate(dialogueOption, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				instanceDialogueOption.transform.SetParent(optionsContainer, false);
				//colocando o texto da alternativa
				instanceDialogueOption.transform.Find("OptionText").GetComponent<Text>().text = optionCache.text;
			}
		}

	}
}
