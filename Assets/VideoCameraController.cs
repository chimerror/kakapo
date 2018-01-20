using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCameraController : MonoBehaviour
{
    public bool PowerOn
    {
        get
        {
            return _powerOn;
        }
    }

    private bool _powerOn = false;

    private void Awake()
    {
    }

    public void AlternatePower()
    {
        _powerOn = !_powerOn;
    }
}
