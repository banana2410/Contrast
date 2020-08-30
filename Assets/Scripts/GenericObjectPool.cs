using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;
    public Queue<T> objects = new Queue<T>();
    private Transform ParentObject;


    #region Singleton

    public static GenericObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public T Get()
    {
        return objects.Dequeue();
    }

    private void Start()
    {
        ParentObject = GameObject.FindGameObjectWithTag("PoolParent").GetComponent<Transform>();
    }

    public void ReturnToPool(T obj)
    {
        objects.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T newObject = GameObject.Instantiate(prefab, ParentObject);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
        }
    }
}