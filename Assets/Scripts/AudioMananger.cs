using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
	public AudioClip[] audioClips; // Array de pistas de audio

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// Reproducir una pista de audio
	public void PlayAudio(int index)
	{
		GetComponent<AudioSource>().clip = audioClips[index];
		GetComponent<AudioSource>().Play();
	}
}
