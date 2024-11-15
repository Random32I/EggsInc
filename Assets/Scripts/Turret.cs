using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{ 
    public int accuarcy = 15;
    public float cooldown = 1;
    [SerializeField] SpawnChickens chickens;

    float timestamp;

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
            if (Time.timeSinceLevelLoad - timestamp >= cooldown)
            {
                Chicken chick = other.GetComponent<Chicken>();
                bool hit;

                if (chick.isEvil)
                {
                    hit = Random.Range(0, Mathf.FloorToInt(accuarcy/4)) == 0;
                }
                else
                {
                    hit = Random.Range(0, accuarcy) != 0;
                }

                if (hit) chickens.UnspawnChicken(chick.isEvil, other.gameObject);
                timestamp = Time.timeSinceLevelLoad;
            }
        }
    }
}
