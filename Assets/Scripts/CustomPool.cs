using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomPool<T> where T : MonoBehaviour
{
    T prefab;
    List<T> pool = new();
    Transform objectParent;
    public CustomPool(T prefab, int prewarmObjects, Transform parent)
    {
        this.prefab = prefab;
        objectParent = parent;

        for(int i = 0; i < prewarmObjects; i++)
        {
            var obj = GameObject.Instantiate(prefab, objectParent);
            pool.Add(obj);
            obj.gameObject.SetActive(false);
        }
    }
    
    public T Get()
    {
        T obj = pool.FirstOrDefault(x => !x.gameObject.activeInHierarchy);

        if (obj == null)
        {
            Add();
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    public void Realese(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    T Add()
    {
        T obj = null;
        
        for(int i = 0; i < 10; i++)
        {
            var poolObj = GameObject.Instantiate(prefab, objectParent);

            if (obj == null)
            {
                obj = poolObj;
            }
            pool.Add(poolObj);

        }

        return obj;
    }
}
