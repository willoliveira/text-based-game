using UnityEngine;
using System.Collections;

public class DialogueOptions {
	
	protected string NextNode;

	public DialogueOptions(string nextNode)
	{
		this.NextNode = nextNode;
	}

	public string nextNode
	{
		get { return NextNode; }
	}
}
