using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

[System.Serializable]
public class IKEvent : UnityEvent<int> { }

public class OnAnimatorIKEvent : MonoBehaviour
{
    public IKEvent onAnimatorIK;
    
    private void OnAnimatorIK(int layerIndex)
    {
        onAnimatorIK.Invoke(layerIndex);    
    }
  
}
