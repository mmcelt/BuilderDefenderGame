using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceGeneratorData
{
	#region Fields

	public float _timerMax;
	public ResourceTypeSO _resourceType;   //use a list here for multiple resource types
	public float _resourceDetectionRadius;
	public int _maxResourceAmount;
	#endregion
}
