using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int eggs;
    public int totalChickens;
    public float multiplier = 1;
    public float money = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eggs += Mathf.RoundToInt(totalChickens * multiplier);
        money = eggs * 0.02f;
    }

    public void IncreaseMultiplier()
    {
        multiplier += 0.1f;
    }

    public void ResetMultiplier()
    {
        multiplier = 1;
    }
}
