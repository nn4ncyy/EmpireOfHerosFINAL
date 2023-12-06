using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class HomeLevel : MonoBehaviour
{
    public int minimum;
    public int maximum;
    //public int current;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {

        int current = PlayerPrefs.GetInt("LevelBar", 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
