using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Tools
{
	public class Hotkeys : Editor
	{
		[MenuItem("Tools/Item %g")]
		static public void Group()
		{
			for(int i = 0; i < Selection.gameObjects.Length; i++)
			{
				GameObject group = new GameObject("Generated At Zero");
				group.transform.parent = Selection.gameObjects[i].transform.parent;
				Selection.gameObjects[i].transform.SetParent(group.transform, true);
			}
		}
	}
}
