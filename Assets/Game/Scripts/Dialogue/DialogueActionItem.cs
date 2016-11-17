using UnityEngine;
using System.Collections;

public class DialogueActionItem: DialogueOptions
{
	private string ActionsText;

	public DialogueActionItem(string nextNode, string actionsText) 
		: base(nextNode)
	{
		this.ActionsText = actionsText;
	}

	public string actionsText
	{
		get { return ActionsText; }
	}
}
