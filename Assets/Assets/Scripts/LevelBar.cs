using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class LevelBar : MonoBehaviour
{
    public int minimum;
    public int maximum = 100;
    public int current;
    private float fillAmount;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        current = PlayerPrefs.GetInt("LevelBar", 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill() ;
    }

    public void GetCurrentFill() 
    {
        LevelManager levelManager = LevelManager.instance;
        if (levelManager != null)
        {
        current = levelManager.pts;
        }
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset/maximumOffset;
        
        mask.fillAmount = fillAmount;
        PlayerPrefs.SetInt("LevelBar", current);
        PlayerPrefs.Save();
    }
}
