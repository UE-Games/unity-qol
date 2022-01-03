using System.Collections;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;


namespace UniEnt.UnityQOL.Runtime {


    public sealed class RandomAnimationFrame : MonoBehaviour {


        public string animationName;
        public uint animationLength;

        Animator _anim;
        WaitForSeconds _flipWait;


        void Awake() {
            _anim = GetComponent<Animator>();

            if (_anim != null) {
                _flipWait = new WaitForSeconds(0.1f);

                StartCoroutine(Flip());
            }
            else
                VLog.Warning($"{name}.RandomAnimationFrame: There is no Animator component");
        }


        IEnumerator Flip() {
            _anim.PlayInFixedTime(animationName, -1, math.floor(Random.Range(0, animationLength)));

            yield return _flipWait;

            _anim.speed = 0;
        }


    }


}
