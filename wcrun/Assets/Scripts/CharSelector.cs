using UnityEngine;
using System.Collections;

public class CharSelector : MonoBehaviour {

	public GameObject[] characters;

//	public const int BRAZIL = 0;
//	public const int CROATIA = 1;
//	public const int MEXICO = 2;
//	public const int CAMEROON = 3;
//	public const int SPAIN = 4;
//	public const int NETHERLANDS = 5;
//	public const int CHILE = 6;
//	public const int AUSTRALIA = 7;
//	public const int COLOMBIA = 8;
//	public const int GREECE = 9;
//	public const int COTEDIVOIRE = 10;
//	public const int JAPAN = 11;
//	public const int URUGUAY = 12;
//	public const int COSTARICA = 13;
//	public const int ENGLAND = 14;
//	public const int ITALY = 15;
//	public const int SWITZERLAND = 16;
//	public const int ECUADOR = 17;
//	public const int FRANCE = 18;
//	public const int HONDURAS = 19;
//	public const int ARGENTINA = 20;
//	public const int BOSNIA = 21;
//	public const int IRAN = 22;
//	public const int NIGERIA = 23;
//	public const int GERMANY = 24;
//	public const int PORTUGAL = 25;
//	public const int GHANA = 26;
//	public const int USA = 27;
//	public const int BELGIUM = 28;
//	public const int ALGERIA = 29;
//	public const int RUSSIA = 30;
//	public const int SOUTHKOREA = 31;
	
	public GameObject fetchChar(int charNumber) {
		return characters[charNumber];
	}
}
