using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

namespace PlatForm.player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private bool _moveable;
        [SerializeField] private bool _jumpable;
        [SerializeField] private bool _fallable;
        [SerializeField] private Vector2 _castOffset;
        [SerializeField] private float _belowCastDistance = 3.0f;
        [SerializeField] private Vector2 _belowCastOffset;
        [SerializeField] private Vector2 _castSize;
        private JumpMoveMent _jumpmoveMent;
        private MoveMent _moveMent;
        private CapsuleCollider2D capsuleCollider;
        private Rigidbody2D _rigidbody2D;
        private AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public AudioClip audioJump;
        public AudioClip audioDamaged;
        public AudioClip audioDie;
        public AudioClip audioFinish;
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
            audioSource = GetComponent<AudioSource>();
            _moveMent = GetComponent<MoveMent>();
            _jumpmoveMent = GetComponent <JumpMoveMent>();
        }

        public void Update()
        {
            Debug.DrawRay(_rigidbody2D.position, Vector3.down, new Color(0, 0.5f, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_rigidbody2D.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            //RaycastHit2D hit =
            //        Physics2D.BoxCast(origin: (Vector2)transform.position + _castOffset + Vector2.down * _castSize.y + _belowCastOffset,
            //      size: _castSize,
            //      angle: 0.0f,
            //      direction: Vector2.down,
            //      distance: _belowCastDistance);

            //if(hit.collider != null)
            //{
            //    Debug.Log("hit");
            //}

            if (rayHit.collider == null && _rigidbody2D.velocity.y < 0)
            {
                _fallable = true;
                _moveable = false;
                _jumpable = false;
            }
            else if (rayHit.collider != null && _rigidbody2D.velocity.y == 0)
            {                
                _fallable = false;
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

            if ((_moveMent.horizontal == 1 || _moveMent.horizontal == -1) && _jumpable == false && _fallable == false)
            {
                _moveable = true;
            }
            else if (_moveMent.horizontal == 0)
                _moveable = false;


            if (_jumpable == false && _moveable == false && _fallable == false)
                animator.Play("Stay");

            if (_fallable)
                animator.Play("Fall");

            if (_jumpable)
            {
                animator.Play("Jump");
            }

            if (_moveable)
            {
                animator.Play("Move");
            }
        }
        
        public void VelocityZero()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        public void PlaySound(string action)
        {
            switch (action)
            {
                case "JUMP":
                    audioSource.clip = audioJump;
                    break;
                case "DIE":
                    audioSource.clip = audioDie;
                    break;
                case "DAMAGED":
                    audioSource.clip = audioDamaged;
                    break;
                case "FINISH":
                    audioSource.clip = audioFinish;
                    break;

            }
            audioSource.Play();
        }


    }
}
