using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    [Header("Referencias del Proyectil")]
    public GameObject bulletPrefab; // Aquí arrastras tu modelo de bala
    public Transform firePoint;     // Un objeto vacío en la punta del cañón

    [Header("Ajustes")]
    public float bulletForce = 30f; // Velocidad de la bala
    public float fireRate = 0.5f;   // Tiempo entre disparos
    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. Creamos la bala en la posición y rotación del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Obtenemos su Rigidbody para darle fuerza
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Le damos un impulso hacia adelante
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

        // 3. Destruimos la bala después de 5 segundos para no llenar la memoria
        Destroy(bullet, 5f);
    }
}