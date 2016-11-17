using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueNode
{	
	private string Id;
	private string Enunciation;
	private List<DialogueOptions> DialogueListItems;

	public DialogueNode(string id, string enunciation)
	{
		this.Id = id;
		this.Enunciation = enunciation;

		DialogueListItems = new List<DialogueOptions>();
	}

	public string enunciation
	{
		get { return Enunciation; }
	}

	public string id
	{
		get { return Id; }
	}

	public List<DialogueOptions> options
	{
		get { return DialogueListItems;  }
	}


	public void AddOption(DialogueOptions option)
	{
		DialogueListItems.Add(option);
	}

	public void AddOptions(DialogueOptions[] option)
	{
		
	}
}