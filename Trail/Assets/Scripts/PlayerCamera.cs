using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public Transform CameraTarget;

	private void LateUpdate()
	{
		if (CameraTarget == null)
		{
			return;
		}

		Vector3 targetPosition = CameraTarget.position;
		Quaternion targetroatation = CameraTarget.rotation;
		//targetPosition.y = Mathf.Max(targetPosition.y, 0f);
		//targetPosition.x = Mathf.Max(targetPosition.x, 0f);
		//targetPosition.z = targetPosition.z;
		transform.position = targetPosition;
		//transform.rotation = targetroatation;
	}
}