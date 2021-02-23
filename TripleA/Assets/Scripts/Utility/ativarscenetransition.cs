using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarscenetransition : MonoBehaviour
{
    public float interactRange = 2;
    public GameObject MudarCena;
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                MudarCena.SetActive(true);
            }
        }
    }
}
