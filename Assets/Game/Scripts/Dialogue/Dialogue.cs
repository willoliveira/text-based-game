using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue
{
	private string Actual_dialogue_id;
	private Dictionary<string, DialogueNode> DialogDictionary;

	public Dialogue()
	{
		DialogDictionary = new Dictionary<string, DialogueNode>();
	}

	public string actual_dialogue_id
	{
		get { return Actual_dialogue_id; }
		set { Actual_dialogue_id = value; }
	}

	public Dictionary<string, DialogueNode> dialogDictionary
	{
		get { return DialogDictionary; }
		set { DialogDictionary = value; }
	}

	public void AddNode(DialogueNode dNode)
	{
		DialogDictionary.Add(dNode.id, dNode);
	}
}
