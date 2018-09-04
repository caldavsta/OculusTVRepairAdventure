using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Event_System.Actions
{
    class ShrinkLikeAlice : ActionBehaviour
    {
        [Header("This Script is Deprecated")]
        public float MinimumSize = 10;
        public float SizeDecrement = 0.01f;

        private bool _shrinking = false;

        private Vector3 _localScale;
        [SerializeField]
        private float _currentScaleOffset = 0.0f;

        public override void OnStart()
        {
            _currentScaleOffset = 0.0f;
            _localScale = transform.localScale;
        }

        public override void OnUpdate()
        {
            if (_shrinking)
            {
                _currentScaleOffset += SizeDecrement;
                transform.localScale = new Vector3(_localScale.x + _currentScaleOffset, _localScale.y + _currentScaleOffset, _localScale.z + _currentScaleOffset);

            }
        }

        public override void DoAction()
        {
            Shrink();
        }

        public void Shrink()
        {
            _shrinking = true;
        }
    }
}
