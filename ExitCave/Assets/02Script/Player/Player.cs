using PlatForm.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatForm.player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Vector2 _castOffset;
        [SerializeField] private Vector2 _castSize;
        [SerializeField] private Vector2 _belowCastOffset;
        [SerializeField] private float _belowCastDistance = 1.0f;
        [SerializeField] private bool _moveable;
        [SerializeField] private bool _jumpable;
        [SerializeField] private bool _fallable;
        private JumpMoveMent _jumpmoveMent;
        private MoveMent _moveMent;
        private CapsuleCollider2D capsuleCollider;
        private Rigidbody2D _rigidbody2D;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        private void Start()
        {
            Time.timeScale = 1;
            _moveMent._isMovable = true;
            _moveMent.isDirectionChangeable = true;
        }

        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            _moveMent = GetComponent<MoveMent>();
            _jumpmoveMent = GetComponent <JumpMoveMent>();
        }
        public void Update()
        {
            RaycastHit2D Hit =
                Physics2D.BoxCast(origin: (Vector2)transform.position + _castOffset + Vector2.down * _castSize.y + _belowCastOffset,
                size: _castSize,
                angle: 0.0f,
                direction: Vector2.down,
                distance: _belowCastDistance,
                layerMask: LayerMask.GetMask("Platform"));
            if (Hit.collider == null && _rigidbody2D.velocity.y < 0)
            {
                _fallable = true;
                _moveable = false;
                _jumpable = false;
            }
            if (Hit.collider != null && _rigidbody2D.velocity.y == 0)
            {
                _moveable = false;
                _jumpable = false;
                _fallable = false;
            }
            if (_jumpmoveMent._isJump)
            {
                _moveable = false;
                _fallable = false;
                _jumpable = true; 
            }
            if (_moveMent.horizontal != 0 && _jumpable == false && _fallable == false)
                _moveable = true;
            else if (_moveMent.horizontal == 0)
                _moveable = false;
            if (_jumpable == false && _moveable == false && _fallable == false)
                animator.Play("Idle");
            if (_fallable)
                animator.Play("Fall");
            if (_jumpable)
                animator.Play("Jump");
            if (_moveable)
                animator.Play("Run");
                
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + Vector3.down * _belowCastDistance, _castSize);
        }

    }
}
