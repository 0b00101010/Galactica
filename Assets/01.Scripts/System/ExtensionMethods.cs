using System;
using System.Collections;
using UnityEngine;

public static class ExtensionMethods{
    public static Vector2 Position(this Transform transform){
        return (Vector2)transform.position;
    }

    public static void Log(this object value){
        Debug.Log(value);
    }

    public static IEnumerator Start(this IEnumerator coroutine, MonoBehaviour monoBehaviour){
        monoBehaviour.StartCoroutine(coroutine);
        return coroutine;
    }

    public static void Stop(this IEnumerator coroutine, MonoBehaviour monoBehaviour){
        monoBehaviour.StopCoroutine(coroutine);
    }
}