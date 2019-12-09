using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender selectedDefender;
    GameObject defenderParent;
    bool[,] isFilled;

    //Cached reference
    Resource resourceManager;

    private void Start()
    {
        defenderParent = new GameObject("Defenders");
        SetUpFilledArray();
        resourceManager = FindObjectOfType<Resource>();
    }

    private void SetUpFilledArray()
    {
        Vector2 size = GetComponent<BoxCollider2D>().bounds.extents;
        
        isFilled = new bool[Mathf.RoundToInt(size.x * 2), Mathf.RoundToInt(size.y * 2)];
    }

    public void ClearArrayPos(int x, int y)
    {
        isFilled[x - 1, y - 1] = false;
    }

    private void OnMouseDown()
    {
        int cost = selectedDefender.GetCost();

        Vector3 defenderPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        defenderPos.x = Mathf.Round(defenderPos.x);
        defenderPos.y = Mathf.Round(defenderPos.y);
        defenderPos.z = -1;

        if (resourceManager.IsEnough(cost) && 
            !isFilled[Mathf.RoundToInt(defenderPos.x - 1), Mathf.RoundToInt(defenderPos.y - 1)])
        {
            resourceManager.DecResources(cost);
            SpawnCurrentDefender(defenderPos);
        }
        else
        {
            resourceManager.FlashError();
        }
    }

    private void SpawnCurrentDefender(Vector3 defenderPos)
    {
        Defender defender = Instantiate(
            selectedDefender,
            defenderPos,
            Quaternion.identity);

        defender.SetPos((int)defenderPos.x, (int)defenderPos.y);
        defender.SetSpawner(this);
        isFilled[Mathf.RoundToInt(defenderPos.x - 1), Mathf.RoundToInt(defenderPos.y - 1)] = true;
        defender.transform.parent = defenderParent.transform;
    }

    public void SetDefender(Defender defender)
    {
        selectedDefender = defender;
    }
}
