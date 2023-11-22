using System.Collections;

namespace App.Scripts.Libs.Coroutine
{
    public interface ICoroutineRunner
    {
        public UnityEngine.Coroutine StartCoroutine(IEnumerator coroutine);
        public void StopCoroutine(UnityEngine.Coroutine coroutine);
    }
}