using UnityEngine;
using System.Collections;

public class HoverHighlighter : MonoBehaviour {

	public Texture2D btnNormal;
	public Texture2D btnHover;
	
	
	void OnMouseEnter() {
		guiTexture.texture = btnHover;
	}
	
	void OnMouseExit() {
		guiTexture.texture = btnNormal;
	}

}
