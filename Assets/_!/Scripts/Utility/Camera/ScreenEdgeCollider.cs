using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenEdgeCollider : Singleton<ScreenEdgeCollider>
{
    [Header("Screen Colliders")]
    [SerializeField] private BoxCollider2D topCol;
    [SerializeField] private BoxCollider2D bottomCol;
    [SerializeField] private BoxCollider2D leftCol;
    [SerializeField] private BoxCollider2D rightCol;
    //[SerializeField] private BoxCollider2D gameOverLineCol;
    private Camera _camera;


    private void Awake()
    {
        _camera = GetComponent<Camera>();

        if (!_camera.orthographic)
        {
            _camera.orthographic = true;
            Debug.LogWarning("<color=yellow>Your camera isn't orthographic camera, changing to orthographic...</color>");
        }

        SetCameraEdges();
    }

    public Vector3 GetEdges()
    {
        return new Vector3(leftCol.size.x, 0, topCol.size.y);
    }

    private void SetCameraEdges()
    {
        var cameraHeight = _camera.orthographicSize;// * _camera.aspect;
        var cameraWidth = _camera.orthographicSize * _camera.aspect;

        leftCol.offset = new Vector2(-cameraWidth - leftCol.size.x * .5f, 0);
        leftCol.size = new Vector2(leftCol.size.x, cameraHeight * 2);

        topCol.offset = new Vector2(0, cameraHeight + topCol.size.y * 0.5f);
        topCol.size = new Vector3(cameraWidth * 2, topCol.size.y, 30f);

        rightCol.offset = new Vector2(leftCol.offset.x * -1, leftCol.offset.y);
        rightCol.size = leftCol.size;

        //bottomCol.offset = new Vector2(topCol.offset.x, topCol.offset.y * -1);
        bottomCol.offset = new Vector2(topCol.offset.x, -cameraHeight * 0.3f - 0.64f);// - topCol.size.y);
        bottomCol.size = topCol.size;

    }
}