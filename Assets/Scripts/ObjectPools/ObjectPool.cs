using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T: MonoBehaviour {

    [SerializeField] private T _poolObjectPrefab;
    private List<T> _pool = new List<T>();

    private void Initialize(string resourcesPrefabPath) {
        _poolObjectPrefab = Resources.Load<T>(resourcesPrefabPath);
    }

    public T GetObject() {
        T freePoolObj = null;
        foreach(var obj in _pool) {
            if (!obj.isActiveAndEnabled) {
                freePoolObj = obj;
            }
        }
        if(freePoolObj == null) {
            freePoolObj = Instantiate<T>(_poolObjectPrefab, transform, true);
            _pool.Add(_poolObjectPrefab);
        }
        return freePoolObj;
    }

    public void ClearPool(bool destroyAllObjects = false) {
        if (destroyAllObjects) {
            foreach (var obj in _pool)
                Destroy(obj.gameObject);
        }
        _pool.Clear();
    }
}