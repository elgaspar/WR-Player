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
            Items = new ObservableCollection<PlaylistItem>();
            SelectedItemIndex = -1;
        }



        public ObservableCollection<PlaylistItem> Items { get; private set; }

        public bool AreThereItems { get { return Items.Count > 0; } }

        public PlaylistItem SelectedItem
        {
            get
            {
                if (!AreThereItems)
                    return null;
                if (SelectedItemIndex < 0)
                {
                    SelectFirstItem();
                    return Items[SelectedItemIndex];
                }
                return Items[SelectedItemIndex];
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



        public void SelectFirstItem()
        {
            SelectedItemIndex = 0;
        }

        public void SelectNextItem()
        {
            if (SelectedItemIndex < Items.Count - 1)
                SelectedItemIndex++;
        }

        public void SelectPreviousItem()
        {
            if (SelectedItemIndex > 0)
                SelectedItemIndex--;
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
            loadNewItemCollection(loadedPlaylist.Items);
            return true;
        }





        private void MarkItemAsSelected(int index)
        {
            markAllItemsAsNotSelected();
            PlaylistItem item = Items[index];
            item.IsSelected = true;
        }

        private void markAllItemsAsNotSelected()
        {
            foreach (PlaylistItem item in Items)
                item.IsSelected = false;
        }

        private void loadNewItemCollection(Collection<PlaylistItem> newItems)
        {
            Items.Clear();
            foreach (PlaylistItem item in newItems)
                Items.Add(item);
            if (Items.Count > 0)
                SelectedItemIndex = 0;
            else
                SelectedItemIndex = -1;
        }
    }
}
