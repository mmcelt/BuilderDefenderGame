using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
	#region Fields

	[SerializeField] GameObject _spriteGO;

	[SerializeField] ResourceNearbyOverlay _resourceNearbyOverlay;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		Hide();
	}

	void Start()
	{
		BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
	}

	void Update() 
	{
		transform.position = Utils.GetMouseWorldPosition();
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void Show(Sprite ghostSprite)
	{
		_spriteGO.SetActive(true);
		_spriteGO.GetComponent<SpriteRenderer>().sprite = ghostSprite;
	}

	void Hide()
	{
		_spriteGO.SetActive(false);
	}

	void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
	{
		if (e.activeBuildingType == null)
		{
			Hide();
			_resourceNearbyOverlay.Hide();
		}
		else
		{
			Show(e.activeBuildingType._sprite);
			_resourceNearbyOverlay.Show(e.activeBuildingType._resourceData);
		}
	}
	#endregion
}
