using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class SoundOnCollision : MonoBehaviour {

	public float volume = 1.0f;
	public AudioClip soundToPlay;


	void OnCollisionEnter2D() {
		AudioSource.PlayClipAtPoint (soundToPlay ,transform.position, volume);
	}
}
