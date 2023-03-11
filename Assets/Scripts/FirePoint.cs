using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Bullet bulletPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);

        bullet.Project(this.transform.up);
    }
}
