using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueControl : MonoBehaviour {

	public GameObject dialoguesContainer;
	public GameObject dialoguePanel;
	public GameObject dialogueOption;

	private GameObject panelDialogueInstance;

	private Dictionary<string, Dialogue> DialogueList = new Dictionary<string, Dialogue>();

	public Dictionary<string, Dialogue> dialogueList
	{
		set { DialogueList = value; }
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="dialogue"></param>
	public void StartDialogue(Dialogue dialogue)
	{
		//colocando o dialogue panel na tela
		panelDialogueInstance = Instantiate(dialoguePanel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		panelDialogueInstance.transform.SetParent(dialoguesContainer.transform, false);
		//chama o proximo dialogo
		NextDialgue(dialogue.actual_dialogue_id);
	}
	/// <summary>
	/// 
	/// todo: depois implementar um lance de limpar ou não o dialogo anterior
	/// todo: fazer um lance que de pra voltar dialogos
	/// </summary>
	/// <param name="idDialogue"></param>
	void NextDialgue(string idDialogue)
	{
		//dialoguePanel
		//	Enunciation
		//	OptionsContainer
		//Valida a option
		if (!ValidOptionDialogue(idDialogue)) return;
		//set enunciado
		panelDialogueInstance.transform.Find("Enunciation").GetComponent<Text>().text = DialogueList["stat_dialogue"].dialogDictionary[idDialogue].enunciation;
		//pega referencia do container
		Transform optionsContainer = panelDialogueInstance.transform.Find("OptionsContainer") as Transform;
		//TODO: Mudar isso aqui para reaproveitar os GO já criados...
		//Limpas as alternativas
		ClearOptionsDialogue(optionsContainer);
		//Cria os options com base no conteudo dos options
		foreach (DialogueOptions option in DialogueList["stat_dialogue"].dialogDictionary[idDialogue].options)
		{
			CreateOptionDialogue(option, optionsContainer);
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="idDialogue"></param>
	/// <returns></returns>
	bool ValidOptionDialogue(string idDialogue)
	{
		if (!DialogueList["stat_dialogue"].dialogDictionary.ContainsKey(idDialogue))
		{
			//Se for o fim
			if (idDialogue == "{end}")
				FinishDialogue();
			else
			{
				Debug.LogError("ID de dialogo não se encontra no dicionário");
				FinishDialogue();
			}
			return false;
		}
		return true;
	}
	/// <summary>
	/// 
	/// </summary>
	void FinishDialogue()
	{
		Debug.Log("Finish :)");
		panelDialogueInstance.gameObject.SetActive(false);
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="optionsContainer"></param>
	void ClearOptionsDialogue(Transform optionsContainer)
	{
		//Mudar isso aqui para reaproveitar os GO já criados...
		if (optionsContainer.childCount > 0)
		{
			for (int cont = 0, len = optionsContainer.childCount; cont < len; cont++)
			{
				Destroy(optionsContainer.GetChild(cont).gameObject);
			}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="option"></param>
	/// <param name="optionsContainer"></param>
	void CreateOptionDialogue(DialogueOptions option, Transform optionsContainer)
	{
		if (option.GetType() == typeof(DialogueOptionItem))
		{
			//cache do option
			DialogueOptionItem optionCache = (DialogueOptionItem)option;
			//instanciando um option
			GameObject instanceDialogueOption = Instantiate(dialogueOption, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			instanceDialogueOption.transform.SetParent(optionsContainer, false);
			//colocando o texto da alternativa
			instanceDialogueOption.transform.Find("OptionText").GetComponent<Text>().text = optionCache.text;

			//Add a click
			instanceDialogueOption.GetComponent<Button>().onClick.AddListener(delegate { onClickOption(option); });
		}
	}

	void onClickOption(DialogueOptions option)
	{
		Debug.Log(option.nextNode);

		NextDialgue(option.nextNode);
	}

}
