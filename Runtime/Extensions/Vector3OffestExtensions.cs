using UnityEngine;

namespace ZupUtils.Extensions
{
    public static class Vector3OffestExtensions
    {
        /// <summary>
        /// Offsets the Vector3 values using addition
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>Modifed Vector3 with the coresponding offset</returns>
        public static Vector3 Offset(this Vector3 v, float x = 0, float y = 0, float z = 0) {
            return new Vector3(v.x + x, v.y + y, v.z + z);
        }

        /// <summary>
        /// Offsets the Vector3 x value using addition
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns>Modifed Vector3 with the coresponding offset</returns>
        public static Vector3 OffsetX(this Vector3 v, float x = 0){
            return new Vector3(v.x + x, v.y, v.z);
        }

        /// <summary>
        /// Offsets the Vector3 y value using addition
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns>Modifed Vector3 with the coresponding offset</returns>
        public static Vector3 OffsetY(this Vector3 v, float y = 0)
        {
            return new Vector3(v.x, v.y + y, v.z);
        }

        /// <summary>
        /// Offsets the Vector3 z value using addition
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns>Modifed Vector3 with the coresponding offset</returns>
        public static Vector3 OffsetZ(this Vector3 v, float z = 0)
        {
            return new Vector3(v.x, v.y, v.z + z);
        }

    }
}
