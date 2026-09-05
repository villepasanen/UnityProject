using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStaffController : MonoBehaviour
{
    [SerializeField] Projectile _projectile;
    [SerializeField] AudioClip _shootSound;
    [SerializeField] Transform _tip;

    [SerializeField] float _fireRate;
    [SerializeField] float _spreadFireRate;
    float _nextFireTime;
    float _nextSpreadFireTime;
    Vector2 _lookDirection;

    void Update()
    {
        if (Time.timeScale == 0f)
            return;
        SetLookDirection();
       RotateStaff();

        if (Mouse.current.leftButton.isPressed && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            Shoot();
        }
        if (Mouse.current.rightButton.isPressed && Time.time >= _nextSpreadFireTime)
        {
            _nextSpreadFireTime = Time.time + 1f / _spreadFireRate;
            ShootSpread();
        }


    }

    void RotateStaff()
    {
        

        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    void Shoot()
    {
        Debug.Log("BANG!");
        

        AudioManager.Instance.PlayAudio(_shootSound, AudioManager.SoundType.SFX, 0.4f, false);
        Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile.InitializeProjectile(_lookDirection);

    }
    void SetLookDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _lookDirection = (mousePosition - (Vector2)transform.position).normalized;
    }

    void ShootSpread()
    {
    
        AudioManager.Instance.PlayAudio(_shootSound, AudioManager.SoundType.SFX, 0.4f, false);
        Projectile newProjectile1 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        Projectile newProjectile2 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        Projectile newProjectile3 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        Projectile newProjectile4 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        Projectile newProjectile5 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile1.InitializeProjectile(_lookDirection);
        newProjectile2.InitializeProjectile(Quaternion.Euler(0, 0, 10) * _lookDirection);
        newProjectile3.InitializeProjectile(Quaternion.Euler(0, 0, -10) * _lookDirection);
        newProjectile4.InitializeProjectile(Quaternion.Euler(0, 0, 20) * _lookDirection);
        newProjectile4.InitializeProjectile(Quaternion.Euler(0, 0, -20) * _lookDirection);

    }
}
