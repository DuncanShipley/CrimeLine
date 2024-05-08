using UnityEditor;
using UnityEngine;
using System.Collections.Immutable;
using Unity.VisualScripting.FullSerializer;

namespace Assets.Code.Fighting
{
    public static class MathUtils
    {
        
        public static float EuclideanNorm3(Vector3 vec1, Vector3 vec2)
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

        /**
         * Check if transform is currently colliding with any collider of the specified type
         * 
         */

        public static bool isTouching(this Component component)
        {
            return Physics.OverlapBox(component.transform.position, component.GetComponents<BoxCollider>()[0].size, component.transform.rotation, 0).ToImmutableList().Count > 0;
        }

        public static bool TouchingGround(this Collider collider)
        {
            float distToGround = collider.bounds.extents.y;
            return Physics.Raycast(collider.bounds.center, -Vector3.up, 3.0f);
            
        }

    }

    
}