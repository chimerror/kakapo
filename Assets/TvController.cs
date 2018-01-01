using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    public Material OffMaterial;
    public Material OnMaterial;


    private MeshRenderer _meshRenderer;
    private bool _powerOn = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AlternatePower()
    {
        var currentMaterials = _meshRenderer.materials;
        if (_powerOn)
        {
            currentMaterials[1] = OffMaterial;
        }
        else
        {
            currentMaterials[1] = OnMaterial;
        }

        _meshRenderer.materials = currentMaterials;
        _powerOn = !_powerOn;
    }
}
