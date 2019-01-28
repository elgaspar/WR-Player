using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class DialogEditPlaylistItemViewModel : DialogViewModelBase, IDataErrorInfo
    {
        public DialogEditPlaylistItemViewModel(MainViewModel parent) : base(parent)
        {
            PlaylistItem itemToEdit = ParentVM.PlaylistVM.ItemsToProcess[0];
            ItemTitle = itemToEdit.Title;
            ItemPath = itemToEdit.Path;

            Success = null;
        }

        public bool? Success { get; private set; }

        private string _itemTitle;
        public string ItemTitle
        {
            get { return _itemTitle; }
            set
            {
                _itemTitle = value;
                NotifyOfPropertyChange(() => ItemTitle);
                NotifyOfPropertyChange(() => CanOk);
            }
        }

        private string _itemPath;
        public string ItemPath
        {
            get { return _itemPath; }
            set
            {
                _itemPath = value;
                NotifyOfPropertyChange(() => ItemPath);
                NotifyOfPropertyChange(() => CanOk);
            }
        }



        public bool IsValid { get { return string.IsNullOrEmpty(Error); } }

        public string Error { get { return this[null]; } }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (string.IsNullOrEmpty(columnName) || columnName == "Title")
                {
                    if (string.IsNullOrWhiteSpace(ItemTitle))
                        result = "Can not be empty.";
                }
                if (string.IsNullOrEmpty(columnName) || columnName == "ItemPath")
                {
                    if (string.IsNullOrWhiteSpace(ItemPath))
                        result = "Can not be empty.";
                }
                return result;
            }
        }



        public bool CanOk { get { return IsValid; } }

        public void Ok()
        {
            Success = true;
            try
            {
                ParentVM.PlaylistVM.EditItem(ItemTitle, ItemPath);
            }
            catch (Exception)
            {
                Success = false;
                TryClose(false);
            }
            
            TryClose(true);
        }

        public void Cancel()
        {
            //Do nothing
            TryClose(null);
        }
    }
}
