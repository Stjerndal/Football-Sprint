using UnityEngine;
using System.Collections;

public class FlagSelector : MonoBehaviour {

	public Texture[] flags;

	public Texture getFlag(int charNr) {
		return flags[charNr];
	}
}
