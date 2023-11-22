using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using PlatForm.Audio;

namespace PlatForm.player
{
    public class JumpMoveMent : MonoBehaviour
    {
        [SerializeField] private AudioMachine playSound;
        [SerializeField] private Vector2 _castOffset;
        [SerializeField] private Vector2 _castSize;
        [SerializeField] private Vector2 _belowCastOffset;
        [SerializeField] private float _belowCastDistance = 1.0f;
        [SerializeField] private AudioClip audioJump;
        [SerializeField] private PlusJump plusJump;
        [SerializeField] private int _jumpcount = 1;
        public Player player;
        public Rigidbody2D _rigidbody2D;
        public bool _isJump;
        public bool _plusJump;
        private float jumpPower = 7.0f;
        public void Jump()
        {
            if (_isJump)
            {
                _isJump = false;
                playSound.PlaySound("JUMP");
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (_jumpcount > 0)
                {
                    _isJump = true;
                    transform.position = _rigidbody2D.position;
                    _jumpcount--;
                }
            }
        }
        private void FixedUpdate()
        {
            Jump();
            if (_plusJump)
            {
                _jumpcount += 1;
                if (_jumpcount > 1)
                    _jumpcount = 1;
                _plusJump = false;
            }
            if (_rigidbody2D.velocity.y <= 0)
            {
                _rigidbody2D.gravityScale = 3;
                RaycastHit2D rayHit =
                    Physics2D.BoxCast(origin: (Vector2)transform.position + _castOffset + Vector2.down * _castSize.y + _belowCastOffset,
                    size: _castSize,
                    angle: 0.0f,
                    direction: Vector2.down,
                    distance: _belowCastDistance,
                    layerMask: LayerMask.GetMask("Platform"));
                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.7f)
                        _jumpcount = 1;
                    _rigidbody2D.gravityScale = 1;
                }
            }
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + Vector3.down * _belowCastDistance, _castSize);
        }

    }

}
