using UnityEngine;
using UnityEngine.Assertions;

public interface IFactoryElement
{
    void Prepare(object customParameter = null);
}

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour, IFactoryElement
{
    [SerializeField] private T objectPrefab;

    public virtual T Crate(Transform parent, object customParameter = null)
    {
        var element = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity, parent);
        element.Prepare(customParameter);
        
        Assert.IsNotNull(element);
        Debug.Log($"{typeof(T)} is spawned with custom parameter {customParameter}, parent: {parent.gameObject.name}");
        
        return element;
    }
}