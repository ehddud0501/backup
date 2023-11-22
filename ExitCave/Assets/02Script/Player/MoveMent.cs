using PlatForm.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace PlatForm.player
{

    public class MoveMent : MonoBehaviour
    {
        public bool _isMovable;
        public bool isDirectionChangeable;
        public const int DIRECTION_RIGHT = 1;
        public const int DIRECTION_LEFT = -1;
        public Rigidbody2D _rigidbody2D;
        private float _speed = 4.8f;
        private float acceleration;
        private float max;

        private Vector2 _move;

        public int direction
        {
            get => _direction;
            set
            {

                if (isDirectionChangeable == false)
                    return;

                if (_direction == value)
                    return;

                if (value < 0)
                {
                    transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                    _direction = DIRECTION_LEFT;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0.0f, 360.0f, 0.0f);
                    _direction = DIRECTION_RIGHT;
                }

                onDirectionChanged?.Invoke(_direction);
            }
        }

        private int _direction;
        public event Action<int> onDirectionChanged;
        public float horizontal
        {
            get => _horizontal;
            set
            {
                if (_isMovable == false)
                {
                    return;
                }

                if (_horizontal == value)
                    return;

                _horizontal = value;
                //onHorizontalChanged(value); // 직접호출 - 등록된 함수를 호출할때마다 인자를 직접참조
                //onHorizontalChanged.Invoke(value); // 간접호출 - Invoke의 매개변수에 인자 전달 후.. 등록된함수들은 Invoke 의 매개변수를 참조함
                onHorizontalChanged?.Invoke(value); // null 체크 연산자 - null 이면 (등록된함수 없으면) 호출 x 
            }
        }
        [SerializeField] private float _horizontal;
        public event Action<float> onHorizontalChanged;


        private void Update()
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            if (_isMovable)
            {
                _move = new Vector2(horizontal, 0.0f);
                
            }
            else
            {
                _move = Vector2.zero;
            }

            if (isDirectionChangeable)
            {
                if (_horizontal < 0)
                    direction = DIRECTION_LEFT;
                else if (_horizontal > 0)
                    direction = DIRECTION_RIGHT;
            }


        }

        private void FixedUpdate()
        {              
            
            _rigidbody2D.position += _move * _speed * Time.fixedDeltaTime;
        }

    }
}