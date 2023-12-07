using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int level = 0;
    public int pts = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { Destroy(gameObject); }

        // Retrieve the score from PlayerPrefs when the game starts
        level     = PlayerPrefs.GetInt("Level", 0);
        pts     = PlayerPrefs.GetInt("pts", 0);

    }
    

    public void AddEXP(int exp)
    {
        pts += exp;
        if(pts>=100){
            level +=1;
            pts-=100;
        }
        SavePts();
        SaveLevel();
    }

    // Add a method to save the score to PlayerPrefs
    public void SaveLevel()
    {
        PlayerPrefs.SetInt("Level", level);

        PlayerPrefs.Save();
    }

    public void SavePts()
    {
        PlayerPrefs.SetInt("pts", pts);

        PlayerPrefs.Save();
    }
    
    public void ResetScore()
    {
        level     = 0;
        SaveLevel(); // Save the reset score to PlayerPrefs
    }

}
