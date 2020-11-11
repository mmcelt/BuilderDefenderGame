using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	#region Fields

	static Camera _mainCamera;

	#endregion

	#region Public Methods

	public static Vector3 GetMouseWorldPosition()
	{
		if (_mainCamera == null) 
			_mainCamera = Camera.main;

		Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPosition.z = 0;

		return mouseWorldPosition;
	}

	#endregion

	#region Private Methods


	#endregion
}
