/*======================================================================
 * MuzzleBlast
 * 
 * Programmer: David Torrente
 * 
 * Description: This class controls the graphical representation of the
 * muzzle blast itself. It contains a method that may be called
 * asynchonously. As this is simply a visual element, its current
 * state does not effect the main system. It is enabled/disabled
 * to control the Update method which cycles the muzzle animation.
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class MuzzleBlast : MonoBehaviour {
	
	float offSet;
	public float delay;
	Renderer renderer;
	public GameObject muzzleLight;

	void Start () 
	{
		delay = .2F;
		offSet = 0F;
		renderer = GetComponent<Renderer>();
		muzzleLight.SetActive (false);
		renderer.enabled = false;
		enabled = false;
	}
		
	public IEnumerator cycleMuzzleBlast()
	{
		muzzleLight.SetActive (true);
		yield return new WaitForSeconds(delay);
		offSet = 0F;
		renderer.enabled = false;
		enabled = false;
		muzzleLight.SetActive (false);
	}


	//This update is not to be constantly called. It is toggled as enabled/disabled
	//as it is used to show the muzzle flash animation. It typically remains enabled
	//while cycleMuzzleBlast is running.
	void Update()
	{
		renderer.enabled = true;
		offSet += .2F;
		renderer.material.mainTextureOffset = new Vector2 (offSet, 0F);
	}
	
	
}
