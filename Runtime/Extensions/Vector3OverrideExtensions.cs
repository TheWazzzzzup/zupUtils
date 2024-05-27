using UnityEngine;

namespace ZupUtils.Extensions
{
    public static class Vector3OverrideExtensions
    {
        /// <summary>
        /// Overrides the Vector3 with the provided values
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>Modifed Vector3 with the coresponding overrides</returns>
        public static Vector3 Override(this Vector3 v, float? x = null, float? y = null, float? z = null){
            return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
        }

        /// <summary>
        /// Overrides the Vector3 x value
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns>Modifed Vector3 with the coresponding overrides</returns>
        public static Vector3 OverrideX(this Vector3 v, float? x = null) { 
            return new Vector3(x ?? v.x, v.y, v.z);
        }

        /// <summary>
        /// Overrides the Vector3 y value
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns>Modifed Vector3 with the coresponding overrides</returns>
        public static Vector3 OverrideY(this Vector3 v, float? y = null)
        {
            return new Vector3(v.x, y ?? v.y, v.z);
        }

        /// <summary>
        /// Overrides the Vector3 z value
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns>Modifed Vector3 with the coresponding overrides</returns>
        public static Vector3 OverrideZ(this Vector3 v, float? z = null)
        {
            return new Vector3(v.x, v.y, z ?? v.z);
        }

    }
}
