using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueNode
{
	

	private string Name;
	private int Id;
	private List<DialogueOptions> DialogueListItems;

	public DialogueNode(int id, string name)
	{
		this.Id = id;
		this.Name = name;
	}

	public string name
	{
		get { return Name; }
	}

	public int id
	{
		get { return Id; }
	}
	
	public void AddOption(DialogueOptions option)
	{
		DialogueListItems.Add(option);
	}
}
