using UnityEngine;
using System.Collections;

public class DialogueOptionItem : DialogueOptions
{
	private string[] OptionsText;

	public DialogueOptionItem(string labelText, string nextNode, string[] optionsText)
	{
		this.LabelText = labelText;
		this.NextNode = nextNode;
		this.OptionsText = optionsText;
	}

	public string[] optionsText
	{
		get { return OptionsText; }
	}
}
