using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public float speed = 1.0f;
    private bool isPaused = true;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("point"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(10);
                Debug.Log("+10");
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogError("ScoreManager instance is null.");
            }
        }
        else if (other.CompareTag("ClearObject"))
        {
            GameClear();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartIcons();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.x > -3)
                    this.transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.x < 3.2)
                    this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHeartIcons();

        if (currentHealth <= 0)
        {
            Die();  
        }

        void Die()
        {
            Destroy(this.gameObject);
            GameOver();
        }
    }

    private void UpdateHeartIcons()
    {
        heart1.SetActive(currentHealth >= 1);
        heart2.SetActive(currentHealth >= 2);
        heart3.SetActive(currentHealth >= 3);
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void GameClear()
    {
        ScoreManager.instance.SaveScore();
        SceneManager.LoadScene("GameClear");
    }
    public void GameOver()
    {
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene("GameOver");
    }
}
