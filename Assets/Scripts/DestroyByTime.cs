using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;

	void start(){
		Destroy (gameObject, lifetime);
	}
}
