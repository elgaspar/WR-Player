using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class StreamsViewModel : ViewModelBase
    {
        public StreamsViewModel(MainViewModel parent) : base(parent)
        {
            Streams = new ObservableCollection<Stream>();

            //TODO: values for debugging only
            Streams.Add(new Stream("1-kritikorama", "http://46.4.37.132:9382"));
            Streams.Add(new Stream("2-derti", "http://derti.live24.gr:80/derty1000"));
            Streams.Add(new Stream("3-mousikos", "http://netradio.live24.gr:80/mousikos986"));
            Streams.Add(new Stream("4-dromos", "http://dromos898.live24.gr:80/dromos898"));
        }

        public ObservableCollection<Stream> Streams { get; }

        private Stream _selectedStream;
        public Stream SelectedStream
        {
            get { return _selectedStream; }
            set
            {
                _selectedStream = value;
                NotifyOfPropertyChange(() => SelectedStream);
            }
        }

        public bool AreThereStreams { get { return Streams.Count != 0; } }

        public void MarkStreamAsSelected(int streamIndex)
        {
            markAllStreamsAsNotSelected();
            Stream stream = ParentVM.StreamsVM.Streams[streamIndex];
            stream.IsSelected = true;
        }

        private void markAllStreamsAsNotSelected()
        {
            foreach (Stream stream in Streams)
                stream.IsSelected = false;
        }

    }
}
