using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject itemPrefab16;
    public GameObject itemPrefab32;
    public GameObject itemPrefab64;
    public GameObject itemPrefab128;
    public GameObject itemPrefab256;
    public GameObject itemPrefab512;
    public GameObject itemPrefab1024;
    public GameObject itemPrefab2048;
    public GameObject itemPrefab4096;
    public GameObject itemPrefab8192;
    public GameObject itemPrefab16000;
    public GameObject itemPrefab32000;
    public GameObject itemPrefab65000;

    private Dictionary<int, GameObject> prefabDictionary;

    void Awake()
    {
        prefabDictionary = new Dictionary<int, GameObject>
        {
            { 16, itemPrefab16 },
            { 32, itemPrefab32 },
            { 64, itemPrefab64 },
            { 128, itemPrefab128 },
            { 256, itemPrefab256 },
            { 512, itemPrefab512 },
            { 1024, itemPrefab1024 },
            { 2048, itemPrefab2048 },
            { 4096, itemPrefab4096 },
            { 8192, itemPrefab8192 },
            { 16384, itemPrefab16000 },
            { 32768, itemPrefab32000 },
            { 65536, itemPrefab65000 }
        };
    }

    public GameObject GetPrefab(int value)
    {
        prefabDictionary.TryGetValue(value, out var prefab);
        return prefab;
    }
}
