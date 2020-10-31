using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed = 5f, _zoomAmount = 2f, _minOrthographicSize = 10f, _maxOrthographicSize = 30f;
	[SerializeField] CinemachineVirtualCamera _virtualCamera;

	float _orthographicSize, _targetOrthographicSize;
	
	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_orthographicSize = _virtualCamera.m_Lens.OrthographicSize;
		_targetOrthographicSize = _orthographicSize;
	}

	void Update()
	{
		HandleMovement();

		HandleZoom();
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	void HandleMovement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(x, y).normalized;
		transform.position += moveDir * _moveSpeed * Time.deltaTime;
	}

	void HandleZoom()
	{
		_targetOrthographicSize += -Input.mouseScrollDelta.y * _zoomAmount;
		_targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, _minOrthographicSize, _maxOrthographicSize);

		_orthographicSize = Mathf.Lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * _zoomAmount);

		_virtualCamera.m_Lens.OrthographicSize = _orthographicSize;
	}
	#endregion
}
