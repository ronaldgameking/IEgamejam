using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int InfectionPoints = 2;

    public Text InfectionPointsTxt; 

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        InfectionPointsTxt.text = InfectionPoints + "";
    }

    public void RemovePoints()
    {
        InfectionPoints--;
        UpdateUI();
    }
}
