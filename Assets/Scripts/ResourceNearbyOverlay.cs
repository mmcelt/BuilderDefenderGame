using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceNearbyOverlay : MonoBehaviour
{
	#region Fields

	[SerializeField] TextMeshPro _text;
	[SerializeField] SpriteRenderer _iconSprite;

	ResourceGeneratorData _resourceGeneratorData;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		Hide();
	}
	
	void Update() 
	{
		int nearbyResourceAmount = ResourceGenerator.GetNearbyResourceAmount(_resourceGeneratorData, transform.position);
		float percent = Mathf.RoundToInt((float)nearbyResourceAmount / _resourceGeneratorData._maxResourceAmount * 100f);
		_text.SetText(percent + "%");
	}
	#endregion

	#region Public Methods

	public void Show(ResourceGeneratorData resourceGeneratorData)
	{
		_resourceGeneratorData = resourceGeneratorData;
		gameObject.SetActive(true);

		_iconSprite.sprite = resourceGeneratorData._resourceType._sprite;

	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	#endregion

	#region Private Methods


	#endregion
}
