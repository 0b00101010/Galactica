using System;
using System.Collections;
using UnityEngine;

public static class ExtensionMethods{
    public static Vector2 Position(this Vector3 position){
        return (Vector2)position;
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