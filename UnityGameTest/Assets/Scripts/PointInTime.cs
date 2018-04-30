using UnityEngine;

[SerializeField]
public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Transform tra)
    {
        position = tra.position;
        rotation = tra.rotation;
    }
}
