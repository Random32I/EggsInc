using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    float accuracyCost = 1;
    int accuracyLevel = 0;

    float speedCost = 1;
    int speedLevel = 0;

    [SerializeField] GameManager game;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyAccuracy()
    {
        if (accuracyLevel < 13)
        {
            if (game.money >= accuracyCost)
            {
                game.money -= accuracyCost;
                accuracyLevel++;
                accuracyCost = Mathf.Pow(3, accuracyLevel);
                price.text = $"${accuracyCost - 1}.99";
                turret.accuarcy--;
            }
        }
    }

    public void BuySpeed()
    {
        if (accuracyLevel < 8)
        {
            if (game.money >= speedCost)
            {
                game.money -= speedCost;
                speedLevel++;
                speedCost = Mathf.Pow(3, speedLevel);
                price.text = $"${speedCost - 1}.99";
                turret.cooldown -= 0.1f;
            }
        }
    }
}
