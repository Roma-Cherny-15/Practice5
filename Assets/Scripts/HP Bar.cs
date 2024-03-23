using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    private Image HealthImage; // ����� ��� ��������� ��������� �� Image ��'���
    private float HealthCount = 100f;
    public float damageGunBullet;
    public float damageRPGBullet;
    public string gameOverSceneName;

    void Start()
    {
        // ������ ��'��� � ����� "HP" � �������� ��������� �� ���� ��������� Image
        GameObject healthObject = GameObject.FindGameObjectWithTag("HP");
        if (healthObject != null)
        {
            HealthImage = healthObject.GetComponent<Image>();
        }
        else
        {
            Debug.LogError("��'��� � ����� 'HP' �� ��������!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            HealthCount -= damageGunBullet;
            UpdateHealthBar();
        }
        else if (collision.CompareTag("RPGEnemyBullet"))
        {
            HealthCount -= damageRPGBullet;
            UpdateHealthBar();
        }

        CheckHealth();
    }

    void UpdateHealthBar()
    {
        if (HealthImage != null)
        {
            HealthImage.fillAmount = HealthCount / 100f;
        }
        else
        {
            Debug.LogError("��������� �� HealthImage �� ��������!");
        }
    }

    void CheckHealth()
    {
        if (HealthCount <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
