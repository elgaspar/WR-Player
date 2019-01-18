using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class DialogAddUrlViewModel : DialogViewModelBase, IDataErrorInfo
    {
        public DialogAddUrlViewModel(MainViewModel parent) : base(parent)
        {
        }

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

        private string _itemUrl;
        public string ItemUrl
        {
            get { return _itemUrl; }
            set
            {
                _itemUrl = value;
                NotifyOfPropertyChange(() => ItemUrl);
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
                if (string.IsNullOrEmpty(columnName) || columnName == "ItemTitle")
                {
                    if (string.IsNullOrWhiteSpace(ItemTitle))
                        result = "Can not be empty.";
                }
                if (string.IsNullOrEmpty(columnName) || columnName == "ItemUrl")
                {
                    if (string.IsNullOrWhiteSpace(ItemUrl))
                        result = "Can not be empty.";
                }
                return result;
            }
        }



        public bool CanOk { get { return IsValid; } }

        public void Ok()
        {
            Console.WriteLine("URL ADD: \n" +
                                    "\tTitle: " + ItemTitle +
                                    "\n\tURL: " + ItemUrl);//TODO: delete me

            PlaylistItem newItem = new PlaylistItem(ItemTitle, ItemUrl);
            ParentVM.PlaylistVM.AddItem(newItem);

            TryClose(true);
        }

        public void Cancel()
        {
            //Do nothing
            TryClose(null);
        }

    }
}
