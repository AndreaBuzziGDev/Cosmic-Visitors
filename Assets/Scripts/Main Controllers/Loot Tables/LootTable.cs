using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    //DATA
    [SerializeField] List<Crate> lootCrateList = new List<Crate>();
    [SerializeField] float LootChancePercentage = 1.0f;//WON'T DO ANYTHING BENEFICIAL ABOVE 100.0f

    //METHODS
    public Crate getRandomLootCrate()
    {
        int randomChance = Random.Range(0, 100);

        //RANDOM
        Crate result = null;
        if (randomChance < LootChancePercentage)
        {
            if (lootCrateList.Count > 0) result = lootCrateList[Random.Range(0, lootCrateList.Count)];
        }

        return result;
    }

}
