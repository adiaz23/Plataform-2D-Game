using UnityEngine;
using System.Collections.Generic;
using System;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsPrefabs = new List<GameObject>();
    [SerializeField] private int probabilityWindow = 35;

    public void DropItems()
    {
        if (itemsPrefabs.Count > 0)
        {
            foreach (GameObject item in itemsPrefabs)
            {
                System.Random generator = new();
                int randomChance = generator.Next(0, 100);
                if (randomChance < probabilityWindow)
                    Instantiate(item, transform.position, Quaternion.identity);
            }
        }
    }

}
