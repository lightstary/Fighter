using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float playerSpeed = 6f;

    [Header("Shooting")]
    public GameObject bulletPrefab;

    [Header("Viewport Clamp")]
    [Tooltip("Tiny padding inside the edges (in viewport %). 0 = exact edge.")]
    [Range(0f, 0.05f)] public float edgeMargin = 0f;

    public int lives = 3;
    public int score = 0;

    private float horizontalInput;
    private float verticalInput;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Player: No Main Camera found.");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }
    }

    void Movement()
    {
        // 1) Read input (legacy Input Manager: Horizontal/Vertical)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // 2) Move in world space as usual
        Vector3 delta = new Vector3(horizontalInput, verticalInput, 0f) * playerSpeed * Time.deltaTime;
        transform.Translate(delta, Space.World);

        // 3) Convert to viewport space at the player's current depth
        Vector3 vp = cam.WorldToViewportPoint(transform.position);

        // Safety: if somehow behind camera, nudge forward
        if (vp.z < 0.01f) vp.z = 0.01f;

        // 4) Clamp vertical to bottom half [0 .. 0.5]
        float minY = 0f + edgeMargin;
        float maxY = 0.5f - edgeMargin;
        vp.y = Mathf.Clamp(vp.y, minY, maxY);

        // 5) Wrap horizontally (0..1)
        if (vp.x < 0f) vp.x += 1f;
        else if (vp.x > 1f) vp.x -= 1f;

        // 6) Convert back to world space at the same depth
        transform.position = cam.ViewportToWorldPoint(vp);

}
