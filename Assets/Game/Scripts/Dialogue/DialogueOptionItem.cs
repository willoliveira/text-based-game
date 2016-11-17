using UnityEngine;
using System.Collections;

public class DialogueOptionItem : DialogueOptions
{
	private string Text;

	public DialogueOptionItem(string nextNode, string text)
		: base(nextNode)
	{
		this.Text = text;
	}

	public string text
	{
		get { return Text; }
	}
}
