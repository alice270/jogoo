using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneBattle : MonoBehaviour
{
    public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
            DestroyGameObject();
            this.enabled = false;
        }
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
