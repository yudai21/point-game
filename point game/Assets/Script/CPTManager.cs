using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CPTManager : MonoBehaviour
{
    public TextMeshProUGUI clearText;
    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.instance != null)
        {
            clearText.text = "" + ScoreManager.instance.savedScore.ToString();
        }
    }
}
