using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
//using System.Numerics;

public class MapController : MonoBehaviour
{
    [Header("References")]
    public Camera referenceCamera;
    public float checkInterval = 0.5f;

    [Header("Chunk Settings")]
    public List<GameObject> terrainChunks;
    public Vector2 chunkSize = new Vector2(20f, 20f);
    public LayerMask terrainMask;

    //Camera Settings
    Vector3 lastCameraPosition;
    Rect lastCameraRect;
    float cullDistanceSqr;


    void Start()
    {
        if (!referenceCamera)
            Debug.LogError("MapController cannot work without a reference camera.");

        if (terrainChunks.Count < 1)
            Debug.LogError("There are no Terrain Chunks assigned, so the map cannot be dynamically generated.");

        StartCoroutine(HandleMapCheck());
        HandleChunkSpawning(Vector2.zero, true);
    }

    IEnumerator HandleMapCheck()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(checkInterval);

            Vector3 moveDelta = referenceCamera.transform.position;
            bool hasCamWidthChanged = !Mathf.Approximately(referenceCamera.pixelWidth - lastCameraRect.width, 0),
                 hasCamHeightChanged = !Mathf.Approximately(referenceCamera.pixelHeight - lastCameraRect.height, 0);

            if (moveDelta.magnitude > 0.1f || hasCamWidthChanged || hasCamHeightChanged)
            {
                HandleChunkCulling();
                HandleChunkSpawning(moveDelta, true);
            }

            lastCameraPosition = referenceCamera.transform.position;
            lastCameraRect = referenceCamera.pixelRect;
        }
    }

    public Rect GetWorldRectFromViewport()
    {
        Vector2 minPoint = referenceCamera.ViewportToWorldPoint(referenceCamera.rect.min),
                maxPoint = referenceCamera.ViewportToWorldPoint(referenceCamera.rect.max);
        Vector2 size = new Vector2(maxPoint.x - minPoint.x, maxPoint.y - minPoint.y);
        cullDistanceSqr = Mathf.Max(size.sqrMagnitude, chunkSize.sqrMagnitude) * 3;

        return new Rect(minPoint, size);
    }

    public Vector2[] GetCheckedPoints()
    {
        Rect viewArea = GetWorldRectFromViewport();
        Vector2Int tileCount = new Vector2Int(
            (int)Mathf.Ceil(viewArea.width / chunkSize.x) + 1,
            (int)Mathf.Ceil(viewArea.height / chunkSize.y) + 1
        );

        HashSet<Vector2> result = new HashSet<Vector2>();
        for (int y = 0; y < tileCount.y + 1; y++)
        {
            for (int x = 0; x < tileCount.x + 1; x++)
            {
                result.Add(new Vector2(
                    viewArea.min.x + chunkSize.x * x,
                    viewArea.min.y + chunkSize.y * y
                ));
            }
        }

        return result.ToArray();
    }

    void HandleChunkSpawning(Vector2 moveDelta, bool checkWithoutDelta = false)
    {
        HashSet<Vector2> spawnedPositions = new HashSet<Vector2>();

        foreach (Vector2 vp in GetCheckedPoints())
        {
            if (!checkWithoutDelta)
            {
                if ((moveDelta.x > 0 && vp.x < 0.5f) ||
                    (moveDelta.x < 0 && vp.x > 0.5f) ||
                    (moveDelta.y > 0 && vp.y < 0.5f) ||
                    (moveDelta.y < 0 && vp.y > 0.5f))
                {
                    continue;
                }
            }
            Vector2 checkedPosition = SnapPosition(vp);

            if (spawnedPositions.Add(checkedPosition))
            {
                if (!Physics2D.OverlapPoint(checkedPosition, terrainMask))
                {
                    SpawnChunk(checkedPosition);
                }
            }
        }
    }

    Vector2 SnapPosition(Vector2 position)
    {
        return new Vector2(
            Mathf.Round(position.x / chunkSize.x) * chunkSize.x,
            Mathf.Round(position.y / chunkSize.x) * chunkSize.x
        );
    }

    GameObject SpawnChunk(Vector2 spawnPosition, int variant = -1)
    {
        int rand = Random.Range(0, terrainChunks.Count);
        GameObject chunk = Instantiate(terrainChunks[rand], transform);
        chunk.transform.position = spawnPosition;
        return chunk;
    }

    void HandleChunkCulling()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform chunk = transform.GetChild(i);
            Vector2 dist = referenceCamera.transform.position - chunk.position;
            bool cull = dist.sqrMagnitude > cullDistanceSqr;
            chunk.gameObject.SetActive(!cull);
        }
    }
}
