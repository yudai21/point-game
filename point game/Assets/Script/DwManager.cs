using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwManager : MonoBehaviour
{
    public int damageAmount = 0;
    public float speed =1.0f;
    private Rigidbody2D myRigid;
    private bool isPaused = true;
    private Vector3 startPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.TakeDamage(damageAmount);
                Debug.Log("aaaaa");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
        if (!isPaused)
        {
            ResumeStart();
        }
    }

    public void Pause()
    {
        isPaused = true;
    }
    
    public void Resume()
    {
        isPaused = false;
        ResumeStart();
    }

    private void ResumeStart()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        myRigid.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
}
