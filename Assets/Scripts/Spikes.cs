using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;
    public AudioClip failSound;
    public AudioSource failSoundSource;
    public GameObject player;
    public AudioClip getHurtSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                failSoundSource.clip = failSound;
                failSoundSource.Play();
                deathUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                StartCoroutine(GetHurt());
                failSoundSource.clip = getHurtSoundClip;
                failSoundSource.Play();
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        player.GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        player.GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
