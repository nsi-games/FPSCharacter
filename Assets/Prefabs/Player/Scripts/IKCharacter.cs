using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKCharacter : MonoBehaviour
{
    public float globalIKWeight;

    [Header("IK Elbow")]
    public Transform leftElbowHint;
    public Transform rightElbowHint;
    public Transform lookAtHint;

    [Header("IK Hand")]
    public float leftElbowHintWeight;
    public float rightElbowHintWeight;
    public Transform leftHandTarget;
    public Transform rightHandTarget;

    [Header("IK Look")]
    public float lookIKWeight;
    public float bodyWeight;
    public float headWeight;
    public float eyesWeight;
    public float clampWeight;

    [Header("References")]
    public Animator anim;

    void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(lookIKWeight * globalIKWeight, 
                             bodyWeight * globalIKWeight, 
                             headWeight * globalIKWeight, 
                             eyesWeight * globalIKWeight, 
                             clampWeight * globalIKWeight);

        anim.SetLookAtPosition(lookAtHint.position);

        // Hand IK
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, globalIKWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, globalIKWeight);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);

        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, globalIKWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, globalIKWeight);

        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);

        // Elbow IK
        anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, leftElbowHintWeight * globalIKWeight);
        anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rightElbowHintWeight * globalIKWeight);

        anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowHint.position);
        anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowHint.position);
    }
}
