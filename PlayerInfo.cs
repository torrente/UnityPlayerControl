/*======================================================================
 * PlayerInfo
 * 
 * Programmer: David Torrente
 * 
 * Description: This class contains information for the main player. It
 * holds the data portion of the player, as well as methods to adjust
 * the values. It ties in to the GUI.
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	private int health;
	private int score;
	private int totalAmmunition;
	private int currentAmmunition;
	private int clipSize;
	private int playerNum;
	private string playerName;
	private Rect crossHairPosition;

	public Texture2D crossHairs;
	

	void Start () 
	{
		
		health = 100;
		score = 0;
		totalAmmunition = 20;
		currentAmmunition = 5;
		clipSize = 5;
	}
	
	public void setPlayerName(string playerNameParam)
	{
		playerName = playerNameParam;
	}

	public void setPlayerNum(int playerNumParam)
	{
		playerNum = playerNumParam;
	}

	public int getCurrentAummunition()
	{
		return currentAmmunition;
	}

	public int getClipSize()
	{
		return clipSize;
	}

	public void addPoints(int points)
	{
		score += points;
	}
	
	public void reduceHealth(int damage)
	{
		health -= damage;

		if (health < 1)
		{
			Application.LoadLevel("Defeat");
		}	
	}

	public void addHealth()
	{
		health += 10;
	}

	public void addAmmo()
	{
		totalAmmunition += 10;
	}
	
	public void OnGUI()
	{
		//This will display the crossHairs on the screen. It will remain in the final version.
		//GUI.Label(new Rect(Screen.width/2-22, Screen.height/2 -22, 45, 45), crossHairs);
		GUI.Label(crossHairPosition, crossHairs);

		//The next two lines are placeholders. They need to be replaced in the final version with 
		//something that looks better.
		GUI.Label(new Rect(0,0, 100,80), "HP: " + (health.ToString()));
		GUI.Label (new Rect (0, 100, 100, 80), "Ammo: " + (currentAmmunition.ToString ()));
		GUI.Label(new Rect(Screen.width - 120,0,120,80), "Score: " + (score.ToString ()));
	}


	//used to reduce ammo one shot at a time.
	public void reduceCurrentAmmo()
	{
		currentAmmunition--;
	}


	//Subtract the current clipSize from total.
	public void reduceTotalAmmo()
	{
		totalAmmunition =- clipSize;
	}

	public void placeCrosshairs(int crossHairSetting)
	{
		switch(crossHairSetting)
		{
			case 0:
				crossHairPosition = new Rect (Screen.width / 2 - 22, Screen.height / 2 - 22, 45, 45);
				break;
			case 1:
				crossHairPosition = new Rect (Screen.width / 2 - 22, Screen.height / 4 - 22, 45, 45);
				break;
			case 2:
				crossHairPosition = new Rect (Screen.width / 2 - 22, Screen.height / 2 - 22 + Screen.height / 4, 45, 45);
				break;
			case 3:
				crossHairPosition = new Rect (Screen.width / 4 - 22 , Screen.height / 2 - 22 + Screen.height / 4, 45, 45);
				break;
			case 4:
				crossHairPosition = new Rect (Screen.width / 2 - 22 + Screen.width / 4, Screen.height / 2 - 22 + Screen.height / 4, 45, 45);
				break;
			case 5:
				crossHairPosition = new Rect (Screen.width / 4 - 22, Screen.height / 4 - 22, 45, 45);
				break;
			case 6:
			crossHairPosition = new Rect (Screen.width / 2 - 22 + Screen.width / 4, Screen.height / 2 - 22 - Screen.height / 4, 45, 45);
				break;

		}


	}
		
}
