using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;
    public AudioClip failSound;
    public AudioSource failSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            failSoundSource.clip = failSound;
            failSoundSource.Play();
            deathUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
