using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;

    

    public void OnAfterDeserialize()
    {

    }

    public void OnBeforeSerialize()
    {

    }
}