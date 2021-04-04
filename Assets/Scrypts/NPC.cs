using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject Pushtext;
    void Start()
    {
        Pushtext = GameObject.Find("NPCDialoge");
        Pushtext.gameObject.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {
            Pushtext.gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
            Pushtext.gameObject.SetActive(false);
    }
}
