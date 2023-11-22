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
                //onHorizontalChanged(value); // ����ȣ�� - ��ϵ� �Լ��� ȣ���Ҷ����� ���ڸ� ��������
                //onHorizontalChanged.Invoke(value); // ����ȣ�� - Invoke�� �Ű������� ���� ���� ��.. ��ϵ��Լ����� Invoke �� �Ű������� ������
                onHorizontalChanged?.Invoke(value); // null üũ ������ - null �̸� (��ϵ��Լ� ������) ȣ�� x 
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