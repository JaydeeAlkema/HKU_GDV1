﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class UIManager
{
	/// <summary> This is the dictionary that keeps track of all the text UI elements in the game </summary>
	public static Dictionary<string, TextMeshProUGUI> UI_TEXT_ELEMENTS = new Dictionary<string, TextMeshProUGUI>();

	/// <summary> This is the canvas on which the UI elements get put on </summary>
	public static GameObject Canvas { get; set; }

	/// <summary>
	/// This gets the main canvas in the scene
	/// </summary>
	public static void FindCanvas()
	{
		Canvas = GameObject.FindObjectOfType<Canvas>().gameObject;
	}

	/// <summary>
	/// Generates a piece of text on a position given by the user
	/// </summary>
	/// <param name="position"></param>
	/// <param name="text"></param>
	/// <param name="editorName"></param>
	/// <param name="parent"></param>
	/// <param name="fontSize"></param>
	public static void AddTextUIElement(Vector2 position, string text, string editorName, Transform parent, float fontSize)
	{
		GameObject uiElementGO = new GameObject();
		TextMeshProUGUI txt = uiElementGO.AddComponent<TextMeshProUGUI>();
		RectTransform rTransform = uiElementGO.GetComponent<RectTransform>();
		if(parent != null)
		{
			uiElementGO.transform.SetParent(parent.transform);
			rTransform.localPosition = position;
		}
		else
		{
			Debug.LogError("UIManager can't add UI element without a canvas as its parent");
		}
		UI_TEXT_ELEMENTS.Add(editorName, txt);
		txt.fontSize = fontSize;
		txt.text = text;
	}

	/// <summary>
	/// Updates a text element with new text (for instance updating score)
	/// </summary>
	/// <param name="textMesh"></param>
	/// <param name="newText"></param>
	public static void UpdateUITextElement(TextMeshProUGUI textMesh, string newText)
	{
		textMesh.text = newText;
	}
}
