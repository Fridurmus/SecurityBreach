using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCone : MonoBehaviour
{

    public float viewRadius;

    [Range(0, 360)]
    public float maxViewAngle;
    [Range(0, 360)]
    public float minViewAngle;
    public enum PatrolType
    {
        Patrol,
        Sentry,
        Spotlight,
    }
    public PatrolType Type;

    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

    public bool tempCrouch;
    public bool hunting;

    Color searchingColor = Color.yellow;
    Color caughtColor = Color.red;

    public float meshResolution;
    public int edgeResolveIterations;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    MeshRenderer[] viewRender;

    [HideInInspector]
    public float viewAngle;
    [HideInInspector]
    public List<Transform> visibleTargets;

    private void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        viewRender = GetComponentsInChildren<MeshRenderer>();
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    private void LateUpdate()
    {
        if (!tempCrouch)
        {
            viewAngle = maxViewAngle;
        }
        else
        {
            viewAngle = minViewAngle;
        }

        if (visibleTargets.Count > 0)
        {
            viewRender[1].material.color = Color.red;
        }
        else
        {
            viewRender[1].material.color = Color.yellow;
        }

        DrawFieldOfView();

    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        // Clear list of visible targets
        visibleTargets.Clear();

        // Make an array of things within the view radius
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, TargetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;

            //Find the direction to the target
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //If there within the view arc
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle * 0.5)
            {
                //Find distance to the target
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                //If it doesnt collide with a wall
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, ObstacleMask))
                {
                    //Add it to the visible target list
                    visibleTargets.Add(target);
                }
            }
        }
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle * .5f + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);


            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] Vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        Vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            Vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = Vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();

    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 direction = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, viewRadius, ObstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * viewRadius, viewRadius, globalAngle);
        }
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dist;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle)
        {
            hit = _hit;
            point = _point;
            dist = _dist;
            angle = _angle;
        }
    }
}
