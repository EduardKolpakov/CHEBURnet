using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteSCript : MonoBehaviour
{
    private Transform obj;
    private static Renderer ren;
    void Start()
    {
        obj = GetComponent<Transform>();
        ren = obj.GetComponent<Renderer>();
        ren.enabled = !ren.enabled;
    }

    public static IEnumerator ToggleVisibility()
    {
        ren.enabled = !ren.enabled;
        yield return new WaitForSeconds(0.1f);
        ren.enabled = !ren.enabled;
    }
}
