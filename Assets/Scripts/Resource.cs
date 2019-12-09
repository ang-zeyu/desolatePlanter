using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    [SerializeField] int initialResources = 20;

    int resources;

    //Cached Reference
    TextMeshProUGUI textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        resources = initialResources;
        textDisplay = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void IncResources(int amt)
    {
        resources += amt;
        UpdateText();
    }

    public void DecResources(int amt)
    {
        resources -= amt;
        UpdateText();
    }

    public bool IsEnough(int cost)
    {
        return resources >= cost;
    }

    public void FlashError()
    {
        StartCoroutine(FlashErrorRoutine());
    }

    IEnumerator FlashErrorRoutine()
    {
        Color color = textDisplay.color;
        textDisplay.color = Color.red;
        yield return new WaitForSeconds(1);
        textDisplay.color = color;
    }

    private void UpdateText()
    {
        textDisplay.text = resources.ToString();
    }
}
