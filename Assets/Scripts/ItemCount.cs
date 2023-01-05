using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount : MonoBehaviour
{

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.ScorePoints();
            Destroy(gameObject);
        }
    }
}
