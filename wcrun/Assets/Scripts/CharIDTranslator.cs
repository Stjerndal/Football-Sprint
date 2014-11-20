using UnityEngine;
using System.Collections;

public class CharIDTranslator : MonoBehaviour {

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

	string[] countries;

	// Use this for initialization
	void Start () {
		countries = new string[32];

//		countries[0] = "BRAZIL";
//		countries[1] = "CROATIA";
//		countries[2] = "MEXICO";
//		countries[3] = "CAMEROON";
//		countries[4] = "SPAIN";
//		countries[5] = "NETHERLANDS";
//		countries[6] = "CHILE";
//		countries[7] = "AUSTRALIA";
//		countries[8] = "COLOMBIA";
//		countries[9] = "GREECE";
//		countries[10] = "COTEDIVOIRE";
//		countries[11] = "JAPAN";
//		countries[12] = "URUGUAY";
//		countries[13] = "COSTARICA";
//		countries[14] = "ENGLAND";
//		countries[15] = "ITALY";
//		countries[16] = "SWITZERLAND";
//		countries[17] = "ECUADOR";
//		countries[18] = "FRANCE";
//		countries[19] = "HONDURAS";
//		countries[20] = "ARGENTINA";
//		countries[21] = "BOSNIA";
//		countries[22] = "IRAN";
//		countries[23] = "NIGERIA";
//		countries[24] = "GERMANY";
//		countries[25] = "PORTUGAL";
//		countries[26] = "GHANA";
//		countries[27] = "USA";
//		countries[28] = "BELGIUM";
//		countries[29] = "ALGERIA";
//		countries[30] = "RUSSIA";
//		countries[31] = "SOUTHKOREA";

		countries[0] = "BRA";
		countries[1] = "CRO";
		countries[2] = "MEX";
		countries[3] = "CMR";
		countries[4] = "ESP";
		countries[5] = "NED";
		countries[6] = "CHI";
		countries[7] = "AUS";
		countries[8] = "COL";
		countries[9] = "GRE";
		countries[10] = "CIV";
		countries[11] = "JPN";
		countries[12] = "URU";
		countries[13] = "CRC";
		countries[14] = "ENG";
		countries[15] = "ITA";
		countries[16] = "SUI";
		countries[17] = "ECU";
		countries[18] = "FRA";
		countries[19] = "HON";
		countries[20] = "ARG";
		countries[21] = "BIH";
		countries[22] = "IRN";
		countries[23] = "NGA";
		countries[24] = "GER";
		countries[25] = "POR";
		countries[26] = "GHA";
		countries[27] = "USA";
		countries[28] = "BEL";
		countries[29] = "ALG";
		countries[30] = "RUS";
		countries[31] = "KOR";
	}

	public string translate(int charID) {
		return countries[charID];
	}
}
