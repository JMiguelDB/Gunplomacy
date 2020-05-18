using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EterIndicator : MonoBehaviour
{
    public static EterIndicator Instance { get; private set; }
    public GameObject eterBotaniclo;
    public GameObject eterIctioniclo;
    public GameObject eterMutano;
    public GameObject eterMecano;

    private Dictionary<string, TextMeshProUGUI> eterUI = new Dictionary<string, TextMeshProUGUI>();
    void Start()
    {
        Instance = this;

        eterUI.Add(eterBotaniclo.tag, eterBotaniclo.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterIctioniclo.tag, eterIctioniclo.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterMutano.tag, eterMutano.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterMecano.tag, eterMecano.GetComponent<TextMeshProUGUI>());
    }

    public void UpdateEterUI(int value, string tag)
    {
        eterUI[tag].text = value.ToString();
    }
}
