using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityTrigger : MonoBehaviour
    {
        public enum State
        {
            Enter,Exit,Stay
        }
        public event Action<Collider> onTriggerEnter;
        public event Action<Collider> onTriggerExit;
        public event Action<Collider> onTriggerStay;
        public event Action<Collision> onCollisionEnter;
        public event Action<Collision> onCollisionExit;
        public event Action<Collision> onCollisionStay;
        //public void NotifyTrigger(State state, Collider collider)
        //{
        //    switch (state)
        //    {
        //        case State.Enter:
        //            onTriggerEnter?.Invoke(collider);
        //            break;
        //        case State.Exit:
        //            onTriggerExit?.Invoke(collider);
        //            break;
        //        case State.Stay:
        //            onTriggerStay?.Invoke(collider);
        //            break;
        //    }
        //}
        public bool isTrigger = true;
        private void Awake()
        {
            Init(isTrigger);
        }
        public void Init(bool isTrigger)
        {
            this.isTrigger = isTrigger;
            var c = GetComponent<Collider>();
            if (c)
            {
                c.isTrigger = isTrigger;
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke(other);
        }
        public void OnTriggerExit(Collider other)
        {
            onTriggerExit?.Invoke(other);
        }
        public void OnTriggerStay(Collider other)
        {
            onTriggerStay?.Invoke(other);
        }
        private void OnCollisionEnter(Collision collision)
        {
            onCollisionEnter?.Invoke(collision);
        }
        private void OnCollisionStay(Collision collision)
        {
            onCollisionStay?.Invoke(collision);
        }
        private void OnCollisionExit(Collision collision)
        {
            onCollisionExit?.Invoke(collision);
        }
    }
}

