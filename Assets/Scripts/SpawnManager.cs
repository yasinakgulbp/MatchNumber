using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnInterval = 2f; // Küplerin spawn olma süresi
    private PrefabManager prefabManager;
    private GridController gridController;

    void Start()
    {
        prefabManager = FindObjectOfType<PrefabManager>();
        gridController = FindObjectOfType<GridController>();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnNewCube();
        }
    }

    private void SpawnNewCube()
    {
        List<Transform> emptySlots = gridController.GetEmptySlots();

        if (emptySlots.Count > 0)
        {
            Transform randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];
            int[] possibleValues = { 16, 32, 64 };
            int randomValue = possibleValues[Random.Range(0, possibleValues.Length)];
            GameObject newCube = prefabManager.GetPrefab(randomValue);

            if (newCube != null)
            {
                Instantiate(newCube, randomSlot);
            }
        }
    }
}
