using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstraction of defender type entity holding common attributes and method relavant to all types of defenders
public class Defender : MonoBehaviour
{

    [SerializeField] int cost = 10;

    int xPos, yPos;
    DefenderSpawner defenderSpawner;

    public int GetCost()
    {
        return cost;
    }

    public int GetY()
    {
        return yPos;
    }

    public int GetX()
    {
        return xPos;
    }

    public void SetPos(int x, int y)
    {
        xPos = x;
        yPos = y;
    }

    public void SetSpawner(DefenderSpawner defenderSpawner)
    {
        this.defenderSpawner = defenderSpawner;
    }

    private void OnDestroy()
    {
        defenderSpawner.ClearArrayPos(xPos, yPos);
    }
}
