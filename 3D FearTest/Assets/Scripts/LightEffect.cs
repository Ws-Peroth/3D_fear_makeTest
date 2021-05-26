using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightEffect : MonoBehaviour
{
    public float maxRange;
    public float minRange;
    public float targetRange;
    public int lightCondition;
    public int changeCount;
    public Light light;
    
    public Light classMoonLight01;
    public Light classMoonLight02;
    public Light classMoonLight03;
    public Light classMoonLight04;

    private void Start()
    {
        changeCount = 0;
        lightCondition = 0;
        maxRange = 80.0f;
        minRange = 50.0f;
        light.range = maxRange;

        classMoonLight01.gameObject.SetActive(true);
        classMoonLight02.gameObject.SetActive(true);
        classMoonLight03.gameObject.SetActive(true);
        classMoonLight04.gameObject.SetActive(true);
    }

    int LightChangeEffect()
    {
        if (lightCondition == 3) return 1;

        if (lightCondition == 0)
        {
            targetRange = Random.Range(minRange, maxRange);
            lightCondition = light.range <= targetRange ? 1 : -1;
            changeCount++;
        }

        if (lightCondition == 1)
        {
            light.range += Random.Range(0.1f, 0.01f);

            if (light.range >= targetRange)
                lightCondition = 0;
        }
        if (lightCondition == -1)
        {
            light.range -= Random.Range(0.1f, 0.01f);

            if (light.range <= targetRange)
                lightCondition = 0;
        }
        if (lightCondition == 2)
        {
            light.range--;
            if (light.range - 1.0f < 0.0f)
            {
                light.range = 0f;
                lightCondition = 3;
            }
        }
        if (changeCount == 10)
        {
            light.range--; ;
            lightCondition = 2;
        }
        return 0;
    }

    void MoonLightControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            classMoonLight01.gameObject.SetActive(!classMoonLight01.gameObject.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            classMoonLight02.gameObject.SetActive(!classMoonLight02.gameObject.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            classMoonLight03.gameObject.SetActive(!classMoonLight03.gameObject.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            classMoonLight04.gameObject.SetActive(!classMoonLight04.gameObject.activeSelf);
    }

    void Update()
    {
        LightChangeEffect();
        MoonLightControl();
    }
}
