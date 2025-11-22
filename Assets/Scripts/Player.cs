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

    private float horizontalInput;
    private float verticalInput;

    private Camera cam;

    public GameObject ShieldPowerUp;
    public float shieldDuration = 5f;

    bool shiledActive = false;
    float timer = 0f;

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Player: No Main Camera found.");
            enabled = false;
            return;
        }

        if (ShieldPowerUp != null)
        {
            ShieldPowerUp.SetActive(false);
        }
    }

    void Update()
    {
        Movement();
        Shooting();

        if (shiledActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
                DisableShield();
        }
    }

    public void ActivateShield(float duration)
    {
        shiledActive = true;
        timer = duration;
        if (ShieldPowerUp != null)
        {
            ShieldPowerUp.SetActive(true);
        }
    }

    void DisableShield()
    {
        shiledActive = false;
        timer = 0f;
        if (ShieldPowerUp != null)
        {
            ShieldPowerUp.SetActive(false);
        }
    }

    public bool IsShieldActive()
    {
        return shiledActive;
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 delta = new Vector3(horizontalInput, verticalInput, 0f) * playerSpeed * Time.deltaTime;
        transform.Translate(delta, Space.World);

        Vector3 vp = cam.WorldToViewportPoint(transform.position);

        if (vp.z < 0.01f) vp.z = 0.01f;

        float minY = 0f + edgeMargin;
        float maxY = 0.5f - edgeMargin;
        vp.y = Mathf.Clamp(vp.y, minY, maxY);

        if (vp.x < 0f) vp.x += 1f;
        else if (vp.x > 1f) vp.x -= 1f;

        transform.position = cam.ViewportToWorldPoint(vp);
    }
}
