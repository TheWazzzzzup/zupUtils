using UnityEngine;

namespace ZupUtils.Tweakables
{
    public abstract class Tweakable<T> : ScriptableObject
    {
        public string keyName;
        public T value;

        public virtual void ChangeValue(T newValue)
        {
            value = newValue;
        }
    }
}