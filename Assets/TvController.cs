using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    public Material OffMaterial;
    public Material OnCameraMaterial;
    public Material OnTvMaterial;
    public VideoCameraController VideoCamera;

    private MeshRenderer _meshRenderer;
    private bool _powerOn = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        var currentMaterials = _meshRenderer.materials;
        if (!_powerOn)
        {
            currentMaterials[1] = OffMaterial;
        }
        else if (VideoCamera.PowerOn)
        {
            currentMaterials[1] = OnCameraMaterial;
        }
        else
        {
            currentMaterials[1] = OnTvMaterial;
        }

        _meshRenderer.materials = currentMaterials;
    }

    public void AlternatePower()
    {

        _powerOn = !_powerOn;
    }
}
