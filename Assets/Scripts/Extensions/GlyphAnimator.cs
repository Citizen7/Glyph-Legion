using System.Collections;
using UnityEngine;

namespace GlyphLegion {
    public static class GlyphAnimator {
        public static IEnumerator SetAnimationBool(Animator thisAnimator, string name, bool value) {
            //Debug.Log("SAB coroutine called.");
            thisAnimator.SetBool(name, value);
            // TODO: remove this line Debug.Log($"Bool is {thisAnimator.GetBool(name)}.");
            yield return null;
        }
    }
}