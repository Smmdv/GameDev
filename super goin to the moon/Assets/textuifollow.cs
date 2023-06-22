using UnityEngine;
using UnityEngine.UI;

public class AttachTextToCamera : MonoBehaviour
{
    public Text textComponent;
    private Camera mainCamera;

    void Start()
    {
        // Find the "Main" camera in the scene
        mainCamera = GameObject.Find("Main").GetComponent<Camera>();

        // Create a new text object as a child of the camera
        GameObject textObject = new GameObject("AttachedText");
        textObject.transform.SetParent(mainCamera.transform);

        // Set the text object's position and rotation relative to the camera
        textObject.transform.localPosition = Vector3.zero;
        textObject.transform.localRotation = Quaternion.identity;

        // Attach the Text component to the text object
        textComponent = textObject.AddComponent<Text>();

        // Set the initial properties of the Text component
        textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textComponent.fontSize = 24;
        textComponent.color = Color.white;
    }

    void Update()
    {
        // Rotate the text object to face the camera
        textComponent.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
    }
}
