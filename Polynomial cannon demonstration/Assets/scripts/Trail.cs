using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileTrail : MonoBehaviour
{
    private LineRenderer line;
    private int index = 0;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void Update()
    {
        // Add new point to the line
        line.positionCount = index + 1;
        line.SetPosition(index, transform.position);
        index++;
    }
}