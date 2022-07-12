using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace KeyCount.Global
{
    /// <summary>
    /// Provides a sortable binding list
    /// </summary>
    /// <typeparam name="T">The type of the list</typeparam>
    [Serializable]
    public class SortableBindingList<T> : BindingList<T>, ITypedList
    {
        /// <summary>
        /// Contains the properties
        /// </summary>
        [NonSerialized]
        private readonly PropertyDescriptorCollection? _properties;

        /// <summary>
        /// Contains the current property
        /// </summary>
        [NonSerialized]
        private PropertyDescriptor? _currentProperty;

        /// <summary>
        /// Contains the current sorting direction
        /// </summary>
        [NonSerialized]
        private ListSortDirection _currentDirection;

        /// <summary>
        /// Creates a new empty instance of the <see cref="SortableBindingList{T}" />
        /// </summary>
        public SortableBindingList()
        {
            // Get the 'shape' of the list. 
            // Only get the public properties marked with Browsable = true.
            var pdc = TypeDescriptor.GetProperties(
                typeof(T),
                new Attribute[] { new BrowsableAttribute(true) });

            // Sort the properties.
            _properties = pdc.Sort();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SortableBindingList{T}" />
        /// </summary>
        /// <param name="list">The list which should be converted into the <see cref="SortableBindingList{T}" /></param>
        public SortableBindingList(IEnumerable<T> list) : this()
        {
            AddRange(list);
        }

        /// <summary>
        /// Adds a list of items
        /// </summary>
        public void AddRange(IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Gets the item properties for a list of properties
        /// </summary>
        /// <param name="listAccessors">List of properties</param>
        /// <returns>The property descriptions</returns>
        public PropertyDescriptorCollection? GetItemProperties(PropertyDescriptor[]? listAccessors)
        {
            var pdc = null == listAccessors
                ? _properties
                : ListBindingHelper.GetListItemProperties(listAccessors[0].PropertyType);

            return pdc;
        }

        /// <summary>
        /// This method is only used in the design-time framework
        /// and by the obsolete DataGrid control.
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }

        /// <inheritdoc />
        protected override bool SupportsSortingCore => true;

        /// <inheritdoc />
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var helper = (List<T>)Items;
            _currentProperty = prop;
            _currentDirection = direction;
            helper.Sort(Compare);
        }

        /// <summary>
        /// Compares two types
        /// </summary>
        private int Compare(T a, T b)
        {
            if (a == null && b == null)
                return 0;

            if (a == null && b != null)
                return -1;

            if (a != null && b == null)
                return -1;

            var valA = _currentProperty?.GetValue(a) ?? null;
            var valB = _currentProperty?.GetValue(b) ?? null;

            if (valA is KeyValuePair<int, string> pair && valB is KeyValuePair<int, string> otherPair)
            {
                valA = pair.Value;
                valB = otherPair.Value;
            }

            var icA = valA as IComparable;
            var icB = valB as IComparable;

            switch (icA)
            {
                case null when icB == null:
                    return 0;
                case null:
                    return _currentDirection == ListSortDirection.Ascending ? -1 : 1;
            }

            if (icB == null)
                return _currentDirection == ListSortDirection.Ascending ? 1 : -1;


            if (_currentDirection == ListSortDirection.Ascending)
                return icA.CompareTo(icB);

            return -icA.CompareTo(icB);
        }

        /// <inheritdoc />
        protected override void RemoveSortCore() { }
    }

}
