using UnityEngine;
using System.Collections;

public class CharacterClass
{
	public string CharacterName;
	public int Attack;
	public int HP;
	public int Distance;
	public bool D_or_A;


	public void InitAttack()
	{
		Attack = 10;
		Debug.Log (Attack);
	}
}
