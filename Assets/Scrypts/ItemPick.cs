using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    private GameObject Pushtext;
    void Start()
    {
        Pushtext = GameObject.Find("ItemPick");
        Pushtext.gameObject.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {
        Pushtext.gameObject.SetActive(true);
        Destroy(gameObject, 2f);
    }
    void OnTriggerExit(Collider other)
    {
        Pushtext.gameObject.SetActive(false);
    }
}
