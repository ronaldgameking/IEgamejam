using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionShot : MonoBehaviour
{
    public Image FillImage;
    public float Timer;
    public float RechargeTime = 1;


    private void Awake()
    {
        FillImage.fillAmount = 0;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        FillImage.fillAmount = Mathf.Clamp01(Timer / RechargeTime);
    }

    public void Reset()
    {
        Timer = 0;
        RechargeTime = 1;
    }

    public bool CanShoot()
    {
        if (Timer >= RechargeTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
