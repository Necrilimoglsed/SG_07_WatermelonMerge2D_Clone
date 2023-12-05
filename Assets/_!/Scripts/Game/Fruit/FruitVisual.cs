using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVisual : MonoBehaviour
{
    [SerializeField] private FruitVisualSO fruitVisualSO;
    public MeshFilter MeshFilter => _meshFilter;
    private MeshFilter _meshFilter;
    private GameObject _currentVisual;

    public void Prepare(int id)
    {
        _currentVisual = Instantiate(fruitVisualSO.Visuals[id], Vector3.zero, Quaternion.identity, transform);

        _meshFilter = _currentVisual.GetComponent<MeshFilter>();
    }
}
