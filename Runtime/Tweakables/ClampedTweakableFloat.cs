using UnityEngine;

namespace ZupUtils.Tweakables
{
    [CreateAssetMenu(menuName = "Tweakable/Clamped Float")]
    public class ClampedTweakableFloat : TweakableFloat
    {
        public Vector2? Range;
    
        public override void ChangeValue(float newValue)
        {
            if (Range != null)
            {
                base.ChangeValue(Mathf.Clamp(newValue, Range.Value.x, Range.Value.y));
                return;
            }
        
            base.ChangeValue(newValue);
        }
    }
}