using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceGeneratorOverlay : MonoBehaviour
{
	#region Fields

	[SerializeField] ResourceGenerator _resourceGenerator;
	[SerializeField] SpriteRenderer _iconSprite;
	[SerializeField] Transform _bar;
	[SerializeField] TextMeshPro _text;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		ResourceGeneratorData resourceGeneratorData = _resourceGenerator.GetResourceGeneratorData();
		_iconSprite.sprite = resourceGeneratorData._resourceType._sprite;
		_bar.localScale = new Vector3(_resourceGenerator.GetTimerNormalized(), 1, 1);
		_text.SetText(_resourceGenerator.GetResourceAmountGeneratedPerSecond().ToString("F1"));
	}
	
	void Update() 
	{
		_bar.localScale = new Vector3(1 - _resourceGenerator.GetTimerNormalized(), 1, 1);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
