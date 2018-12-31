using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class DialogStreamAddEditViewModel : DialogViewModelBase, IDataErrorInfo
    {
        public DialogStreamAddEditViewModel(MainViewModel parent, bool addEdit) : base(parent)
        {
            AddEdit = addEdit;
            if (AddEdit == true)
            {
                Title = "Add Stream";
            }
            else
            {
                Title = "Edit Stream";
                StreamTitle = ParentVM.PlaylistVM.ItemToProcess.Title;
                StreamUrl = ParentVM.PlaylistVM.ItemToProcess.Path;
            }
        }



        private bool AddEdit { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }



        private string _streamTitle;
        public string StreamTitle
        {
            get { return _streamTitle; }
            set
            {
                _streamTitle = value;
                NotifyOfPropertyChange(() => StreamTitle);
                NotifyOfPropertyChange(() => CanOk);
            }
        }

        private string _streamUrl;
        public string StreamUrl
        {
            get { return _streamUrl; }
            set
            {
                _streamUrl = value;
                NotifyOfPropertyChange(() => StreamUrl);
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
                if (string.IsNullOrEmpty(columnName) || columnName == "StreamTitle")
                {
                    if (string.IsNullOrWhiteSpace(StreamTitle))
                        result = "Can not be empty.";
                }
                if (string.IsNullOrEmpty(columnName) || columnName == "StreamUrl")
                {
                    if (string.IsNullOrWhiteSpace(StreamUrl))
                        result = "Can not be empty.";
                }
                return result;
            }
        }



        public bool CanOk { get { return IsValid; } }

        public void Ok()
        {
            if (AddEdit)
                StreamAdd();
            else
                StreamEdit();
            TryClose(true);
        }

        public void Cancel()
        {
            //Do nothing
            TryClose(null);
        }



        private void StreamAdd()
        {
            Console.WriteLine("STREAM ADD: \n" +
                                    "\tTitle: " + StreamTitle +
                                    "\n\tURL: " + StreamUrl);//TODO: delete me

            PlaylistItem stream = new PlaylistItem(StreamTitle, StreamUrl);
            ParentVM.PlaylistVM.AddStream(stream);
        }

        private void StreamEdit()
        {
            Console.WriteLine("STREAM EDIT: \n" +
                                    "\tTitle: " + StreamTitle +
                                    "\n\tURL: " + StreamUrl);//TODO: delete me

            ParentVM.PlaylistVM.ItemToProcess.Title = StreamTitle;
            ParentVM.PlaylistVM.ItemToProcess.Path = StreamUrl;
        }
    }
}
