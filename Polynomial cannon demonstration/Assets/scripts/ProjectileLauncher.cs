using UnityEngine;
using TMPro;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public TMP_Text equationText;

    public float launchForce = 10f;

    private GameObject currentProjectile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentProjectile != null)
        {
            Destroy(currentProjectile);
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2 direction = (mouseWorldPos - launchPoint.position).normalized;

        currentProjectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);

        Rigidbody2D rb = currentProjectile.GetComponent<Rigidbody2D>();

        Vector2 velocity = direction * launchForce;
        rb.linearVelocity = velocity;

        DisplayEquation(velocity);
    }

    void DisplayEquation(Vector2 velocity)
    {
        float vx = velocity.x;
        float vy = velocity.y;
        float y0 = launchPoint.position.y;

        float g = Mathf.Abs(Physics2D.gravity.y);

        if (Mathf.Abs(vx) < 0.01f)
        {
            equationText.text = "Vertical shot: no standard y = ax² + bx + c form";
            return;
        }

        float a = -g / (2 * vx * vx);
        float b = vy / vx;
        float c = y0;

        equationText.text =
            $"Projectile polynomial:\n" +
            $"y = {a:F3}x² + {b:F3}x + {c:F3}";
    }
}