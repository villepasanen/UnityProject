using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] TMP_Text _clockText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _clockText.text = Time.time.ToString("0")+ " S";
        
    }
}
