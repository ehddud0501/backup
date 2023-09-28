using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FallGasi : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _spikeRigid;
    [SerializeField] private GameObject _spikeRotation;
    private Vector3 _spikeRotationPos;
    private float fallPower = 20.0f;
    private bool _rotation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeathLine")
            _rotation = true;
    }

    private void Start()
    {
        _spikeRigid.AddForce(Vector2.down * fallPower, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {

        if ( _rotation )
        {
            _spikeRotationPos = _spikeRotation.transform.position;
            transform.position = _spikeRotationPos;
            _rotation = false;
        }

    }

}
