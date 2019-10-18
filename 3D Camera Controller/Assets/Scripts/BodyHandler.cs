using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    public class BodyHandler : MonoBehaviour
    {
        protected PlayerBody pb;
        protected float priority;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            pb = GetComponentInParent<PlayerBody>();

        }
    }
}
