using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Goal043
{


    public static class Math
    {


        public static float Map(this float t, float x1, float x2, float y1, float y2)
        {
            var m = (y2 - y1) / (x2 - x1);
            var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

            return m * t + c;
        }
        /// <summary>
        /// Lerps using a coroutine and a callback
        /// </summary>
        /// <param name="from">start paramter</param>
        /// <param name="to">end parameter</param>
        /// <param name="duration">how long it takes, <b> !! must be bigger than 0 !!</b></param>
        /// <param name="Callback">invokes te callback every frame with the value</param>
        /// <returns></returns>
        public static IEnumerator Lerp(float from, float to, float duration, UnityAction<float> Callback)
        {
            float time = 0;

            routineStart:
            time += Time.deltaTime/duration;
            Callback.Invoke(Mathf.Lerp(from, to, time));

            yield return null;
            if (time >=1.0) goto End;

            goto routineStart;
            End:
            Callback.Invoke(to);
        }
        /// <summary>
        /// Lerps using a coroutine and a callback
        /// </summary>
        /// <param name="duration">how long it takes, <b> !! must be bigger than 0 !!</b></param>
        /// <param name="Callback">invokes te callback every frame with a value from 0 to 1 (time/duration)</param>
        /// <returns></returns>
        public static IEnumerator Lerp(float duration, UnityAction<float> Callback)
        {
            float time = 0;

            routineStart:
            time += Time.deltaTime/duration;
            Callback.Invoke(time);

            yield return null;
            if (time >=1.0) goto End;
            goto routineStart;

            End:
            Callback.Invoke(1.0f);
        }

        /// <summary>
        /// Lerps using a coroutine and a callback
        /// </summary>
        /// <param name="from">start paramter</param>
        /// <param name="to">end parameter</param>
        /// <param name="duration">how long it takes, <b> !! must be bigger than 0 !!</b></param>
        /// <param name="Callback">invokes te callback every frame with the value</param>
        /// <returns></returns>
        public static IEnumerator UnscaledLerp(float from, float to, float duration, UnityAction<float> Callback)
        {
            float time = 0;

            routineStart:
            time += Time.unscaledDeltaTime/duration;
            Callback.Invoke(Mathf.Lerp(from, to, time));

            yield return null;
            if (time >=1.0) goto End;

            goto routineStart;
            End:
            Callback.Invoke(to);
        }
        /// <summary>
        /// Lerps using a coroutine and a callback
        /// </summary>
        /// <param name="duration">how long it takes, <b> !! must be bigger than 0 !!</b></param>
        /// <param name="Callback">invokes te callback every frame with a value from 0 to 1 (time/duration)</param>
        /// <returns></returns>
        public static IEnumerator UnscaledLerp(float duration, UnityAction<float> Callback)
        {
            float time = 0;

            routineStart:
            time += Time.unscaledDeltaTime/duration;
            Callback.Invoke(time);

            yield return null;
            if (time >=1.0) goto End;
            goto routineStart;

            End:
            Callback.Invoke(1.0f);
        }
    }

}