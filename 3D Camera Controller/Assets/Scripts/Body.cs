using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    [RequireComponent(typeof(Rotator))]
    [RequireComponent(typeof(Rigidbody))]
    public class Body : MonoBehaviour
    {
        [HideInInspector]
        public float gravity_multiplier = 4.0f;
        protected Rigidbody rb;

        [HideInInspector]
        public Rotator rotator;

        public int action_state;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rotator = GetComponent<Rotator>();
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (rb.velocity.y != 0f)
                rb.velocity += Vector3.up * Physics.gravity.y *
                    gravity_multiplier * Time.fixedDeltaTime;
        }
    }
}