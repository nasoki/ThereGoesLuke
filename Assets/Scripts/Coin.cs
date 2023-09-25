using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int scoreValue = 100; // Her coin'in deðeri
    public TextMeshProUGUI scoreText; // Skor metni

    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(scoreValue); // GameManager veya skor yöneticinizin AddScore fonksiyonunu kullanýn

            // Coin'i yok et
            Destroy(gameObject);

            isCollected = true;
        }
    }
}
