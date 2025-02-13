﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Hybrid.Code;

/// <summary> 
/// Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. 
/// </summary> 
public class ObservableRangeCollection<T> : ObservableCollection<T>
{
    public bool Descending { get; set; }
    public Func<T, object>? SortingSelector { get; set; }
    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        base.OnCollectionChanged(e);
        if (SortingSelector == null || e.Action == NotifyCollectionChangedAction.Remove)
        {
            return;
        }

        var query = this.Select((item, index) => (Item: item, Index: index));
        query = Descending
            ? query.OrderByDescending(tuple => SortingSelector(tuple.Item))
            : query.OrderBy(tuple => SortingSelector(tuple.Item));

        var map = query.Select((tuple, index) => (OldIndex: tuple.Index, NewIndex: index))
            .Where(o => o.OldIndex != o.NewIndex);

        using var enumerator = map.GetEnumerator();
        if (enumerator.MoveNext())
        {
            Move(enumerator.Current.OldIndex, enumerator.Current.NewIndex);
        }
    }

    /// <summary> 
    /// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class. 
    /// </summary> 
    public ObservableRangeCollection() : base() { }

    /// <summary> 
    /// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class that contains elements copied from the specified collection. 
    /// </summary> 
    /// <param name="collection">collection: The collection from which the elements are copied.</param> 
    /// <exception cref="System.ArgumentNullException">The collection parameter cannot be null.</exception> 
    public ObservableRangeCollection(IEnumerable<T> collection) : base(collection) { }

    /// <summary> 
    /// Adds the elements of the specified collection to the end of the ObservableCollection(Of T). 
    /// </summary> 
    public void AddRange(IEnumerable<T> collection, NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Add)
    {
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));
        if (notificationMode != NotifyCollectionChangedAction.Add && notificationMode != NotifyCollectionChangedAction.Reset)
        {
            throw new ArgumentException("Mode must be either Add or Reset for AddRange.", nameof(notificationMode));
        }

        CheckReentrancy();

        var startIndex = Count;

        var itemsAdded = AddArrangeCore(collection);

        if (!itemsAdded)
        {
            return;
        }

        if (notificationMode == NotifyCollectionChangedAction.Reset)
        {
            RaiseChangeNotificationEvents(NotifyCollectionChangedAction.Reset);

            return;
        }

        var changedItems = collection is List<T> list ? list : new List<T>(collection);
        RaiseChangeNotificationEvents(NotifyCollectionChangedAction.Add, changedItems, startIndex);
    }

    /// <summary> 
    /// Removes the first occurrence of each item in the specified collection from ObservableCollection(Of T). NOTE: with notificationMode = Remove, removed items starting index is not set because items are not guaranteed to be consecutive.
    /// </summary> 
    public void RemoveRange(IEnumerable<T> collection, NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Reset)
    {
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));
        if (notificationMode != NotifyCollectionChangedAction.Remove && notificationMode != NotifyCollectionChangedAction.Reset)
        {
            throw new ArgumentException("Mode must be either Remove or Reset for RemoveRange.", nameof(notificationMode));
        }

        CheckReentrancy();

        if (notificationMode == NotifyCollectionChangedAction.Reset)
        {
            var raiseEvents = false;
            foreach (var item in collection)
            {
                Items.Remove(item);
                raiseEvents = true;
            }

            if (raiseEvents)
            {
                RaiseChangeNotificationEvents(NotifyCollectionChangedAction.Reset);
            }

            return;
        }

        // Can't use a foreach because changedItems is intended to be (carefully) modified.
        var changedItems = new List<T>(collection);
        for (var i = 0; i < changedItems.Count; i++)
        {
            if (!Items.Remove(changedItems[i]))
            {
                changedItems.RemoveAt(i);
                i--;
            }
        }

        if (changedItems.Count == 0)
        {
            return;
        }

        RaiseChangeNotificationEvents(NotifyCollectionChangedAction.Remove, changedItems);
    }

    /// <summary> 
    /// Clears the current collection and replaces it with the specified item. 
    /// </summary> 
    public void Replace(T item) => ReplaceRange([item]);

    /// <summary> 
    /// Clears the current collection and replaces it with the specified collection. 
    /// </summary> 
    public void ReplaceRange(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        CheckReentrancy();

        var previouslyEmpty = Items.Count == 0;

        Items.Clear();

        AddArrangeCore(collection);

        var currentlyEmpty = Items.Count == 0;

        if (previouslyEmpty && currentlyEmpty)
        {
            return;
        }

        RaiseChangeNotificationEvents(NotifyCollectionChangedAction.Reset);
    }

    private bool AddArrangeCore(IEnumerable<T> collection)
    {
        var itemAdded = false;
        foreach (var item in collection)
        {
            Items.Add(item);
            itemAdded = true;
        }

        return itemAdded;
    }

    private void RaiseChangeNotificationEvents(NotifyCollectionChangedAction action, List<T>? changedItems = null, int startingIndex = -1)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));

        if (changedItems is null)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action));
        }
        else
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, changedItems, startingIndex));
        }
    }

    public void RaiseObjectMoved(T obj, int index, int oldIndex)
    {
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, obj, index, oldIndex));
    }
}