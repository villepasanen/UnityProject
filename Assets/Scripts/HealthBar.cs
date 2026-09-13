using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _hpBar;
    [SerializeField] EntityHealth _playerHealth;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnEnable()
    {
        _playerHealth.OnHealthChanged += OnHealthChanged;    
    }
    void OnDisable()
    {
        _playerHealth.OnHealthChanged -= OnHealthChanged;
    }
    void OnHealthChanged(float currenthealth, float maxHealth)
    {
        _hpBar.fillAmount = currenthealth / maxHealth;

    }
}
