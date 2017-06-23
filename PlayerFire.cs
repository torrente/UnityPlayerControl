/*======================================================================
 * PlayerFire
 * 
 * Programmer : David Torrente
 * 
 * Description: This class controls the firing mechanism for the gun.
 * It checks to make sure there is ammunition in the gun, and then
 * casts a ray to fire. It also holds the controls for reloading the
 * gun.
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {
	
	
	private RaycastHit objHit;
	private float fireRate;
	private float nextShot;
	private int damage;
	private float range;
	private PlayerInfo playerInfo;
	private MuzzleBlast muzzleBlast;
	private bool reloading;
	private float reloadTime;

	private AudioSource audioSource;

	public AudioClip shotGunBlastSound;
	public AudioClip reloadSound;
	public AudioClip emptyClipSound;

	public GameObject muzzleBlastObj;
	public int playerNum;

	private EnemyInfo enemyInfo;

	void Start () 
	{
		playerInfo = GetComponentInParent<PlayerInfo> ();
		muzzleBlast = muzzleBlastObj.GetComponent<MuzzleBlast> ();
		audioSource = GetComponent<AudioSource> ();
		damage = 30;
		nextShot = 0F;
		fireRate = 1F;
		range = 100F;
		reloadTime = 2F;
		reloading = false;
	}
	
	void Update () 
	{
		if (Input.GetAxis ("Fire" + playerNum) != 0 && Time.time > nextShot)
			{
				fire();
			}

		if(Input.GetAxis("Reload" + playerNum) != 0 && playerInfo.getCurrentAummunition() != playerInfo.getClipSize())
			{
				StartCoroutine(reload());
			}
	}
		
	void fire()
	{
			playerInfo.reduceCurrentAmmo ();
			audioSource.PlayOneShot (shotGunBlastSound);
			nextShot = Time.time + fireRate;
			muzzleBlast.enabled = true;
			StartCoroutine (muzzleBlast.cycleMuzzleBlast ());

			int scoreChange = 0; 
			
			Debug.DrawRay(transform.position, transform.forward*range, Color.green);	

			if (Physics.Raycast(transform.position, transform.forward, out objHit, range))
			{
					
				Debug.DrawRay(transform.position, transform.forward*range, Color.red);	
				
				
				if (objHit.collider.gameObject.tag == "Enemy")
				{
					enemyInfo = objHit.collider.gameObject.GetComponentInParent<EnemyInfo> ();

					scoreChange = enemyInfo.reportHit (damage, objHit.point);

					if ( scoreChange != 0)
					{
						playerInfo.addPoints (scoreChange);
						enemyInfo.death (objHit.point);
					}
					
				}
			}
		
	}//END fire

	private IEnumerator reload()
	{
		audioSource.PlayOneShot (reloadSound);
		reloading = true;
		yield return new WaitForSeconds (reloadTime);
		reloading = false;
	}


	

}
			