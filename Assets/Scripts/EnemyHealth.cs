using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour    
{

    //https://www.youtube.com/watch?v=l11fkFoFfrg

    public Image healthBar;
    public float maxHealth = 100.0f;
    public static float health;

    Animator bossAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GetComponent<Image>();
        health = maxHealth;
        bossAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        bossAnimator.SetFloat("BossHealthPercentage", health / maxHealth);

    }


}
