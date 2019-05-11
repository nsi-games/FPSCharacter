using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;

using System.Linq;

public class IKCharacter : MonoBehaviour
{
    [Slider(0, 1)] public float globalIKWeight = 1f;

    [BoxGroup("Hints")] public Transform lookAtHint;

    [BoxGroup("Targets")] [Tag] public string leftHandTargetTag, rightHandTargetTag;

    [BoxGroup("Weighting")] [Slider(0, 1)] public float lookIKWeight = 1f;
    [BoxGroup("Weighting")] [Slider(0, 1)] public float bodyWeight = 0.75f;
    [BoxGroup("Weighting")] [Slider(0, 1)] public float headWeight = 1f;
    [BoxGroup("Weighting")] [Slider(0, 1)] public float eyesWeight = 1f;
    [BoxGroup("Weighting")] [Slider(0, 1)] public float clampWeight = 1f;

    [BoxGroup("References")] public Animator anim;

    public Transform rightHandTarget, leftHandTarget;

    private void Start()
    {
        RemapAllTargets();
    }

    public void OnAnimatorIK(int layerIndex)
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
    }

    [Button]
    public void RemapAllTargets()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        leftHandTarget = children.Single(item => item.tag == "LeftHandTarget");
        rightHandTarget = children.Single(item => item.tag == "RightHandTarget");
    }
}
