using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int InfectionPoints = 2;

    public Text InfectionPointsTxt; 

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
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
