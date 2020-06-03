using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EterManager : MonoBehaviour
{
    [Range(0, 500)]
    public int maxEterMutanos = 100;
    [Range(0, 500)]
    public int maxEterBotaniclos = 100;
    [Range(0, 500)]
    public int maxEterIctioniclos = 100;
    [Range(0, 500)]
    public int maxEterMecanos = 100;

    //Variable para indicar la raza actual a la que pertenece el arma
    string currentEter;

    Dictionary<string, int> maxEter = new Dictionary<string, int>();
    Dictionary<string, int> eter = new Dictionary<string, int>();

    void Start()
    {
        List<string> tags = new List<string> { "Mutano", "Botaniclo", "Ictioniclo", "Mecano" };

        maxEter.Add(tags[0], maxEterMutanos);
        maxEter.Add(tags[1], maxEterBotaniclos);
        maxEter.Add(tags[2], maxEterIctioniclos);
        maxEter.Add(tags[3], maxEterMecanos);

        int currentEterMutanos = maxEterMutanos;
        int currentEterBotaniclos = maxEterBotaniclos;
        int currentEterIctioniclos = maxEterIctioniclos;
        int currentEterMecanos = maxEterMecanos;

        eter.Add(tags[0], currentEterMutanos);
        eter.Add(tags[1], currentEterBotaniclos);
        eter.Add(tags[2], currentEterIctioniclos);
        eter.Add(tags[3], currentEterMecanos);

        foreach(string tag in tags)
            EterIndicator.Instance.UpdateEterUI(eter[tag], tag);
    }

    public void IncreaseEter(int value, string tag)
    {
        eter[tag] += value;
        if (eter[tag] > maxEter[tag])
        {
            eter[tag] = maxEter[tag];
        }
        EterIndicator.Instance.UpdateEterUI(eter[tag], tag);
    }

    public void DecreaseCurrentEter(int value)
    {
        eter[currentEter] -= value;
        if (eter[currentEter] < 0)
        {
            eter[currentEter] = 0;
        }
        EterIndicator.Instance.UpdateEterUI(eter[currentEter], currentEter);
    }

    public int GetEter(string tag)
    {
        return eter[tag];
    }

    public string GetCurrentEter()
    {
        return currentEter;
    }

    public void SetCurrentEter(string tag)
    {
        currentEter = tag;
    }

    public bool CanUseEter(int eterQuantity)
    {
        return eter[currentEter] >= Mathf.Abs(eterQuantity);
    }
}
