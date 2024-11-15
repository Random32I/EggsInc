using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCoup : MonoBehaviour
{
    [SerializeField] GameManager game;
    [SerializeField] SpawnChickens chick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Chicken")
        {
            Chicken chicken = other.GetComponent<Chicken>();
            if (chicken.isEvil)
            {
                game.totalChickens /= 2;
            }
            else
            {
                game.totalChickens++;
            }
            chick.UnspawnChicken(chicken.isEvil, chicken.gameObject);
        }
    }
}
