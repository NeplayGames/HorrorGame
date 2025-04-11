using UnityEngine;

namespace HorrorGame.Utils
{
    public static class Utilities
    {

        public static Vector3 GetPointInsideNavmesh(){
            //ToDo:
            //Check if in the navmesh
            var point = Random.insideUnitSphere * 60;
            return new Vector3(point.x, 0, point.z);
        }
    }

}
