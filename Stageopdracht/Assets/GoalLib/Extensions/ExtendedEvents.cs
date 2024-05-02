using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Events
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { };
    [System.Serializable]

    public class StringEvent : UnityEvent<string> { };
    [System.Serializable]

    public class FloatEvent : UnityEvent<float> { };
    [System.Serializable]

    public class DoubleEvent : UnityEvent<double> { };
    [System.Serializable]

    public class IntEvent : UnityEvent<int> { };
}