using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    [SerializeField] bool isPressed = false;

    Color originalColor;

    //Cached reference
    DefenderSpawner spawner;
    TextMeshProUGUI costText;

    private void OnMouseDown()
    {
        SetCurrent();
    }

    private void SetCurrent()
    {
        if (!isPressed)
        {
            DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

            foreach (DefenderButton button in buttons)
            {
                button.TurnOff();
            }

            TurnOn();
        }
    }

    private void TurnOff()
    {
        isPressed = false;
        GetComponent<SpriteRenderer>().color = Color.grey;
        costText.color = Color.grey;
    }

    private void TurnOn()
    {
        isPressed = true;
        spawner.SetDefender(defenderPrefab);
        GetComponent<SpriteRenderer>().color = originalColor;
        costText.color = originalColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        originalColor = new Color(originalColor.r, originalColor.g, originalColor.b);

        costText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateCostText();

        spawner = FindObjectOfType<DefenderSpawner>();

        if (!isPressed)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }

    }

    private void UpdateCostText()
    {
        costText.text = defenderPrefab.GetCost().ToString();
    }
}
