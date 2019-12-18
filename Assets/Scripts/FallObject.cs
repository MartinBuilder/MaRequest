using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour {

    [SerializeField] private float maxFallDepth = -5;
    [SerializeField] private int scoreGain = 100;

    private AudioSource audioSource;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<AudioClip> soundEffects = new List<AudioClip>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
    }

    private void Update() {
        if (transform.position.y < maxFallDepth) {
            ScoreManager.ScoreAdded.Invoke(scoreGain);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(((1 << collision.gameObject.layer) & layerMask) != 0 && !audioSource.isPlaying)
        {
            audioSource.clip = soundEffects[Random.Range(0, soundEffects.Count)];
            audioSource.Play();
        } 
    }

}
