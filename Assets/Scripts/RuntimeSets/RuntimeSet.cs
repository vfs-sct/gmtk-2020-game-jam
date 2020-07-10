/*
    Copyright (C) Team Triple Double, Vitor Brito 2020
*/
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Afloat
{
	public class RuntimeSet<T> : ScriptableObject
	{
        // ## UNITY EDITOR ##
		[SerializeField] private List<T> _runtimeItems = new List<T>();
        
        // ## UNITY EVENTS ##
        public UnityEvent OnItemsChanged;

		// ## PROPERTIES ##
		public List<T> RuntimeItems { get { return _runtimeItems; } }

#region // ## PUBLIC METHODS ##

	public void Add(T item)
    {
        if(!RuntimeItems.Contains(item)) RuntimeItems.Add(item);
        OnItemsChanged.Invoke();
    }

    public void Remove(T item)
    {
        if(RuntimeItems.Contains(item)) RuntimeItems.Remove(item);
        OnItemsChanged.Invoke();
    }

#endregion
	}
}
