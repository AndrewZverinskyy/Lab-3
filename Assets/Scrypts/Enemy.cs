using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    private GameObject Pushtext;
    void Start()
    {
        Pushtext = GameObject.Find("EnemyBattle");
        Pushtext.gameObject.SetActive(false);
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("Death", false);
    }
    void OnTriggerEnter(Collider other)
    {
        Pushtext.gameObject.SetActive(true);
        enemyAnimator.SetBool("Death", true);
    }
    void OnTriggerExit(Collider other)
    {
        Pushtext.gameObject.SetActive(false);
        Destroy(gameObject, 5f);
    }
}