using UnityEngine;
using System.Collections;

public class DialogueActionItem: DialogueOptions
{
	private string[] ActionsText;

	public DialogueActionItem(string labelText, string nextNode, string[] actionsText)
	{
		this.LabelText = labelText;
		this.NextNode = nextNode;
		this.ActionsText = actionsText;
	}

	public string[] actionsText
	{
		get { return ActionsText; }
	}
}
