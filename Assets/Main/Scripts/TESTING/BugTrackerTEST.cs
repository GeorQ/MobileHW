using UnityEngine;

public class BugTrackerTEST : MonoBehaviour
{
    private Rigidbody errorRef;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            errorRef.AddForce(Vector3.up);
        }
    }
}