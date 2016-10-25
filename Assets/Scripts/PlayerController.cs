using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float tilt;
	public Boundary boundary;
	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private AudioSource audioSource;

	public GameObject bigShot;
	public Transform bigShotSpawn;
	public float BigFireRate;
	private float BigNextFire;
	//private AudioSource BigaudioSource;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		float boom = 3.0f;

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			//add sound
			audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("a") || Input.GetKeyDown ("Fire3")){
			BigNextFire = Time.time + BigFireRate;
			Instantiate (bigShot, bigShotSpawn.position, bigShotSpawn.rotation);
			/*
			boom -= Time.deltaTime;
			if (boom <= 0) {
				Instantiate (bigShot, bigShotSpawn.position , bigShotSpawn.rotation);
				Instantiate (bigShot, bigShotSpawn.position , bigShotSpawn.rotation);

			}
			*/
			//add sound
			audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
		}
			
	}

	void BigShotFire(){
		
	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed; 
		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);	
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.angularVelocity.x * - tilt); 
	}
}
