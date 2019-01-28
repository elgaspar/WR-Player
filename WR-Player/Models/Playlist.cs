using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Models
{
    public class Playlist : NotifyBase
    {
        public Playlist()
        {
            _items = new ObservableCollection<PlaylistItem>();
            Items = new ReadOnlyObservableCollection<PlaylistItem>(_items);
            SelectedItemIndex = -1;
        }



        private ObservableCollection<PlaylistItem> _items { get; }
        public ReadOnlyObservableCollection<PlaylistItem> Items { get; }

        public bool AreThereItems { get { return _items.Count > 0; } }

        public PlaylistItem SelectedItem
        {
            get
            {
                if (!AreThereItems)
                    return null;
                if (SelectedItemIndex < 0)
                {
                    SelectFirstItem();
                    return _items[SelectedItemIndex];
                }
                return _items[SelectedItemIndex];
            }
        }

        private int _selectedItemIndex;
        private int SelectedItemIndex
        {
            get { return _selectedItemIndex; }
            set
            {
                _selectedItemIndex = value;
                if (value == -1)
                    return;
                MarkItemAsSelected(value);
                NotifyPropertyChanged("SelectedItem");
            }
        }

        

        public void Add(PlaylistItem item)
        {
            _items.Add(item);
            if (_items.Count == 1)
                SelectFirstItem();
        }

        public void Remove(PlaylistItem item)
        {
            int indexOfRemovedItem = _items.IndexOf(item);
            _items.Remove(item);
            updateSelectedIndexAfterRemove(indexOfRemovedItem);
        }

        public void SelectNextItem()
        {
            if (SelectedItemIndex < _items.Count - 1)
                SelectedItemIndex++;
        }

        public void SelectPreviousItem()
        {
            if (SelectedItemIndex > 0)
                SelectedItemIndex--;
        }

        public void SelectItem(PlaylistItem item)
        {
            if (_items.Contains(item))
                SelectedItemIndex = _items.IndexOf(item);
        }




        public void Clear()
        {
            _items.Clear();
        }



        public bool SaveToFile(string filepath)
        {
            return PlaylistParser.WriteToFile(this, filepath);
        }

        public bool LoadFromFile(string filepath)
        {
            Playlist loadedPlaylist = PlaylistParser.ReadFromFile(filepath);
            if (loadedPlaylist == null)
                return false;
            loadNewItemCollection(loadedPlaylist._items);
            return true;
        }





        private void updateSelectedIndexAfterRemove(int indexOfRemovedItem)
        {
            if (!AreThereItems)
            {
                SelectedItemIndex = -1;
                return;
            }
            if (indexOfRemovedItem == SelectedItemIndex)
                SelectedItemIndex = 0;
            if (indexOfRemovedItem < SelectedItemIndex)
                SelectedItemIndex--;
        }

        private void SelectFirstItem()
        {
            SelectedItemIndex = 0;
        }

        private void MarkItemAsSelected(int index)
        {
            markAllItemsAsNotSelected();
            PlaylistItem item = _items[index];
            item.IsSelected = true;
        }

        private void markAllItemsAsNotSelected()
        {
            foreach (PlaylistItem item in _items)
                item.IsSelected = false;
        }

        private void loadNewItemCollection(Collection<PlaylistItem> newItems)
        {
            _items.Clear();
            foreach (PlaylistItem item in newItems)
                _items.Add(item);
            if (Items.Count > 0)
                SelectedItemIndex = 0;
            else
                SelectedItemIndex = -1;
        }
    }
}
