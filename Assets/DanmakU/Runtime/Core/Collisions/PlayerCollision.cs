using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;
using DanmakU;

public class PlayerCollision : MonoBehaviour
{

    private int currentHealth = 6;
    private int maxHealth = 6;

    private bool isInvincible = false;

    [SerializeField]
    private float invincibilityDurationSeconds = 1.0f;

    [SerializeField]
    private float invincibilityDeltaTime = 0.1f;

    [SerializeField]
    private GameObject model;

    public GameObject player;

    public GameObject[] health;
    public GameObject deathGraphic;

    public Sprite ghostSprite;
    private SpriteRenderer spriteRenderer;

    public AudioSource playerHitAudioSource;
    public AudioSource playerDeathAudioSource;
    public AudioSource aliveMusicAudioSource;
    public AudioSource deadMusicAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;

    }

    void Update()
    {

        if (currentHealth <= 0)
            if (Input.GetKeyDown(KeyCode.Y)) {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.N)) {
                SceneManager.LoadScene(0);
                //Application.Quit();
            }
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        //Debug.Log("Hello");
        if (isInvincible == false && currentHealth > 0) {
            Debug.Log(collisionList[0].ToString());
            LoseHealth(1);
            StartCoroutine(BecomeTemporarilyInvincible());
            playerHitAudioSource.Play();
        }

    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale.x == 1)
            {
                ScaleModelTo(Vector2.zero);
            }
            else
            {
                ScaleModelTo(Vector2.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector2.one);
        isInvincible = false;
    }


    void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private void ScaleModelTo(Vector2 scale)
    {
        model.transform.localScale = scale;
    }


    public void LoseHealth(int amount)
    {
        if (currentHealth <=0) return;

        currentHealth -= amount;
        UpdateHealthGraphic();

        // The player died
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Broadcast some sort of death event here before returning
            Debug.Log("Player died");
            playerDeathAudioSource.Play();
            aliveMusicAudioSource.Stop();
            deadMusicAudioSource.Play();
            //Destroy(player);

            deathGraphic.SetActive(true);

            model.GetComponent<SpriteRenderer>().sprite = ghostSprite;
            //spriteRenderer.sprite = ghostSprite;

            return;
        }
    }

    public void UpdateHealthGraphic()
    {
        for (int i = 0; i < currentHealth; i++)
        {
            health[i].SetActive(true);
        }

        for (int i=0; i < maxHealth - currentHealth; i++)
        {
            health[i].SetActive(false);
        }

    }





}
