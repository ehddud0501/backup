using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace PlatForm.player
{
    public class JumpMoveMent : MonoBehaviour
    {
        private float jumpPower = 8.0f;
        [SerializeField] private int _jumpcount = 1;
        public Player player;
        public Rigidbody2D _rigidbody2D;
        private AudioSource audioSource;
        [SerializeField] private AudioClip audioJump;
        [SerializeField] private PlusJump plusJump;
        public bool _isJump;
        public bool _plusJump;
        public void Jump()
        {
            if (_isJump)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _isJump = false;
                _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
            //landing 점프후 바닥에 착지시 점프가능횟수 초기화
            if (_rigidbody2D.velocity.y < 0)
            {
                Debug.DrawRay(_rigidbody2D.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(_rigidbody2D.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.7f)
                    {
                        _jumpcount = 1;
                    }
                }
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
    }

}
