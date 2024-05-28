using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnInterval = 2f; // Küplerin spawn olma süresi
    private PrefabManager prefabManager;
    private GridController gridController;
    private GameManager gameManager;
    private bool isGameOver = false;

    void Start()
    {
        InitializeComponents();
        StartCoroutine(SpawnRoutine());
    }

    private void InitializeComponents()
    {
        prefabManager = FindObjectOfType<PrefabManager>();
        gridController = FindObjectOfType<GridController>();
        gameManager = FindObjectOfType<GameManager>();

        if (prefabManager == null || gridController == null || gameManager == null)
        {
            Debug.LogError("SpawnManager: One or more components are not initialized.");
            isGameOver = true;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (!SpawnNewCube())
            {
                GameOver();
                yield break;
            }
        }
    }

    private bool SpawnNewCube()
    {
        List<Transform> emptySlots = gridController.GetEmptySlots();

        if (emptySlots.Count > 0)
        {
            Transform randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];
            int maxTileValue = gridController.GetMaxTileValue();
            int[] possibleValues = GetPossibleValues(maxTileValue);
            int randomValue = possibleValues[Random.Range(0, possibleValues.Length)];
            GameObject newCube = prefabManager.GetPrefab(randomValue);

            if (newCube != null)
            {
                Instantiate(newCube, randomSlot);
                return true;
            }
        }
        return false;
    }

    private int[] GetPossibleValues(int maxTileValue)
    {
        if (maxTileValue >= 16384) return new int[] { 256, 512, 1024 };
        if (maxTileValue >= 4096) return new int[] { 64, 256, 512 };
        if (maxTileValue >= 1024) return new int[] { 32, 64, 128 };
        if (maxTileValue >= 512) return new int[] { 8, 16, 32 };
        if (maxTileValue >= 256) return new int[] { 4, 8, 16 };
        return new int[] { 2, 4, 8 };
    }

    private void GameOver()
    {
        isGameOver = true;
        gameManager.GameOver();
        //gameOverPanel.SetActive(true);
    }

    public void TriggerPenaltySpawn()
    {
        if (!isGameOver)
        {
            if (!SpawnNewCube())
            {
                GameOver();
            }
        }
    }
}
