using System;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class Nameplates : MonoBehaviour
{
    private TMP_Text characterNameText;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = FindFirstObjectByType<Camera>();
        GetName();
    }
    
    void FixedUpdate()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        Vector3 direction = mainCamera.transform.position - transform.position;
        Quaternion lookAtCamera = Quaternion.LookRotation(-direction);
        transform.rotation = lookAtCamera;
    }

    private void GetName()
    {
        characterNameText = GetComponent<TMP_Text>();
        characterNameText.text = GetComponentInParent<Characters>().characterName;
    }
}
