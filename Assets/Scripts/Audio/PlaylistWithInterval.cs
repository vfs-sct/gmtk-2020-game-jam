/*
    Copyright (C) Team Triple Double, Vitor Brito 2020
*/
using System.Collections;
using UnityEngine;

namespace Afloat
{
	public class PlaylistWithInterval : MonoBehaviour
	{
		// ## UNITY EDITOR ##
		[SerializeField] private AudioSourceController _audioController;
		[SerializeField] private float _interval;
		[SerializeField] private bool _addVariation;
		[SerializeField] private float _randomVariationRange;

		// ## PRIVATE VARS ##
		private Coroutine _playingCoroutine;
		private float _currentInterval;

#region // ## MONOBEHAVIOUR METHODS ##

		private void Start()
		{
			_currentInterval = _addVariation ? _interval + Random.Range(0, _randomVariationRange) : _interval; 
			_playingCoroutine = StartCoroutine(Playing());
		}

#endregion

#region // ## PRIVATE METHODS ##

		IEnumerator Playing()
		{
			while(true)
			{
				yield return new WaitForSeconds(_currentInterval);
				_audioController.PlayImmediately();
				_currentInterval = _addVariation ? _interval + Random.Range(0, _randomVariationRange) : _interval; 
			}
		}

#endregion

	}
}
