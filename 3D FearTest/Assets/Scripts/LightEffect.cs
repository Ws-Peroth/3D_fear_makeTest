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

    private void Start()
    {
        changeCount = 0;
        lightCondition = 0;
        maxRange = 60.0f;
        minRange = 37.0f;
        light.range = maxRange;
    }

    void Update()
    {
        if (lightCondition == 0)
        {
            targetRange = Random.Range(minRange, maxRange);
            lightCondition = light.range <= targetRange ? 1 : -1;
            changeCount++;
        }

        if(lightCondition == 1)
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

        if(changeCount == 10)
        {
            light.range = minRange;
            lightCondition = 2;
        }
    }
}
