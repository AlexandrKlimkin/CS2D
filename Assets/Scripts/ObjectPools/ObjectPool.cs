using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> : SingletonBehaviour<ObjectPool<T>> where T: MonoBehaviour {

    [SerializeField] private T _poolObjectPrefab;
    private List<T> _pool = new List<T>();

    private void Initialize(string resourcesPrefabPath) {
        _poolObjectPrefab = Resources.Load<T>(resourcesPrefabPath);
    }

    public T GetObject() {
        var freePoolObj = _pool.FirstOrDefault(_ => !_.gameObject.activeSelf);
        if(freePoolObj == null) {
            freePoolObj = AddObject();
        }
        return freePoolObj;
    }

    private T AddObject() {
        var newObj = Instantiate(_poolObjectPrefab);
        newObj.transform.SetParent(transform);
        newObj.gameObject.SetActive(false);
        _pool.Add(newObj);
        return newObj;
    }

    public void ClearPool(bool destroyAllObjects = false) {
        if (destroyAllObjects) {
            foreach (var obj in _pool)
                Destroy(obj.gameObject);
        }
        _pool.Clear();
    }
}