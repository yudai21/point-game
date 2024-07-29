using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaerObjectManager : MonoBehaviour
{
    private bool isPaused = true;
    public float speed = 1.0f;
    private Rigidbody2D myRigid;
    
    void Start()
    {
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
