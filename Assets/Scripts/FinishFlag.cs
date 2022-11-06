using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{

    public GameManager gameManager;
    void OnTriggerEnter()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        gameManager.CompleteLevel();
        GetComponent<CapsuleCollider>().enabled = true;

    }
}
