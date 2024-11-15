using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameManager game;
    [SerializeField] TextMeshProUGUI multiplier;
    [SerializeField] TextMeshProUGUI eggs;
    [SerializeField] TextMeshProUGUI totalChickens;
    [SerializeField] TextMeshProUGUI money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eggs.text = $"Eggs: {game.eggs}";
        multiplier.text = $"x{Mathf.Floor(game.multiplier * 10)/10}";
        totalChickens.text = $"Chickens: {game.totalChickens}";
        money.text = $"${Mathf.Floor(game.money * 100) / 100}";
    }
}
