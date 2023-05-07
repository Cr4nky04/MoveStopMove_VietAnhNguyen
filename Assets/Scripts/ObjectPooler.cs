using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public Weapon Prefab;
        public int Size;
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<Weapon>> poolDictionary;
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<Weapon>>();
        foreach (Pool pool in pools)
        {
            Queue<Weapon> objectPool = new Queue<Weapon>();
            for(int i=0; i < pool.Size; i++)
            {
                Weapon obj = Instantiate(pool.Prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.Tag, objectPool);
        }

    }
    public Weapon SpawnWeaponFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        Weapon objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.OnInit();
        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}