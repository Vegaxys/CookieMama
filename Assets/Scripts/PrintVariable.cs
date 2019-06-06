using UnityEngine;
using TMPro;

public class PrintVariable : MonoBehaviour
{
    public Ressources_Manager ressourceManager;
    public string textToAdd;
    TextMeshProUGUI text;
    public string var;
    int value;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        value = (int)ressourceManager.GetType().GetField(var).GetValue(ressourceManager);
        SetDisplay(value, text, textToAdd);
        Debug.Log(value);
    }

    void SetDisplay(int varToPrint, TextMeshProUGUI text, string textToAdd)
    {
        text.text = textToAdd + " " + varToPrint.ToString();
    }
}
