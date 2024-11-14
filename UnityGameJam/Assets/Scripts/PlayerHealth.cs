using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth = 100; 
    public Slider healthBar; 
    public TextMeshProUGUI gameOverText;
    private bool isGameOver = false;
    public AudioSource audioSource; 
    public AudioClip soundClip; 

    void Start()
    {
        healthBar.value = (float)currentHealth / maxHealth;
        UpdateHealthBar();
        ShowStart();
        StartCoroutine(HideText());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioSource.Play();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            ShowGameOver();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }

    public void ShowGameOver()
    {
        gameOverText.text = "Game Over! Space Bar to Play Again"; 
        gameOverText.gameObject.SetActive(true); 
        isGameOver = true;
    }

    public void ShowStart()
    {
        gameOverText.text = "Run From The Ghosts!"; 
        gameOverText.gameObject.SetActive(true); 
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(3);
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the game is over and if the space bar is pressed
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false);
        isGameOver = false;
    }

}
