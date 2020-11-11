using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
	#region Fields

	float _timer;
	float _timerMax;
	BuildingTypeSO _buildingType;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		_buildingType = GetComponent<BuildingTypeHolder>()._buildingType;
		_timerMax = _buildingType._resourceData._timerMax;
	}
	
	void Update() 
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			_timer = _timerMax;
			//Debug.Log("Ding!! " + _buildingType._resourceData._resourceType._name);
			ResourceManager.Instance.AddResource(_buildingType._resourceData._resourceType, 1);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
