using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Abstraction of enemy spawner for spawning enemies, 
//and providing utility methods to determine whether a enemy exists in a lane. (refactor to new utility class maybe)
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Parameters")]
    [SerializeField] float minBaseSpawnInterval = 1f;
    [SerializeField] float maxBaseSpawnInterval = 3f;
    [SerializeField] Attacker[] attackerTypes;
    [SerializeField] int numLanes = 5;

    int[] attackersSpawned;
    int totalAttackers = 0;

    bool doSpawn = true;

    //Cached reference
    LevelController level;
    GameObject enemies;

    IEnumerator Start()
    {
        level = FindObjectOfType<LevelController>();
        enemies = new GameObject("Enemies");
        attackersSpawned = new int[numLanes + 1];
        minBaseSpawnInterval /= PlayerPrefsController.GetDifficulty();
        maxBaseSpawnInterval /= PlayerPrefsController.GetDifficulty();

        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(minBaseSpawnInterval, maxBaseSpawnInterval));

            if (doSpawn)
            {
                int yCoord = Random.Range(1, 6);
                int xCoord = 10;
                
                SpawnAttacker(xCoord, yCoord);
                
            }
        }
    }

    private void SpawnAttacker(int xCoord, int yCoord)
    {
        Attacker attacker = Object.Instantiate(
                    attackerTypes[Random.Range(0, attackerTypes.Length)],
                    new Vector3(xCoord, yCoord, -1),
                    Quaternion.identity);

        attacker.SetLane(yCoord);

        //inc lane count 
        attackersSpawned[yCoord]++;
        //and total attacker count
        totalAttackers++;
        level.SetEnemiesLeft(totalAttackers);

        attacker.transform.parent = enemies.transform;
    }

    public int GetAttackersInLane(int laneNum)
    {
        return attackersSpawned[laneNum];
    }

    public void DecAttackersInLane(int laneNum)
    {
        attackersSpawned[laneNum]--;
        totalAttackers--;
        level.SetEnemiesLeft(totalAttackers);
    }

    public void TurnSpawnOff()
    {
        doSpawn = false;
    }
}
