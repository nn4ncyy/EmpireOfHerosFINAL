using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void UpdateHealthBar(float cur, float max)
    {
        slider.value = cur / max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
