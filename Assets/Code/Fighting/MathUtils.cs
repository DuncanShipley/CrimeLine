using UnityEditor;
using UnityEngine;

namespace Assets.Code.Fighting
{
    public class MathUtils
    {
        
        public float EuclideanNorm3(Vector3 vec1, Vector3 vec2)
        {
           float xDifference = vec2[0] - vec1[0];
           float yDifference = vec2[1] - vec1[1];
           float zDifference = vec2[2] - vec2[2];
            return Mathf.Sqrt(
                Mathf.Pow(xDifference, 2)+
                Mathf.Pow(yDifference, 2)+
                Mathf.Pow(zDifference, 2)
             );
        }

    }
}