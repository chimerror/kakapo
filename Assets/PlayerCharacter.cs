using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using VRTK;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(VRTK_HipTracking))]
public class PlayerCharacter : MonoBehaviour
{
    public Transform MeshTransform;
    public float LegHeight = 0.48f;
    public float LegWidthOffset = 0.25f;
    public float LookAtOffset = 1f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    private void OnAnimatorIK()
    {
        var leftTransform = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.LeftController);
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, leftTransform.position);
        _animator.SetIKRotation(AvatarIKGoal.LeftHand, leftTransform.rotation);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        var rightTransform = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.RightController);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, rightTransform.position);
        _animator.SetIKRotation(AvatarIKGoal.RightHand, rightTransform.rotation);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

        var hipPosition = transform.position;
        var rightFootPosition = new Vector3(hipPosition.x + LegWidthOffset, hipPosition.y - LegHeight, hipPosition.z);
        _animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition);
        _animator.SetIKRotation(AvatarIKGoal.RightFoot, transform.rotation);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);

        var leftFootPosition = new Vector3(hipPosition.x - LegWidthOffset, hipPosition.y - LegHeight, hipPosition.z);
        _animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPosition);
        _animator.SetIKRotation(AvatarIKGoal.LeftFoot, transform.rotation);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);

        var headTransform = VRTK_DeviceFinder.HeadsetTransform();
        var lookAtGoal = headTransform.position + LookAtOffset * headTransform.forward;
        _animator.SetLookAtPosition(lookAtGoal);
        _animator.SetLookAtWeight(1f);

    }
}
