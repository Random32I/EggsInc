using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChickens : MonoBehaviour
{
    [SerializeField] GameObject chicken;
    [SerializeField] GameManager game;
    [SerializeField] Material ChickenGood;
    [SerializeField] Material ChickenBad;
    float timestamp;

    GameObject[] chicks = new GameObject[100];
    int chicksUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject chick = Instantiate(chicken);
            chick.name = "Chicken";
            chick.transform.parent = gameObject.transform;
            chicks[i] = chick;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - timestamp > 0.25f)
        {
            game.ResetMultiplier();
        }

        if (Input.anyKeyDown)
        {
            if (Time.timeSinceLevelLoad - timestamp >= 0.025f)
            {
                if (Time.timeSinceLevelLoad - timestamp <= 0.25f)
                {
                    game.IncreaseMultiplier();
                }
                else
                {
                    game.ResetMultiplier();
                }

                bool isEvil = false;
                switch (Random.Range(0, 50))
                {
                    case 0:
                        isEvil = true;
                        break;
                    default:
                        isEvil = false;
                        break;
                }

                SpawnChicken(isEvil, chicks[chicksUsed]);
                timestamp = Time.timeSinceLevelLoad;
            }
        }
    }

    void SpawnChicken(bool isEvil, GameObject chick)
    {
        if (!chick.activeSelf)
        {
            chick.SetActive(true);
            chick.GetComponent<Chicken>().isEvil = isEvil;
            if (isEvil) chick.GetComponent<Renderer>().material = ChickenBad;
            chick.transform.position = new Vector3(9, 0.5f, 12);
            chicksUsed++;
            if (chicksUsed == 100) chicksUsed = 0;
        }
    }

    public void UnspawnChicken(bool isEvil, GameObject chick)
    {
        if (isEvil)
        { 
            chick.GetComponent<Chicken>().isEvil = false;
            chick.GetComponent<Renderer>().material = ChickenGood;
        }
        chick.SetActive(false);
    }

}
