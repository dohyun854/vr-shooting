using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
        PlayerPrefs.SetInt("HP",currentHp);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        PlayerPrefs.SetInt("HP",currentHp);
        // Debug.Log("Player HP: " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    private void Die()
    {
        // Debug.Log("Player is dead!");
        SceneManager.LoadScene("RankingScene");

    }
}
