using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue
{
	public Dialogue()
	{

	}

	public List<DialogueNode> DialogueLists;
		
	public void AddNode(DialogueNode dNode)
	{
		DialogueLists.Add(dNode);
	}
}
