using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    [SerializeField] private Transform _target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = _target.position.x;
        position.y = _target.position.y;

        transform.position = position;
        //Voi tehdä smoothimmaksi käyttämällä Vector3.Lerp
    }
}
