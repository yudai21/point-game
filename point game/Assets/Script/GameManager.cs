using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int countdownTime = 3;
    public TextMeshProUGUI countdownText;
    public List<PlayerManager> playerManagers;
    public List<DwManager> dWManagers;
    public List<PointManager> pointManagers;
    public List<ClaerObjectManager> claerObjectManagers;
    private bool countdownStarted = true;
    void Start()
    {
        StartCountdown();
    }

    void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

        IEnumerator CountdownCoroutine()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }

        countdownText.text = "";

        foreach (PlayerManager playerManager in playerManagers)
        {
            playerManager.Resume();
        }
        foreach (DwManager dwManager in dWManagers)
        {
            dwManager.Resume();
        }
        foreach (PointManager pointManager in pointManagers)
        {
            pointManager.Resume();
        }
        foreach (ClaerObjectManager claerObjectManager in claerObjectManagers)
        {
            claerObjectManager.Resume();
        }
    }
}
