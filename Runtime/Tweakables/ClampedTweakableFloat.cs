using UnityEngine;
using UnityEngine.UI;

namespace ZupUtils.Tweakables
{
    [CreateAssetMenu(menuName = "Tweakable/Clamped Float")]
    public class ClampedTweakableFloat : TweakableFloat
    {
        public Vector2 Range;

        public override void ChangeValue(float newValue)
        {
            if (Range != Vector2.zero)
            {
                base.ChangeValue(Mathf.Clamp(newValue, Range.x, Range.y));
                return;
            }
        
            base.ChangeValue(newValue);
        }
    }

}