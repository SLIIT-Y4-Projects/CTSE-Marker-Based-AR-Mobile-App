using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject dinosaurPrefab; 
    [SerializeField] private Vector3 prefabOffset;

    private GameObject instantiatedDinosaur; 
    private ARTrackedImageManager aRTrackedImageManager;

    private void Start()
    {
        // Find ARTrackedImageManager in the scene
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        if (aRTrackedImageManager == null)
        {
            Debug.LogError("ARTrackedImageManager not found in the scene.");
            return;
        }

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            if (dinosaurPrefab != null) 
            {
                instantiatedDinosaur = Instantiate(dinosaurPrefab, image.transform.position + prefabOffset, Quaternion.identity, image.transform); 
            }
            else
            {
                Debug.LogError("Dinosaur prefab is not assigned!"); 
            }
        }
    }
}
