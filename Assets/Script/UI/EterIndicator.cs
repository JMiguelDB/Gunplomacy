using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EterIndicator : MonoBehaviour
{
    public static EterIndicator Instance { get; private set; }
    public GameObject eterBotaniclo;
    public GameObject highlightEterBotaniclo;
    public GameObject eterIctioniclo;
    public GameObject highlightEterIctioniclo;
    public GameObject eterMutano;
    public GameObject highlightEterMutano;
    public GameObject eterMecano;
    public GameObject highlightEterMecano;

    private Dictionary<string, TextMeshProUGUI> eterUI = new Dictionary<string, TextMeshProUGUI>();
    private Dictionary<string, GameObject> highlightUI = new Dictionary<string, GameObject>();

    private GameObject selectedHighlight = null;
    void Start()
    {
        Instance = this;

        eterUI.Add(eterBotaniclo.tag, eterBotaniclo.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterIctioniclo.tag, eterIctioniclo.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterMutano.tag, eterMutano.GetComponent<TextMeshProUGUI>());
        eterUI.Add(eterMecano.tag, eterMecano.GetComponent<TextMeshProUGUI>());

        highlightUI.Add(eterBotaniclo.tag, highlightEterBotaniclo);
        highlightUI.Add(eterIctioniclo.tag, highlightEterIctioniclo);
        highlightUI.Add(eterMutano.tag, highlightEterMutano);
        highlightUI.Add(eterMecano.tag, highlightEterMecano);
    }

    public void UpdateEterUI(int value, string tag)
    {
        eterUI[tag].text = value.ToString();
    }

    public void HighlightCurrentEter(string tag)
    {
        if (selectedHighlight != null)
            selectedHighlight.SetActive(false);
        highlightUI[tag].SetActive(true);
        selectedHighlight = highlightUI[tag];
    }
}
