using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clipPool;


    public void PlayRandom()
    {
        audioSource.clip = clipPool[Random.Range(0, clipPool.Length)];
        Play();
    }

    public void Play()
    {
        audioSource.Play();
    }
}
