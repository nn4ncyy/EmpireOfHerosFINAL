using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowLevel : MonoBehaviour
{
    public string textValue = "LEVEL: ";
    public TextMeshProUGUI textElement;

    void Update()
    {
        UpdateLevelDisplay();
    }
    
    public void UpdateLevelDisplay()
    {
        LevelManager levelManager = LevelManager.instance;
        if (levelManager != null)
        {
            textElement.text = textValue + levelManager.level.ToString();
            //Debug.Log("Score updated to: " + scoreManager.score);
        }
    }

}
